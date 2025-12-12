using System.Collections;
using AO;
using Assembly.scripts;

namespace Assembly.scripts;

public abstract partial class Mob : Component
{
    public static List<Mob> ActiveMobs = new();

    [Serialized] public Movement_Agent Agent;
    [Serialized] public Spine_Animator Animator;
    [Serialized] public Entity CenterMassAnchor;
    [Serialized] public Entity HealthBarAnchor;

    public HashSet<string> FreezeReasons = new();
    public AIBehaviour ServerCurrentBehaviour;
    public Dictionary<Type, float> AbilityCooldowns = new();
    public WeightedList<Type> AbilityPool = new();
    public Vector2 InitialPosition;
    public bool LocalIsBeingTargeted;
    
    protected List<MobEffect> Effects = new();
    protected SyncVar<bool> IsDying = new();
    
    private Vector2[] PathPoints;
    
    protected virtual AIBehaviour InitialState { get; }
    protected abstract int CombatLevel { get; }
    public abstract string MobName { get; }
    protected virtual float StartingSpeed => 100;
    protected virtual bool IsValidTarget => true;
    protected virtual float MaxHealthMultiplier => 1f;
    protected virtual string DeathSound => null;
    protected virtual string[] IdleSounds => null;
    protected virtual string DamagedSound => null;
    protected virtual bool CanEffectsBeApplied => true;
    protected virtual Prefab DeathVFX => null;
    protected virtual bool ShouldFlipAnimator => true;
    // Different anchors for each effect since scaling/positioning is different for each VFX and each mob
    public Entity CenterOfMass => CenterMassAnchor ?? Entity;

    public SyncVar<int> Health = new();
    public SyncVar<int> MaxHealth = new();
    public SyncVar<Vector2> Destination = new();
    public SyncVar<float> Speed = new();
    
    public override void Awake()
    {
        InitialPosition = Entity.Position;
        
        if (Network.IsServer)
        {
            MaxHealth.Set((int)MathF.Floor(MyUtil.GetGlobalHealthForLevel(CombatLevel) * MaxHealthMultiplier));
            Health.Set(MaxHealth.Value);
            Destination.Set(Entity.Position);
            Speed.Set(StartingSpeed);

            var initialState = InitialState;
            if (initialState != null)
            {
                ServerSetBehaviour(initialState);
            }
            else
            {
                DecideNextAction();
            }
        }

        if (Animator != null)
        {
            Animator.Awaken();
            var sm = StateMachine.Create();
            SetupSpine(sm);
            Animator.SpineInstance.SetStateMachine(sm, true);
        }
        
        Agent.ClientsidePrediction = true;
        Agent.CustomVelocityCallback = (agent, currentVelocity, input, dt) =>
        {
            if (FreezeReasons.Count > 0 || Health <= 0)
            {
                return Vector2.Zero;
            }

            if (Agent.NavmeshToLockTo == null)
            {
                if (Navmesh.TryFindClosestPointOnAnyNavmesh(Entity.Position, out var point, out var navmesh))
                {
                    Agent.NavmeshToLockTo = navmesh;
                }
                else
                {
                    Log.Warn("WTF");
                    return Vector2.Zero;
                }
            }

            if (Vector2.Distance(Entity.Position, Destination.Value) > 0.1f && Agent.NavmeshToLockTo.TryFindPath(agent.Entity.Position, Destination.Value, ref PathPoints, out int pathLength))
            {
                Vector2 nextPoint = PathPoints[1];
                Vector2 direction = (nextPoint - agent.Entity.Position).Normalized;

                float effectSpeedMultiplier = 1f;
                foreach (var effect in Effects)
                {
                    effectSpeedMultiplier *= effect.SpeedMultiplier;
                }

                return currentVelocity + direction * Speed * effectSpeedMultiplier * dt;
            }

            return currentVelocity;
        };
        
        ActiveMobs.Add(this);
    }
    
    protected abstract void SetupSpine(StateMachine sm);

    public abstract void DecideNextAction();

