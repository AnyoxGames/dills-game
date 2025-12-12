using System.Drawing;
using AO;

namespace Assembly.scripts;

public enum SkillType
{
    Null,
    Combat,
    Magic,
    Harvesting,
    Crafting,
    Mixology
}

public abstract class Skill
{
    private const int XP_CAP = 1000000000;
    
    public abstract string Name { get; }
    public abstract string Icon { get; }
    public abstract SkillType Type { get; }
    public virtual Vector4 SkillColor => Vector4.White;
    public virtual int DefaultXP => 0;
    public virtual int LevelCap => 100;

    protected MyPlayer Player;
    protected SyncVar<int> CurrentXP = new();

    public float RotationValue;
    
    public float ProgressToNextLevel => CurrentLevel == LevelCap ? 1f : MathF.Min(MyUtil.GetNormalizedValue(CurrentXP, (float)MyUtil.GetXPForLevel(CurrentLevel), (float)MyUtil.GetXPForLevel(CurrentLevel + 1)), 1f);
    public int XP => CurrentXP;

    private string SaveID => $"XP_{Name}";

    public int CurrentLevel => Math.Min(LevelCap, MyUtil.GetLevelForXP(CurrentXP));

    protected Skill(MyPlayer player)
    {
        CurrentXP.OnSync += (oldVal, newVal) =>
        {
            var levelAtOldXP = MyUtil.GetLevelForXP(oldVal);
            var levelAtCurrentXP = MyUtil.GetLevelForXP(newVal);

            if (levelAtOldXP != levelAtCurrentXP)
            {
                RotationValue = 0;
            }
        };
        
        Player = player;
        ServerInit();
    }

    private void ServerInit()
    {
        if (!Network.IsServer)
            return;
         
        CurrentXP.Set(Math.Min(XP_CAP, Save.GetInt(Player, SaveID, DefaultXP)), true);
    }
    
    public void ServerSetXp(int xp)
    {
        if (!Network.IsServer)
            return;

        CurrentXP.Set(xp);
        Save.SetInt(Player, SaveID, xp);
    }
    
    public void ServerAwardXp(int xpAmount, Vector2? xpSource = null)
    {
        if (!Network.IsServer)
            return;

        Player.CallClient_SpawnXPDrop(Type, xpAmount, xpSource ?? Player.Position + Vector2.Up * 0.5f);

        var newXP = Math.Min(CurrentXP + xpAmount, XP_CAP);
        bool levelUp = MyUtil.GetXPForLevel(CurrentLevel + 1) <= newXP;
        CurrentXP.Set(newXP);
        Save.SetInt(Player, SaveID, newXP);

        if (levelUp)
        {
            Effect_LevelUp.CallClient_AddToPlayer(Player, Type);
        }
    }
}

public class Combat : Skill
{
    public Combat(MyPlayer player) : base(player) { }

    public override string Name => "Combat";
    public override string Icon => "Sprites/SkillIcons/Combat.png";
    public override SkillType Type => SkillType.Combat;
    public override Vector4 SkillColor => new(1f, 0.57f, 0f, 1f);

    public int MaxHealth => MyUtil.GetGlobalHealthForLevel(CurrentLevel);
}

public class Magic : Skill
{
    public Magic(MyPlayer player) : base(player) { }

    public override string Name => "Magic";
    public override string Icon => "Sprites/SkillIcons/Magic.png";
    public override SkillType Type => SkillType.Magic;
    public override Vector4 SkillColor => new(0, 0.16f, 1, 1f);
}

public class Harvesting : Skill
{
    public Harvesting(MyPlayer player) : base(player) { }

    public override string Name => "Harvesting";
    public override string Icon => "Sprites/SkillIcons/Harvesting.png";
    public override SkillType Type => SkillType.Harvesting;
    public override Vector4 SkillColor => new(0.29f, 0.91f, 0f, 1f);
}

public class Crafting : Skill
{
    public Crafting(MyPlayer player) : base(player) { }

    public override string Name => "Crafting";
    public override string Icon => "Sprites/SkillIcons/Artisan.png";
    public override SkillType Type => SkillType.Crafting;
    public override Vector4 SkillColor => new(0.75f, 0.43f, 0f, 1f);
}

public class Mixology : Skill
{
    public Mixology(MyPlayer player) : base(player) { }

    public override string Name => "Mixology";
    public override string Icon => "Sprites/SkillIcons/Mixology.png";
    public override SkillType Type => SkillType.Mixology;
    public override Vector4 SkillColor => new(0.471f, 0.286f, 0.91f, 1f);
}