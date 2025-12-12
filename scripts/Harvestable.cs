using AO;

namespace Assembly.scripts;

public abstract partial class Harvestable : Component
{
    [Serialized] public Interactable Interactable;
    [Serialized] public Sprite_Renderer DefaultRenderer;
    [Serialized] public Sprite_Renderer DepletedRenderer;
    
    public virtual float DepleteChance => 0.5f;
    public virtual float BaseHarvestChance => 0.4f;
    public virtual float BaseHarvestRate => 1f;
    public virtual float RespawnTime => 20f;
    public virtual int HarvestXP => 0;
    public virtual int ChipHarvestXP => 0;
    
    protected abstract string ChipSound { get; }
    protected abstract string HarvestSound { get; }
    
    public SyncVar<bool> IsDepleted = new(false);
    
    private List<(SkillType, int)> Requirements = new();
    private float RespawnTimer;
    
    public override void Awake()
    {
        IsDepleted.OnSync += (_, isDepleted) =>
        {
            if (DefaultRenderer.Alive())
                DefaultRenderer.Entity.LocalEnabled = !isDepleted;
            if (DepletedRenderer.Alive())
                DepletedRenderer.Entity.LocalEnabled = isDepleted;
            
            if (!isDepleted)
            {
                RespawnTimer = 0;
            }
        };

        Interactable.CanUseCallback += p => !IsDepleted.Value; 
        
        Interactable.OnInteract += p => 
        {
            if (!Network.IsServer)
                return;
        
            var player = (MyPlayer)p;

            if (!player.ServerCheckRequirements(Requirements, "harvest"))
            {
                return;
            }
        
            CallClient_OnHarvestStarted(player);
        };

        CollectRequirements(ref Requirements);
    }

    public override void Update()
    {
        if (Network.IsServer && IsDepleted.Value)
        {
            RespawnTimer += Time.DeltaTime;

            if (RespawnTimer >= RespawnTime)
            {
                IsDepleted.Set(false);
            }
        }
    }

    protected abstract void CollectRequirements(ref List<(SkillType, int)> list);

    [ClientRpc]
    public void OnHarvestStarted(MyPlayer player)
    {
        player.AddEffect<Effect_Harvesting>(preInit: e => e.Harvestable = this);
    }

    public virtual void ServerOnHarvest(MyPlayer player)
    {
        player.HarvestingSkill.ServerAwardXp(HarvestXP, Position);
        CallClient_Harvest(player);

        bool deplete = Random.Shared.NextFloat() < DepleteChance;
        
        Log.Info(deplete.ToString());
        if (deplete)
        {
            IsDepleted.Set(true);
        }
    }
    
    public virtual void ServerOnHarvestFail(MyPlayer player)
    {
        CallClient_OnHarvestFailed(player);
        player.HarvestingSkill.ServerAwardXp(ChipHarvestXP, Position);
    }

    [ClientRpc]
    public void OnHarvestFailed(MyPlayer player)
    {
        player.SpineAnimator.SpineInstance.StateMachine.SetTrigger("swing_tool");
        
        if (player.IsLocal)
        {
            SFX.Play(Assets.GetAsset<AudioAsset>(ChipSound), new SFX.PlaySoundDesc() { Positional = false, Volume = 0.25f, Speed = Random.Shared.NextFloat(0.7f, 1.3f) });
        }
    }
    
    [ClientRpc]
    public void Harvest(MyPlayer player)
    {
        player.SpineAnimator.SpineInstance.StateMachine.SetTrigger("swing_tool");
        
        if (player.IsLocal)
        {
            SFX.Play(Assets.GetAsset<AudioAsset>(HarvestSound), new SFX.PlaySoundDesc() { Positional = false, Volume = 0.25f, Speed = Random.Shared.NextFloat(0.7f, 1.3f) });
        }

        OnHarvested(player);
    }

    protected abstract void OnHarvested(MyPlayer player);
}

#region Ores

public class IronOre : Harvestable
{
    public override int HarvestXP => 10;
    public override int ChipHarvestXP => 2;
    protected override string ChipSound => "SFX/mine-chip.wav";
    protected override string HarvestSound => "SFX/mine-harvest.wav";

    protected override void CollectRequirements(ref List<(SkillType, int)> requirements)
    {
        requirements.Add((SkillType.Harvesting, 1));
    }

    protected override void OnHarvested(MyPlayer player)
    {
        if (Network.IsServer)
        {
            player.ServerTryAddItem(GameItems.Instance.IronOre);
        }
    }
}

public class CoalOre : Harvestable
{
    public override int HarvestXP => 15;
    public override int ChipHarvestXP => 3;
    protected override string ChipSound => "SFX/mine-chip.wav";
    protected override string HarvestSound => "SFX/mine-harvest.wav";

    protected override void CollectRequirements(ref List<(SkillType, int)> requirements)
    {
        requirements.Add((SkillType.Harvesting, 15));
    }