    public void AddFreezeReason(string reason)
    {
        FreezeReasons.Add(reason);
    }
    
    public void RemoveFreezeReason(string reason)
    {
        FreezeReasons.Remove(reason);
    }

    public virtual void DrawHealthBar(AllOut.DeferImpl pushContext, AllOut.DeferImpl pushZ, AllOut.DeferImpl pushScaleFactor)
    {
        if (Network.IsServer) return;

        // Only render the health bar if the mob is actually damaged
        if (!LocalIsBeingTargeted) return;

        // Create a rect above the turret
        var healthBarPosition = HealthBarAnchor.Position;
        var healthRect = new Rect(healthBarPosition, healthBarPosition).Grow(25, 70, 0, 70);

        // Cull the drawing if the rect is not on screen
        if (!Camera.GetCurrentCameraWorldRect().Overlaps(healthRect)) return; 
        
        var borderRect = healthRect.Grow(5.5f, 4, 5.5f, 4).Offset(0, -2);

        // Get the bar textures
        var back = Assets.GetAsset<Texture>("Sprites/HUD Elements/hp bars/mob hp bar/back.png");
        var fill = Assets.GetAsset<Texture>("Sprites/HUD Elements/hp bars/mob hp bar/fill.png");
        var front = Assets.GetAsset<Texture>("Sprites/HUD Elements/hp bars/mob hp bar/front.png");
		
		// Draw bar background
		UI.Image(borderRect, back, Vector4.White, new UI.NineSlice());
		
		// Draw health percentage
		var healthPercent = (float)Health.Value / (float)MaxHealth.Value;
		var healthPercentRect = healthRect.SubRect(0, 0, healthPercent, 1, 0, 0, 0, 0);
		UI.Image(healthPercentRect, fill, Vector4.White, new UI.NineSlice());

        UI.Image(healthRect, front, Vector4.White, new UI.NineSlice());
		
        // Disabling the text rendering for now since it is very expensive
        // Draw health count text
        //using var _4 = UI.PUSH_SCALE_FACTOR(3.0f / 540.0f);
        //UI.TextAsync(healthRect, $"{Health.Value:0}/{MaxHealth.Value:0}", GameManager.GetTextSettings(24, Vector4.White, UI.HorizontalAlignment.Center));

        // Name text
        //UI.TextAsync(healthRect.Offset(0.0f, 50f), $"{MobName}", GameManager.GetTextSettings(36, Vector4.White, UI.HorizontalAlignment.Center));

        // Draw effect tags
        var effectTagRect = healthRect.Offset(0.0f, 50.0f);
        foreach (var effect in Effects)
        {
            effectTagRect = effect.GetEffectTagRect(effectTagRect);
            effectTagRect = effectTagRect.Offset(0, 5);
        }
    }

