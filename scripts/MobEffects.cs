using AO;

namespace Assembly.scripts;

public abstract class MobEffect : Component
{
    public abstract string EffectTag { get; }
    public virtual Vector4 EffectTagColour { get; } = Vector4.White;

    public virtual bool IsValidTarget { get; } = true;
    public virtual bool AllowBehaviourToRun { get; } = true;
    public virtual float? HardcodedDuration { get; } = null;
    public virtual float SpeedMultiplier { get; } = 1.0f;

    public bool AlreadyEnding { get; set; }

    public virtual bool FreezeNpc { get; } = false;

    public float DurationRemaining { get; private set; }
    public float DurationElapsed { get; private set; }
    public virtual string SoundAsset => null;

    public float DurationProgress01 => HardcodedDuration.HasValue ? 1 - (DurationRemaining / HardcodedDuration.Value) : 0;

    public virtual Prefab EffectVisualsPrefab { get; } = null;
    public virtual Entity EffectVisualsAnchor { get; } = null;
    public virtual Vector2 EffectVisualsLocalOffset => Vector2.Zero;
    protected Entity SpawnedEffectVisuals;
    
    public Mob Mob;
    public T GetMob<T>() where T : Mob => (T)Mob;

    public MyPlayer Caster;
    
    private ulong SoundId;

    public void RequestStart()
    {
        AlreadyEnding = false;
        DurationRemaining = HardcodedDuration ?? float.MaxValue;
        DurationElapsed = 0;

        if (FreezeNpc)
        {
            Mob.AddFreezeReason(GetType().Name + "_" + Entity.Id.ToString());
        }
        
        OnEffectStart();
    }

    public void RequestEnd(bool interrupt)
    {
        if (FreezeNpc)
        {
            Mob.RemoveFreezeReason(GetType().Name + "_" + Entity.Id.ToString());
        }
        
        OnEffectEnd(interrupt);
    }
    
    public override void Update()
    {
        base.Update();

        if (AlreadyEnding)
        {
            return;
        }

        if (!Mob.CanHit())
        {
            Mob.RemoveEffect(this, false);
            return;
        }
        
        DurationElapsed += Time.DeltaTime;
        OnEffectUpdate();
        
        if (DurationRemaining <= 0)
        {
            return;
        }
        
        if (HardcodedDuration.HasValue)
        {
            DurationRemaining -= Time.DeltaTime;
            if (DurationRemaining <= 0)
            {
                Mob.RemoveEffect(this, false);
            }
        }
    }

    public virtual void Refresh()
    {
        if (HardcodedDuration.HasValue)
        {
            DurationRemaining = HardcodedDuration.Value;
        }
    }

    public virtual void OnEffectStart()
    {
        if (EffectVisualsPrefab != null)
        {
            var effectVisualParent = EffectVisualsAnchor != null ? EffectVisualsAnchor : Mob.Entity;

            SpawnedEffectVisuals = Entity.Instantiate(EffectVisualsPrefab);
            SpawnedEffectVisuals.SetParent(effectVisualParent, false);
            SpawnedEffectVisuals.LocalPosition = EffectVisualsLocalOffset;
        }

        if (SoundAsset != null)
        {
            SoundId = SFX.Play(Assets.GetAsset<AudioAsset>(SoundAsset), new SFX.PlaySoundDesc() { EntityToFollow = Mob.Entity });
        }
    }

    public virtual void OnEffectUpdate() { }

    public virtual void OnEffectEnd(bool interrupt)
    {
        if (SpawnedEffectVisuals.Alive() && SpawnedEffectVisuals != null)
        {
            SpawnedEffectVisuals.Destroy();
        }
        
        if (SoundId != 0)
        {
            SFX.Stop(SoundId);
        }
    }

    public virtual Rect GetEffectTagRect(Rect tagRect)
    {
        tagRect = tagRect.TopRect().Grow(40, 0, 0, 0);

        string durationText = HardcodedDuration.HasValue ? $" : {(int)Math.Ceiling(DurationRemaining)}s" : "";
        UI.TextAsync(tagRect, $"{EffectTag}{durationText}", MyUI.GetTextSettings(40, EffectTagColour));

        return tagRect;
    }
}