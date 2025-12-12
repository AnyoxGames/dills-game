using System.Collections;
using AO;

namespace Assembly.scripts;

public partial class VFX : Component
{
    private static VFX _instance;
    public static VFX Instance
    {
        get
        {
            if (_instance == null)
            {
                foreach (var component in Scene.Components<VFX>())
                {
                    _instance = component;
                    _instance.Awaken();
                    break;
                }
            }
            return _instance;
        }
    }
    
    public struct ParticleData
    {
        public Vector2 Position;
        public Vector2 Velocity;
        public float Lifetime;
    }

    public struct Particle
    {
        public Texture texture;
        public Func<ParticleData, ParticleData> OnUpdateVelocity;
        public ParticleData Data;
        public Vector4 Color;
        public float Size;

        public Particle(Texture texture, Func<ParticleData, ParticleData> onUpdateVelocity, Vector2 position, Vector2 velocity, Vector4 color, float size, float lifetime)
        {
            this.texture = texture;
            OnUpdateVelocity = onUpdateVelocity;
            Data = new ParticleData() { Position = position, Velocity = velocity, Lifetime = lifetime };
            Color = color;
            Size = size;
        }
    }
    
    private static readonly List<VFXInstance> Instances = new();
    private static List<Particle> ScreenParticles = new();
    private static IM.QuadData[] ParticleQuads;

    public class VFXInstance
    {
        public Entity Entity;
        public Spine_Animator Animator;
        public Entity FollowTarget;
        public Vector2 Offset;
        public float TotalTime;

        public Action<Vector2, Vector2> OnPositionUpdated;
        public Action<Vector2> OnEndReached;

        public VFXInstance SetTotalime(float time)
        {
            TotalTime = time;
            return this;
        }
        
        public VFXInstance SetFollowEntity(Entity entity)
        {
            FollowTarget = entity;
            return this;
        }
        
        public VFXInstance SetSkin(string skin)
        {
            Animator.SpineInstance.SetSkin(skin);
            Animator.SpineInstance.RefreshSkins();
            return this;
        }

        public VFXInstance SetScale(float scale)
        {
            Entity.Scale = Vector2.One * scale;
            return this;
        }
        
        public VFXInstance SetOffset(float x, float y)
        {
            Offset = new Vector2(x, y);
            return this;
        }
        
        public VFXInstance SetDepthOffset(float offset)
        {
            Animator.DepthOffset = offset;
            return this;
        }
    }

    public override void Update()
    {
        if (ParticleQuads == null || ParticleQuads.Length < ScreenParticles.Count)
        {
            ParticleQuads = new IM.QuadData[ScreenParticles.Count];
        }

        if (ScreenParticles.Count == 0) 
            return;
        
        using var _1 = UI.PUSH_CONTEXT(UI.Context.SCREEN);
        using var _2 = UI.PUSH_LAYER(100);
        using var _3 = UI.PUSH_SCALE_FACTOR(10.0f);
        
        for (int i = ScreenParticles.Count - 1; i >= 0; i--)
        {
            var particle = ScreenParticles[i];
            particle.Data.Position += particle.Data.Velocity * Time.DeltaTime;
            particle.Data.Lifetime -= Time.DeltaTime;

            if (particle.Data.Lifetime <= 0)
            {
                ScreenParticles.RemoveAt(i);
            }
            else
            {
                ParticleQuads[i] = new IM.QuadData(particle.Data.Position - new Vector2(particle.Size, particle.Size), particle.Data.Position + new Vector2(particle.Size, particle.Size), particle.Color, particle.texture);
                particle.Data = particle.OnUpdateVelocity?.Invoke(particle.Data) ?? particle.Data;
                ScreenParticles[i] = particle;
            }
        }
        if (ScreenParticles.Count > 0)
        {
            IM.Quads(ParticleQuads, ScreenParticles.Count);
        }
    }