    public override void Update()
    {
        
        if (Network.IsServer)
        {
            /*var closestDistance = float.MaxValue;
            foreach (var player in Scene.Components<MyPlayer>())
            {
                var distance = Vector2.Distance(player.Entity.Position, Entity.Position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                }
            }*/

            Entity.NetSyncFlags = /*closestDistance < 10 ?*/ Entity.NetSyncOptions.Enabled/* : Entity.NetSyncOptions.None*/;
            
            var hasBlockingEffect = Effects.Any(effect => !effect.AllowBehaviourToRun);
            if (ServerCurrentBehaviour != null && !hasBlockingEffect && !IsDying.Value)
            {
                ServerCurrentBehaviour.OnUpdate(Time.DeltaTime);
            }
        }
        else
        {
            if (Health.Value > 0)
            {
                if (Animator != null)
                {
                    if (ShouldFlipAnimator && FreezeReasons.Count == 0)
                    {
                        if (PathPoints != null && PathPoints.Length > 0)
                        {
                            Animator.SpineInstance.Scale = new Vector2(PathPoints[0].X < Entity.Position.X ? 1f : -1f, 1f);    
                        }
                    }

                    bool moving = Agent.Velocity.LengthSquared > 0.1f; 
                    Animator.SpineInstance.StateMachine.SetBool("moving", moving);
                }
            }

            // Cull the mob and its health bar if they are not on screen
            if (!Network.IsServer)
            {
                // Reuse the contexts for the rects for both the spine and the health bar
                using var _pushContext = UI.PUSH_CONTEXT(UI.Context.World);
                using var _pushZ = IM.PUSH_Z(-0.0001f);
                using var _pushScaleFactor = UI.PUSH_SCALE_FACTOR(5.0f / 540.0f);

                // Check if the spine is either on screen or just offscreen
                bool isOnScreen = CheckIsSpineOnScreen(_pushContext, _pushZ, _pushScaleFactor);
                bool aliveOrVisibleDuringDeath = !IsDying.Value;
                Animator.LocalEnabled = isOnScreen && aliveOrVisibleDuringDeath;

                if (isOnScreen)
                {
                    // Optionally show the health bar, which has a tighter culling box
                    if (aliveOrVisibleDuringDeath)
                    {
                        //TODO Health Bar logic for players in combat
                        DrawHealthBar(_pushContext, _pushZ, _pushScaleFactor);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Used to check if the spine renderer is on screen
    /// The 1.5x for the camera is to give a bit of a buffer since we don't have the exact bounds of the spine
    /// As of May 22nd, there is an update coming to the editor that will also significantly speed up the performance of spines
    /// --> Another future update will allow us to use the exact bounds of the spine, which will allow us to remove the 1.5x buffer
    /// </summary>
    public bool CheckIsSpineOnScreen(AllOut.DeferImpl pushContext, AllOut.DeferImpl pushZ, AllOut.DeferImpl pushScaleFactor)
    {
        var rect = new Rect(Entity.Position, Entity.Position).Grow(50, 50, 50, 50);
        return Camera.GetCurrentCameraWorldRect().Scale(1.5f).Overlaps(rect);
    }
    
    public void ServerSetBehaviour(AIBehaviour behaviour)
    {
        ServerCurrentBehaviour?.OnEnded();
        ServerCurrentBehaviour = behaviour;

        if (ServerCurrentBehaviour == null) 
            return;
        
        ServerCurrentBehaviour.Mob = this;
        ServerCurrentBehaviour.OnStarted();
    }

    public WeightedList<Type> GetAvailableAbilities(WeightedList<Type> fromPool = null)
    {
        fromPool ??= new WeightedList<Type> { AbilityPool };

        for (int i = fromPool.Count - 1; i >= 0; i--)
        {
            if (!IsAbilityCooldownComplete(fromPool[i]))
            {
                fromPool.RemoveAt(i);
            }
        }
        
        return fromPool;
    }

    public bool IsAbilityCooldownComplete(Type type)
    {
        return !AbilityCooldowns.ContainsKey(type) || AbilityCooldowns[type] < Time.TimeSinceStartup;
    }

    public void ApplyCooldown(Type type, float cooldown)
    {
        AbilityCooldowns[type] = Time.TimeSinceStartup + cooldown;
    }
    
    public virtual IEnumerator OnDespawn()
    {
        Animator.LocalEnabled = false;
        yield return null;
    }
    
    [ClientRpc]
    public void Despawn()
    {
        FreezeReasons.Add(nameof(Despawn));
        
        Coroutine.Start(Entity, DespawnRoutine());
        IEnumerator DespawnRoutine()
        {
            yield return Coroutine.Start(Entity, OnDespawn());

            //Ensure the above routine is fully done
            yield return new WaitForSeconds(1);
            
            if (!Network.IsServer)
            {
                yield break;
            }
            
            ServerSetBehaviour(null);
        
            Network.Despawn(Entity);
            Entity.Destroy();    
        }
    }

    public virtual void ServerOnDeath(MyPlayer killer)
    {
        if (TryGetDropTableForMob(GetType(), out var dropTable))
        {
            foreach (var tuple in dropTable.GetDrops())
            {
                GameItems.Instance.SpawnLootInstance(tuple.Item1, Entity.Position, true, tuple.Item2, lockedOwner: killer);
            }
        }
        
        IsDying.Set(true);
        CallClient_SpawnDeathVFX();
        CallClient_Despawn();
    }

    [ClientRpc]
    public void SpawnDeathVFX()
    {
        if (DeathSound != null)
        {
            SFX.Play(Assets.GetAsset<AudioAsset>(DeathSound), new SFX.PlaySoundDesc() { EntityToFollow = Entity, RangeMultiplier = 2, Volume = 0.6f, VolumePerturb = 0.1f, SpeedPerturb = 0.1f });
        }

        if (DeathVFX != null)
        {
            throw new NotImplementedException();
        }
    }

    [ClientRpc]
    public void TriggerAnim(string animTrigger, string sound)
    {
        if (!string.IsNullOrEmpty(sound))
        {
            var soundAsset = Assets.GetAsset<AudioAsset>(sound);
            if (soundAsset != null)
            {
                SFX.Play(soundAsset, new SFX.PlaySoundDesc() { EntityToFollow = Entity, RangeMultiplier = 4, Volume = 0.7f, VolumePerturb = 0.1f, SpeedPerturb = 0.1f });
            }
            else
            {
                Log.Warn($"Trying to play TriggerAnim sound for mobs but the sound asset was not found: {sound}");
            }
        }
        
        Animator.SpineInstance.StateMachine.SetTrigger(animTrigger);
    }

    [ClientRpc]
    public void ShootProjectile(MyPlayer target, string prefabId, Vector2 pos, Vector2 dir, string anim, float scale)
    {
        throw new NotImplementedException();
        /*var projectileEntity = Game.SpawnProjectile(target.Entity, prefabId, $"{MobName}_projectile", pos, dir);
        projectileEntity.Scale = Vector2.One * scale;
        var bullet = projectileEntity.GetComponent<Bullet>();
        bullet.MaxLifespan = 5f;

        if (bullet.Spine != null)
        {
            bullet.Spine.SpineInstance.SetAnimation(anim, true);
        }*/
    }
    
    [ClientRpc]
    public virtual bool TryHit(int damage, HitsplatType splatType, MyPlayer source)
    {
        if (!CanHit()) return false;

        if (source.Alive() && source.IsLocal)
        {
            LocalIsBeingTargeted = true;
            SFX.Play(Assets.GetAsset<AudioAsset>("SFX/impact.wav"), new SFX.PlaySoundDesc() { Positional = false, Volume = 0.6f, Speed = Random.Shared.NextFloat(0.95f, 1.05f) });
        }
        
        if (Network.IsServer)
        {
            if (source.Alive())
            {
                source.CombatSkill.ServerAwardXp(damage * 10);
            }
            
            Health.Set(Math.Max(Health - damage, 0));
            if (Health == 0)
            {
                ServerOnDeath(source);
            }
        }
        else
        {
            using var _pushContext = UI.PUSH_CONTEXT(UI.Context.World);
            using var _pushZ = IM.PUSH_Z(-0.0001f);
            using var _pushScaleFactor = UI.PUSH_SCALE_FACTOR(5.0f / 540.0f);

            if (CheckIsSpineOnScreen(_pushContext, _pushZ, _pushScaleFactor))
            {
                GameManager.Instance.AddHitsplat(CenterMassAnchor.Position, splatType, damage.ToString());
                MyUtil.FlashSprite(Entity, Animator, Vector4.Red);
            }
        }

        return true;
    }

    public virtual bool CanHit() => Entity.Alive() && Health > 0 && IsValidTarget && !IsDying.Value;

    public override void OnDestroy()
    {
        ActiveMobs.Remove(this);
    }
    
    // Adds an effect to the mob, or refreshes the duration of an existing effect if it already exists
    public void AddOrRefreshEffect<T>(MyPlayer caster, Action<T> preInit = null, bool triggerPreInitWithRefresh = false) where T : MobEffect
    {
        AddOrRefreshEffect(caster, typeof(T), effect => { preInit?.Invoke((T)effect); });
    }

    public void AddOrRefreshEffect(MyPlayer caster, Type effectType, Action<MobEffect> preInit = null, bool triggerPreInitWithRefresh = false)
    {  
        if (!CanEffectsBeApplied) return;

        if (HasEffect(effectType))
        {
            // TODO: Need to think about how to handle the caster when refreshing an effect
            Log.Info($"Mob [{MobName} - {Entity.Id}] effect [{effectType.Name}] REFRESHED");

            var effect = GetEffect(effectType);
            effect.Refresh();

            if (triggerPreInitWithRefresh)
            {
                preInit?.Invoke(effect);
            }
        }
        else
        {
            Log.Info($"Mob [{MobName} - {Entity.Id}] effect [{effectType.Name}] ADDED");

            var effectEntity = Entity.Create();
            effectEntity.Name = effectType.Name;
            effectEntity.Position = Entity.Position;
            effectEntity.SetParent(Entity, true);

            var effectInstance = effectEntity.AddComponent(effectType, onBeforeAwake: effect => 
            {
                preInit?.Invoke((MobEffect)effect);
            }) 
            as MobEffect;

            effectInstance.Mob = this;
            effectInstance.Caster = caster;
            effectInstance.RequestStart();

            Effects.Add(effectInstance);
        }
    }

    public bool HasEffect<T>() where T : MobEffect
    {
        return HasEffect(typeof(T));
    }

    public bool HasEffect(Type effectType)
    {
        return Effects.Any(e => e.GetType() == effectType);
    }

    public T GetEffect<T>() where T : MobEffect
    {
        return Effects.FirstOrDefault(e => e.GetType() == typeof(T)) as T;
    }

    public MobEffect GetEffect(Type effectType)
    {
        return Effects.FirstOrDefault(e => e.GetType() == effectType);
    }

    public bool TryGetEffect<T>(out T effect) where T : MobEffect
    {
        effect = GetEffect<T>();
        return effect != null;
    }

    public bool TryGetEffect(Type effectType, out MobEffect effect)
    {
        effect = GetEffect(effectType);
        return effect != null;
    }

    public bool RemoveEffect<T>(bool interrupt) where T : MobEffect
    {
        var effect = Effects.FirstOrDefault(e => e.GetType() == typeof(T));
        return RemoveEffect(effect, interrupt);
    }

    public bool RemoveEffect(MobEffect effect, bool interrupt)
    {
        if (!effect.Alive() ||!Effects.Contains(effect)) return false;

        Log.Info($"Mob [{MobName} - {Entity.Id}] effect [{effect.GetType().Name}] REMOVED");

        effect.RequestEnd(interrupt);
        Effects.Remove(effect);

        effect.Entity.Destroy();
        return true;
    }
}

public abstract class AIBehaviour
{
    public Mob Mob;
    public float TimeElapsed;

    public Action OnComplete;
    
    public virtual void OnStarted() { }

    public void OnUpdate(float deltaTime)
    {
        TimeElapsed += deltaTime;
        Update();
    }
    protected abstract void Update();
    public virtual void OnEnded() { }

    public T MobAs<T>() where T : Mob
    {
        return (T)Mob;
    }

    protected void CompleteBehaviour()
    {
        if (OnComplete == null)
        {
            Mob.DecideNextAction();
        }
        else
        {
            OnComplete.Invoke();    
        }
    }
}

public class IdleBehaviour : AIBehaviour
{
    public float Time;

    protected override void Update()
    {
        if (TimeElapsed > Time)
        {
            CompleteBehaviour();
        }
    }
}

public class MoveToDestinationBehaviour : AIBehaviour
{
    public Vector2 Destination;

    public override void OnStarted()
    {
        Mob.Destination.Set(Destination);
    }

    protected override void Update()
    {
        if (Vector2.Distance(Mob.Entity.Position, Destination) < 1)
        {
            CompleteBehaviour();
        }
    }
}