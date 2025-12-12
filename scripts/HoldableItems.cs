using System.Xml;
using AO;

namespace Assembly.scripts;

public class LogHoldable : HoldableItem
{
    protected override void CollectAbilities(ref List<Type> list)
    {
        list.Add(typeof(Ability_LightFire));
    }

    class Ability_LightFire : MyAbility
    {
        public override Type Effect => typeof(Effect_LightFire);
        public override Texture Icon => Assets.GetAsset<Texture>("Sprites/AbilityIcons/LightFire.png");
        public override TargettingMode TargettingMode => TargettingMode.Self;
    }
    
    class Effect_LightFire : MyEffect
    {
        public override bool IsActiveEffect => false;

        public override void OnEffectStart(bool isDropIn)
        {
            if (Network.IsServer)
            {
                Network.InstantiateAndSpawn(Assets.GetAsset<Prefab>("Fire.prefab"), e => e.Position = Player.Entity.Position);
                Player.CraftingSkill.ServerAwardXp(25, Player.Entity.Position);

                if (Player.CurrentHeldItem != null)
                {
                    Player.ServerConsumeItemWithCount(Player.CurrentHeldItem.Definition);
                }
            }
        }
    }
}

public class IronSwordHoldable : HoldableItem
{
    public override string AbilitySprite => "Sprites/IronSword.png";
    public override float AbilityCooldown => 0.5f;
    protected override Dictionary<string, object> Metadata => new()
    {
        {META_ATTACK_RANGE, 2f}, 
        {META_ATTACK_WIDTH, 2f}, 
        {META_BASE_DAMAGE, 5}, 
        {META_ATTACK_ANIM_TRIGGER, "sword_attack"},
        {META_ATTACK_SOUND, "SFX/sword.wav"}
    };

    protected override void CollectAbilities(ref List<Type> list)
    {
        list.Add(typeof(Ability_Attack));
    }
}

public class SteelSwordHoldable : HoldableItem
{
    public override string AbilitySprite => "Sprites/SteelSword.png";
    public override float AbilityCooldown => 0.5f;
    protected override Dictionary<string, object> Metadata => new()
    {
        {META_ATTACK_RANGE, 1f}, 
        {META_ATTACK_WIDTH, 2f}, 
        {META_BASE_DAMAGE, 11}, 
        {META_ATTACK_ANIM_TRIGGER, "sword_attack"},
        {META_ATTACK_SOUND, "SFX/sword.wav"}
    };
    
    protected override void CollectAbilities(ref List<Type> list)
    {
        list.Add(typeof(Ability_Attack));
    }
}

public class MithrilSwordHoldable : HoldableItem
{
    public override string AbilitySprite => "Sprites/MithrilSword.png";
    public override float AbilityCooldown => 0.5f;
    protected override Dictionary<string, object> Metadata => new()
    {
        {META_ATTACK_RANGE, 1f}, 
        {META_ATTACK_WIDTH, 2f}, 
        {META_BASE_DAMAGE, 16}, 
        {META_ATTACK_ANIM_TRIGGER, "sword_attack"},
        {META_ATTACK_SOUND, "SFX/sword.wav"}
    };
    
    protected override void CollectAbilities(ref List<Type> list)
    {
        list.Add(typeof(Ability_Attack));
    }
}

public class BarsateSwordHoldable : HoldableItem
{
    public override string AbilitySprite => "Sprites/BarsateSword.png";
    public override float AbilityCooldown => 0.5f;
    protected override Dictionary<string, object> Metadata => new()
    {
        {META_ATTACK_RANGE, 1f}, 
        {META_ATTACK_WIDTH, 2f}, 
        {META_BASE_DAMAGE, 20}, 
        {META_ATTACK_ANIM_TRIGGER, "sword_attack"},
        {META_ATTACK_SOUND, "SFX/sword.wav"}
    };
    
    protected override void CollectAbilities(ref List<Type> list)
    {
        list.Add(typeof(Ability_Attack));
    }
}

public class RunicSwordHoldable : HoldableItem
{
    public override string AbilitySprite => "Sprites/RunicSword.png";
    public override float AbilityCooldown => 0.5f;
    protected override Dictionary<string, object> Metadata => new()
    {
        {META_ATTACK_RANGE, 1f}, 
        {META_ATTACK_WIDTH, 2f}, 
        {META_BASE_DAMAGE, 23f}, 
        {META_ATTACK_ANIM_TRIGGER, "sword_attack"},
        {META_ATTACK_SOUND, "SFX/sword.wav"}
    };
    
    protected override void CollectAbilities(ref List<Type> list)
    {
        list.Add(typeof(Ability_Attack));
    }
}