    protected override void OnHarvested(MyPlayer player)
    {
        if (Network.IsServer)
        {
            player.ServerTryAddItem(GameItems.Instance.CoalOre);
        }
    }
}

public class MithrilOre : Harvestable
{
    public override int HarvestXP => 25;
    public override int ChipHarvestXP => 5;
    protected override string ChipSound => "SFX/mine-chip.wav";
    protected override string HarvestSound => "SFX/mine-harvest.wav";

    protected override void CollectRequirements(ref List<(SkillType, int)> requirements)
    {
        requirements.Add((SkillType.Harvesting, 20));
    }

    protected override void OnHarvested(MyPlayer player)
    {
        if (Network.IsServer)
        {
            player.ServerTryAddItem(GameItems.Instance.MithrilOre);
        }
    }
}

public class BarsateOre : Harvestable
{
    public override int HarvestXP => 40;
    public override int ChipHarvestXP => 7;
    protected override string ChipSound => "SFX/mine-chip.wav";
    protected override string HarvestSound => "SFX/mine-harvest.wav";

    protected override void CollectRequirements(ref List<(SkillType, int)> requirements)
    {
        requirements.Add((SkillType.Harvesting, 35));
    }

    protected override void OnHarvested(MyPlayer player)
    {
        if (Network.IsServer)
        {
            player.ServerTryAddItem(GameItems.Instance.BarsateOre);
        }
    }
}

public class RunicOre : Harvestable
{
    public override int HarvestXP => 65;
    public override int ChipHarvestXP => 10;
    protected override string ChipSound => "SFX/mine-chip.wav";
    protected override string HarvestSound => "SFX/mine-harvest.wav";

    protected override void CollectRequirements(ref List<(SkillType, int)> requirements)
    {
        requirements.Add((SkillType.Harvesting, 50));
    }

    protected override void OnHarvested(MyPlayer player)
    {
        if (Network.IsServer)
        {
            player.ServerTryAddItem(GameItems.Instance.RunicOre);
        }
    }
}

#endregion

#region Trees

public class PineTree : Harvestable
{
    public override int HarvestXP => 10;
    public override int ChipHarvestXP => 2;
    protected override string ChipSound => "SFX/tree-chip.wav";
    protected override string HarvestSound => "SFX/tree-harvest.wav";

    protected override void CollectRequirements(ref List<(SkillType, int)> requirements)
    {
        requirements.Add((SkillType.Harvesting, 1));
    }

    protected override void OnHarvested(MyPlayer player)
    {
        if (Network.IsServer)
        {
            player.ServerTryAddItem(GameItems.Instance.PineLogs);
        }
    }
}

public class OakTree : Harvestable
{
    public override int HarvestXP => 15;
    public override int ChipHarvestXP => 3;
    protected override string ChipSound => "SFX/tree-chip.wav";
    protected override string HarvestSound => "SFX/tree-harvest.wav";

    protected override void CollectRequirements(ref List<(SkillType, int)> requirements)
    {
        requirements.Add((SkillType.Harvesting, 10));
    }

    protected override void OnHarvested(MyPlayer player)
    {
        if (Network.IsServer)
        {
            player.ServerTryAddItem(GameItems.Instance.OakLogs);
        }
    }
}

public class MapleTree : Harvestable
{
    public override int HarvestXP => 25;
    public override int ChipHarvestXP => 5;
    protected override string ChipSound => "SFX/tree-chip.wav";
    protected override string HarvestSound => "SFX/tree-harvest.wav";

    protected override void CollectRequirements(ref List<(SkillType, int)> requirements)
    {
        requirements.Add((SkillType.Harvesting, 20));
    }

    protected override void OnHarvested(MyPlayer player)
    {
        if (Network.IsServer)
        {
            player.ServerTryAddItem(GameItems.Instance.MapleLogs);
        }
    }
}

public class MahoganyTree : Harvestable
{
    public override int HarvestXP => 40;
    public override int ChipHarvestXP => 7;
    protected override string ChipSound => "SFX/tree-chip.wav";
    protected override string HarvestSound => "SFX/tree-harvest.wav";

    protected override void CollectRequirements(ref List<(SkillType, int)> requirements)
    {
        requirements.Add((SkillType.Harvesting, 35));
    }

    protected override void OnHarvested(MyPlayer player)
    {
        if (Network.IsServer)
        {
            player.ServerTryAddItem(GameItems.Instance.MahoganyLogs);
        }
    }
}

public class YewTree : Harvestable
{
    public override int HarvestXP => 65;
    public override int ChipHarvestXP => 10;
    protected override string ChipSound => "SFX/tree-chip.wav";
    protected override string HarvestSound => "SFX/tree-harvest.wav";

    protected override void CollectRequirements(ref List<(SkillType, int)> requirements)
    {
        requirements.Add((SkillType.Harvesting, 50));
    }

    protected override void OnHarvested(MyPlayer player)
    {
        if (Network.IsServer)
        {
            player.ServerTryAddItem(GameItems.Instance.YewLogs);
        }
    }
}

#endregion