    public override void LateUpdate()
    {
        for (int i = Instances.Count - 1; i >= 0; i--)
        {
            if (!Instances[i].Entity.Alive())
            {
                Instances.RemoveAt(i);
                continue;
            }
            
            if (Instances[i].FollowTarget.Alive())
            {
                Instances[i].Entity.Position = Instances[i].FollowTarget.Position + Instances[i].Offset;
            }
        }
    }
    
    public static void SpawnParticles(Vector2 startPos, Rect target, int amount, string assetId = "Sprites/Gold.png")
    {
        if (Network.LocalPlayer == null)
        {
            return;
        }
        
        ParticleData UpdateParticleVelocity(ParticleData data)
        {
            if ((target.Center - data.Position).Length < 15)
            {
                data.Lifetime = 0;
            }
            data.Velocity = Vector2.Lerp(data.Velocity, (target.Center - data.Position).Normalized * 700, Time.DeltaTime * 2);
            return data;
        }
        Particle particle = new Particle(Assets.GetAsset<Texture>(assetId), UpdateParticleVelocity, startPos, Vector2.Zero, Vector4.White, 25, 1000);
        SpawnScreenParticle(particle, amount, true, 500);
    }
    
    public static void SpawnScreenParticle(Particle particle, int count, bool useRandomStartVelocity = false, float magnitude = 0.0f)
    {
        for (int i = 0; i < Math.Min(count, 500); i++)
        {
            if (useRandomStartVelocity)
            {
                particle.Data.Velocity = new Vector2(Random.Shared.NextFloat(-magnitude, magnitude), Random.Shared.NextFloat(-magnitude, magnitude));
            }
            ScreenParticles.Add(particle);
        }
    }

    private static VFXInstance CreateSkeletonSequence(SpineSkeletonAsset skeleton, Vector2 pos, string introAnim, float introTime, string idleAnim, float idleTime, string outroAnim, float outroTime)
    {
        var entity = Entity.Create();
        entity.Position = pos;
        
        var sm = StateMachine.Make();
        var layer = sm.CreateLayer("main");
        layer.InitialState = layer.CreateState(introAnim, 0, false);
        var idle = layer.CreateState(idleAnim, 0, true);
        layer.CreateTransition(layer.InitialState, idle, true);
        layer.CreateTransition(idle, layer.CreateState(outroAnim, 0, false), false).CreateTriggerCondition(sm.CreateVariable("end", StateMachineVariableKind.TRIGGER));
        
        var animator = entity.AddComponent<Spine_Animator>();
        animator.SpineInstance.SetSkeleton(skeleton);
        animator.SpineInstance.SetStateMachine(sm, entity);
        animator.DepthOffset = -0.25f;
        
        var instance = new VFXInstance()
        {
            Entity = entity,
            Animator = animator,
            TotalTime = idleTime + outroTime + idleTime
        };
        
        Instances.Add(instance);

        Coroutine.Start(entity, _routine());
        
        return instance;

        IEnumerator _routine()
        {
            yield return new WaitForSeconds(introTime + idleTime);
            animator.SpineInstance.StateMachine.SetTrigger("end");
            yield return new WaitForSeconds(outroTime);
            animator.Entity.Destroy();
        }
    }

    private static VFXInstance CreateSkeleton(SpineSkeletonAsset skeleton, Vector2 pos, string anim, float totalTime)
    {
        var entity = Entity.Create();
        entity.Position = pos;
        
        var animator = entity.AddComponent<Spine_Animator>();
        
        animator.SpineInstance.SetSkeleton(skeleton);
        animator.SpineInstance.SetAnimation(anim, false);    
        
        animator.DepthOffset = -0.25f;

        if (totalTime > 0)
        {
            Coroutine.Start(entity, FadeAway(animator, Math.Max(totalTime, 0f)));
        }

        var instance = new VFXInstance()
        {
            Entity = entity,
            Animator = animator,
            TotalTime = totalTime
        };
        
        Instances.Add(instance);
        
        return instance;
    }
    
    private static VFXInstance CreateLerpedSkeleton(VFXInstance instance, Vector2 start, Func<Vector2> end)
    {
        Coroutine.Start(instance.Entity, LerpToPosition(instance, start, end, instance.TotalTime));
        return instance;
    }
    
    private static IEnumerator LerpToPosition(VFXInstance instance, Vector2 start, Func<Vector2> end, float duration)
    {
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            var target = end();
            instance.Entity.Position = Vector2.Lerp(start, target, timeElapsed / duration);
            instance.OnPositionUpdated?.Invoke(instance.Entity.Position, target);
            timeElapsed += Time.DeltaTime;
            yield return null;
        }
        
        instance.OnEndReached?.Invoke(end());
    }
    
    private static IEnumerator FadeAway(Spine_Animator animator, float duration)
    {
        yield return new WaitForSeconds(duration);

        if (animator.SpineInstance.StateMachine != null)
        {
            animator.SpineInstance.StateMachine.SetTrigger("outro");
        }
        else
        {
            float lerp = 0;
            while (lerp < 0.5f)
            {
                lerp += Time.DeltaTime;
                animator.SpineInstance.ColorMultiplier = new Vector4(1f, 1f, 1f, 1 - lerp / 0.5f);
                yield return null;
            }
        }

        animator.Entity.Destroy();
    }
    
    [ClientRpc]
    public VFXInstance CreateDarkFireImpact(Vector2 pos)
    {
        return CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/HitEffects/hit_effect.spine"), pos, "Dark_Fire_Impact", 0.717f);
    }
    
    [ClientRpc]
    public VFXInstance CreateConfusedEffect(Vector2 pos)
    {
        return CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/HitEffects/hit_effect.spine"), pos, "Confusion_Smoke_Impact", 0.917f);
    }
    
    [ClientRpc]
    public void CreateLightningBurst(Vector2 pos)
    {
        Coroutine.Start(Entity, _SpawnLightnings());

        IEnumerator _SpawnLightnings()
        {
            var delay = new WaitForSeconds(0.1f);
            CreateLightning(pos - Vector2.Up * 0.2f + Vector2.Right * 0.35f);
            yield return delay;
            CreateLightning(pos - Vector2.Up * 0.2f - Vector2.Right * 0.35f);
            yield return delay;
            CreateLightning(pos + Vector2.Up * 0.2f);    
        }
    }
    
    [ClientRpc]
    public VFXInstance CreateLightning(Vector2 pos)
    {
        return CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/LightningStrike/lightning_strike.spine"), pos, "strike", 2.4f);
    }
    
    [ClientRpc]
    public VFXInstance CreateAcidCircular(Vector2 pos)
    {
        return CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/HitEffects/hit_effect.spine"), pos, "Acid/Acid_Circular", 0.283f);
    }
    
    [ClientRpc]
    public VFXInstance CreateLargeExplosion(Vector2 pos)
    {
        var animator = CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/LargeExplosion/explosion_big.spine"), pos, "Boom", 1.9f);
        animator.Entity.Scale = Vector2.One * 0.5f;
        return animator;
    }
    
    [ClientRpc]
    public VFXInstance CreateHealingBlob(Vector2 pos)
    {
        return CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/Projectiles/General_Projectile_VFX.spine"), pos, "Healing_Glob/Healing_Glob_Hit", 0.65f);
    }
    
    [ClientRpc]
    public VFXInstance CreateHealFX(Entity entity, Vector2 offset = default)
    {
        SFX.Play(Assets.GetAsset<AudioAsset>("SFX/restore_hp.wav"), new SFX.PlaySoundDesc() { Positional = true, EntityToFollow = entity, Speed = Random.Shared.NextFloat(0.95f, 1.05f) });
        
        var animator = CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/heal_effect_spine/heal_effect.spine"), entity.Position, "Swirl", 1.467f);
        animator.FollowTarget = entity;
        animator.Offset = offset;
        return animator;
    }
    
    [ClientRpc]
    public VFXInstance CreateToxicSpores(Vector2 pos)
    {
        return CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/Projectiles/General_Projectile_VFX.spine"), pos, "Toxic_Spores/Toxic_Spore_Burst", 0.33f);
    }
    
    [ClientRpc]
    public VFXInstance CreateFireball2Explosion(Vector2 pos)
    {
        return CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/Projectiles/General_Projectile_VFX.spine"), pos, "FireBall/FireBall2_Impact", 0.6f);
    }
    
    [ClientRpc]
    public VFXInstance CreateDarkSmokeCloud(Vector2 pos)
    {
        return CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/Projectiles/General_Projectile_VFX.spine"), pos, "Dark_Smoke_Ball/Dark_Smoke_Ball_Hit", 0.782f);
    }
    
    [ClientRpc]
    public VFXInstance CreateWebSplat(Vector2 pos)
    {
        return CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/Projectiles/General_Projectile_VFX.spine"), pos, "Spider_Web/Spider_Web_Burst", 0.333f);
    }

    [ClientRpc]
    public VFXInstance CreateWinnerAura(Vector2 pos, float time)
    {
        return CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/WinnerAura/014ANT_winner_auras.spine"), pos, "Loop", time/*, "Start", "End", 0.333f*/);
    }
    
    public VFXInstance CreateFireball(Vector2 start, Func<Vector2> end, float time)
    {
        return CreateLerpedSkeleton(CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/Projectiles/General_Projectile_VFX.spine"), start, "FireBall/FireBall1_Loop", time), start, end);
    }
    
    public VFXInstance CreateVoidProjectile(Vector2 start, Func<Vector2> end, float time)
    {
        return CreateLerpedSkeleton(CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/Gojo/GOJO132_gojo_assets.spine"), start, "gojo132/void_projectile_loop", time), start, end);
    }
    
    [ClientRpc]
    public VFXInstance CreateVoidProjectileBurst(Vector2 pos)
    {
        return CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/Gojo/GOJO132_gojo_assets.spine"), pos, "gojo132/void_projectile_burst", 0.2f);
    }
    
    [ClientRpc]
    public VFXInstance CreateOblivionExplosion(Vector2 pos)
    {
        return CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/HitEffects/hit_effect.spine"), pos, "Oblivion_Explosion", 1.9f);
    }
    
    [ClientRpc]
    public VFXInstance CreateFireball1Explosion(Vector2 pos)
    {
        return CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/Projectiles/General_Projectile_VFX.spine"), pos, "FireBall/FireBall1_Exploded", 0.833f);
    }
    
    [ClientRpc]
    public VFXInstance CreateClawSlash(Vector2 pos)
    {
        return CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/HitEffects/hit_effect.spine"), pos, "Claw_Slash", 0.4f);
    }

    [ClientRpc]
    public VFXInstance CreateCritEffect(Vector2 pos)
    {
        return CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/HitEffects/hit_effect.spine"), pos, "Hit_1_crit", 0.417f);
    }

    [ClientRpc]
    public VFXInstance CreateShieldAura(Vector2 pos)
    {
        return CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/ChargeAuraBlue/charge_aura.spine"), pos, "charge_Aura_loop_AL", 1000f); 
    }
    
    [ClientRpc]
    public VFXInstance CreateSuperSaiyanAura(Vector2 pos)
    {
        return CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/ChargeAuraRed/charge_aura_red.spine"), pos, "charge_Aura_loop_AL", 1000f); 
    }

    [ClientRpc]
    public VFXInstance CreateSpikeShield(Vector2 pos)
    {
        return CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/Shields/BAT003_shields.spine"), pos, "spike_shield/spike_shield_idle", 1000f);
    }

    [ClientRpc]
    public VFXInstance CreateSmokePoof(Vector2 pos)
    {
        return CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/HitEffects/hit_effect.spine"), pos, "Small_Dust_Impact", 0.717f);
    }

    public VFXInstance CreateChest(Vector2 pos)
    {
        return CreateSkeletonSequence(Assets.GetAsset<SpineSkeletonAsset>("Animations/Crate/AO_crate_generic.spine"), pos, "appear", 1f, "lid_off/opens", 0.25f, "break", 1f);
    }

    [ClientRpc]
    public VFXInstance CreateDarknessSlam(Vector2 pos)
    {
        SFX.Play(Assets.GetAsset<AudioAsset>("SFX/darkness-slam.wav"), new SFX.PlaySoundDesc() { Positional = true, Position = pos });
        
        var instance = CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/DarknessSlam/012MIM_Darkness_Slam.spine"), pos, "Darkness_Shockwave", 4f);
        instance.Entity.Scale = Vector2.One * 1.5f;
        instance.Animator.DepthOffset = 0.1f;
        return instance;
    }
    
    public VFXInstance CreateTidalWave(Vector2 start, Func<Vector2> end, float time)
    {
        var instance = CreateLerpedSkeleton(CreateSkeletonSequence(Assets.GetAsset<SpineSkeletonAsset>("Animations/Wave/Wave2.spine"), start, "intro", 0.5f, "loop", time - 1.167f - 0.5f, "crash", 1.167f), start, end);
        instance.OnPositionUpdated += (pos, target) =>
        {
            var localTarget = instance.Animator.Entity.WorldToLocalPoint(target);
            
            var right = localTarget.X > 0f;
            instance.Animator.SpineInstance.Scale = new Vector2(right ? 1f : -1, 1);
            
            localTarget.X *= right ? 1 : -1;

            instance.Animator.SpineInstance.SetBonePosition("AIM", localTarget);
        };
        return instance;
    }
    
    public VFXInstance CreateFireTornado(Vector2 start, Func<Vector2> end, float time)
    {
        var instance = CreateSkeletonSequence(Assets.GetAsset<SpineSkeletonAsset>("Animations/FireTornado/tornado.spine"), start, "spin_intro", 1f, "spin_loop", time - 1f - 1.317f, "spin_outro", 1.317f);
        instance.Animator.SpineInstance.SetSkin("flame");
        instance.Animator.SpineInstance.RefreshSkins();
        return CreateLerpedSkeleton(instance, start, end);
    }

    [ClientRpc]
    public VFXInstance CreateInkPuddle(Vector2 pos)
    {
        var instance = CreateSkeletonSequence(Assets.GetAsset<SpineSkeletonAsset>("Animations/Oil/Oil.spine"), pos, "appear", 0.433f, "idle", 1000f, "despawn", 0.233f);
        instance.Entity.Scale = Vector2.One * 3f;
        instance.Animator.DepthOffset = 10;
        return instance;
    }

    public VFXInstance CreateInkProjectile(Vector2 start, Func<Vector2> end, float time)
    {
        var instance = CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/Projectiles/General_Projectile_VFX.spine"), start, "Wind_Punch/Wind_Punch_Loop", time);
        instance.Animator.Tint = new Vector4(0.2f, 0.2f, 0.2f, 1f);
        
        return CreateLerpedSkeleton(instance, start, end);
    }

    [ClientRpc]
    public VFXInstance CreateInkSplash(Vector2 pos)
    {
        var instance = CreateSkeleton(Assets.GetAsset<SpineSkeletonAsset>("Animations/HitEffects/hit_effect.spine"), pos, "Acid/Acid_Circular", 0.283f);
        instance.Animator.Tint = new Vector4(0.1f, 0.1f, 0.1f, 1f);
        
        return instance;
    }

    [ClientRpc]
    public VFXInstance CreateVineSwarm(Vector2 pos)
    {
        return CreateSkeletonSequence(Assets.GetAsset<SpineSkeletonAsset>("Animations/Vines/Vines.spine"), pos, "intro", 1.1f, "loop", 1000f, "outro", 1f); 
    }

    [ClientRpc]
    public VFXInstance CreateShadowVortex(Vector2 pos)
    {
        return CreateSkeletonSequence(Assets.GetAsset<SpineSkeletonAsset>("Animations/PoolOfDarkness/004RAND_pool_of_darkness.spine"), pos, "Appear", 2f, "Idle", 1000f, "Disappear", 2f); 
    }
}