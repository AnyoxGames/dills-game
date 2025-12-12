using AO;

namespace Assembly.scripts;

public class GameItems
{
    public static GameItems Instance;
    
    public static void Init()
    {
        if (Instance != null) throw new Exception("GameItems has already been initialized");
        _ = new GameItems();
    }
    
    private struct Anyox_ItemDefinition
    {
        public Item_Definition Definition;

        public Anyox_ItemDefinition AssignEquipmentSlot(EquipmentSlotType slot)
        {
            Instance.EquipmentSlotTable.Add(Definition, slot);
            return this;
        }

        public Anyox_ItemDefinition AssignDefaultRarity(ItemRarity rarity) => AssignDefaultRarity((MyItemRarity)rarity);
        public Anyox_ItemDefinition AssignDefaultRarity(MyItemRarity rarity)
        {
            Instance.DefaultRarityTable.Add(Definition, rarity);
            return this;
        }
        
        public Anyox_ItemDefinition AssignEdibleData(EdibleItemData data)
        {
            Instance.EdibleTable.Add(Definition, data);
            return this;
        }
        
        public Anyox_ItemDefinition AssignHoldableClass(HoldableItem holdableItem)
        {
            Instance.HoldableTable.Add(Definition, holdableItem);
            return this;
        }
        
        public Anyox_ItemDefinition AssignDropWarningLevel(DropWarningLevel dropLevel)
        {
            Instance.DropWarningLevelTable.Add(Definition, dropLevel);
            return this;
        }
        
        public Anyox_ItemDefinition AssignSkinId(string skinId)
        {
            Instance.SkinIdTable.Add(Definition, skinId);
            return this;
        }
        
        public static implicit operator Item_Definition(Anyox_ItemDefinition definition) => definition.Definition;
    }

    #region Members
    
    //Ores
    public Item_Definition IronOre;
    public Item_Definition CoalOre;
    public Item_Definition MithrilOre;
    public Item_Definition BarsateOre;
    public Item_Definition RunicOre;
    
    //Logs
    public Item_Definition PineLogs;
    public Item_Definition OakLogs;
    public Item_Definition MapleLogs;
    public Item_Definition MahoganyLogs;
    public Item_Definition YewLogs;
    
    //Ingots
    public Item_Definition IronIngot;
    public Item_Definition SteelIngot;
    public Item_Definition MithrilIngot;
    public Item_Definition BarsateIngot;
    public Item_Definition RunicIngot;
    
    //Swords
    public Item_Definition IronSword;
    public Item_Definition SteelSword;
    public Item_Definition MithrilSword;
    public Item_Definition BarsateSword;
    public Item_Definition RunicSword;
    
    //Helmets
    public Item_Definition IronHelmet;
    public Item_Definition SteelHelmet;
    public Item_Definition MithrilHelmet;
    public Item_Definition BarsateHelmet;
    public Item_Definition RunicHelmet;
    
    //Armor
    public Item_Definition IronArmor;
    public Item_Definition SteelArmor;
    public Item_Definition MithrilArmor;
    public Item_Definition BarsateArmor;
    public Item_Definition RunicArmor;
    
    //Mixology Ingredients
    public Item_Definition AshPile;
    
    //Food
    public Item_Definition TroutRaw;
    public Item_Definition TroutCooked;
    public Item_Definition ChickenRaw;
    public Item_Definition ChickenCooked;
    
    //Misc
    public Item_Definition Feather;
    
    #endregion

    public List<Item_Definition> AllItems = new();
    
    private Dictionary<Item_Definition, EquipmentSlotType> EquipmentSlotTable = new();
    private Dictionary<Item_Definition, MyItemRarity> DefaultRarityTable = new();
    private Dictionary<Item_Definition, DropWarningLevel> DropWarningLevelTable = new();
    private Dictionary<Item_Definition, string> SkinIdTable = new();
    private Dictionary<Item_Definition, HoldableItem> HoldableTable = new();
    private Dictionary<Item_Definition, EdibleItemData> EdibleTable = new();
    
    private GameItems()
    {
        Instance = this;
        
        IronOre =    CreateItem("Sprites/IronOre.png",    "iron_ore",    "Iron Ore",    100).AssignDefaultRarity(MyItemRarity.Common);
        CoalOre =    CreateItem("Sprites/CoalOre.png",    "coal_ore",    "Coal Ore",    100).AssignDefaultRarity(ItemRarity.Common);
        MithrilOre = CreateItem("Sprites/MithrilOre.png", "mithril_ore", "Mithril Ore", 100).AssignDefaultRarity(ItemRarity.Uncommon);
        BarsateOre = CreateItem("Sprites/BarsateOre.png", "barsate_ore", "Barsate Ore", 100).AssignDefaultRarity(ItemRarity.Uncommon);
        RunicOre =   CreateItem("Sprites/RunicOre.png",   "runic_ore",   "Runic Ore",   100).AssignDefaultRarity(ItemRarity.Rare);
                                                                                                                                                                                    //TODO Reuse this
        PineLogs =     CreateItem("Sprites/PineLog.png", "pine_log",     "Pine Log",     100).AssignDefaultRarity(ItemRarity.Common).AssignHoldableClass(new LogHoldable());
        OakLogs =      CreateItem("Sprites/PineLog.png", "oak_log",      "Oak Log",      100).AssignDefaultRarity(ItemRarity.Common).AssignHoldableClass(new LogHoldable());
        MapleLogs =    CreateItem("Sprites/PineLog.png", "maple_log",    "Maple Log",    100).AssignDefaultRarity(ItemRarity.Uncommon).AssignHoldableClass(new LogHoldable());
        MahoganyLogs = CreateItem("Sprites/PineLog.png", "mahogany_log", "Mahogany Log", 100).AssignDefaultRarity(ItemRarity.Uncommon).AssignHoldableClass(new LogHoldable());
        YewLogs =      CreateItem("Sprites/PineLog.png", "yew_log",      "Yew Log",      100).AssignDefaultRarity(ItemRarity.Rare).AssignHoldableClass(new LogHoldable());
        
        IronIngot =    CreateItem("Sprites/IronIngot.png",    "iron_ingot",    "Iron Ingot",    100).AssignDefaultRarity(ItemRarity.Common);
        SteelIngot =   CreateItem("Sprites/SteelIngot.png",   "steel_ingot",   "Steel Ingot",   100).AssignDefaultRarity(ItemRarity.Common);
        MithrilIngot = CreateItem("Sprites/MithrilIngot.png", "mithril_ingot", "Mithril Ingot", 100).AssignDefaultRarity(ItemRarity.Uncommon);
        BarsateIngot = CreateItem("Sprites/BarsateIngot.png", "barsate_ingot", "Barsate Ingot", 100).AssignDefaultRarity(ItemRarity.Uncommon);
        RunicIngot =   CreateItem("Sprites/RunicIngot.png",   "runic_ingo",    "Runic Ingot",   100).AssignDefaultRarity(ItemRarity.Rare);
        
        IronSword =    CreateItem("Sprites/IronSword.png", "iron_sword",     "Iron Sword",    1).AssignDefaultRarity(ItemRarity.Common).AssignHoldableClass(new IronSwordHoldable()).AssignSkinId("008BED/weapons/wood_sword");
        SteelSword =   CreateItem("Sprites/SteelSword.png", "steel_sword",   "Steel Sword",   1).AssignDefaultRarity(ItemRarity.Common).AssignHoldableClass(new SteelSwordHoldable()).AssignSkinId("008BED/weapons/iron_sword");
        MithrilSword = CreateItem("Sprites/MithrilSword.png", "mithril_sword", "Mithril Sword", 1).AssignDefaultRarity(ItemRarity.Uncommon).AssignHoldableClass(new MithrilSwordHoldable()).AssignSkinId("008BED/weapons/iron_sword");
        BarsateSword = CreateItem("Sprites/BarsateSword.png", "barsate_sword", "Barsate Sword", 1).AssignDefaultRarity(ItemRarity.Uncommon).AssignHoldableClass(new BarsateSwordHoldable()).AssignSkinId("008BED/weapons/iron_sword");
        RunicSword =   CreateItem("Sprites/RunicSword.png", "runic_sword",   "Runic Sword",   1).AssignDefaultRarity(ItemRarity.Rare).AssignHoldableClass(new RunicSwordHoldable()).AssignSkinId("008BED/weapons/iron_sword");
        
        IronHelmet =    CreateItem("Sprites/IronArmor.png", "iron_helmet",    "Iron Helmet",    1).AssignDefaultRarity(ItemRarity.Common).AssignEquipmentSlot(EquipmentSlotType.Helmet).AssignSkinId("hat/leather_armor_helmet");
        SteelHelmet =   CreateItem("Sprites/IronArmor.png", "steel_helmet",   "Steel Helmet",   1).AssignDefaultRarity(ItemRarity.Common).AssignEquipmentSlot(EquipmentSlotType.Helmet).AssignSkinId("hat/iron_armor_helmet");
        MithrilHelmet = CreateItem("Sprites/IronArmor.png", "mithril_helmet", "Mithril Helmet", 1).AssignDefaultRarity(ItemRarity.Uncommon).AssignDropWarningLevel(DropWarningLevel.Warn).AssignEquipmentSlot(EquipmentSlotType.Helmet).AssignSkinId("hat/iron_armor_helmet");
        BarsateHelmet = CreateItem("Sprites/IronArmor.png", "barsate_helmet", "Barsate Helmet", 1).AssignDefaultRarity(ItemRarity.Uncommon).AssignDropWarningLevel(DropWarningLevel.Warn).AssignEquipmentSlot(EquipmentSlotType.Helmet).AssignSkinId("hat/iron_armor_helmet");
        RunicHelmet =   CreateItem("Sprites/IronArmor.png", "runic_helmet",   "Runic Helmet",   1).AssignDefaultRarity(ItemRarity.Rare).AssignDropWarningLevel(DropWarningLevel.Warn).AssignEquipmentSlot(EquipmentSlotType.Helmet).AssignSkinId("hat/iron_armor_helmet");

        IronArmor =    CreateItem("Sprites/IronArmor.png", "iron_armor",    "Iron Chestplate",    1).AssignDefaultRarity(ItemRarity.Common).AssignEquipmentSlot(EquipmentSlotType.Armour).AssignSkinId("body/leather_armor_body");
        SteelArmor =   CreateItem("Sprites/IronArmor.png", "steel_armor",   "Steel Chestplate",   1).AssignDefaultRarity(ItemRarity.Common).AssignEquipmentSlot(EquipmentSlotType.Armour).AssignSkinId("body/iron_armor_chest");
        MithrilArmor = CreateItem("Sprites/IronArmor.png", "mithril_armor", "Mithril Chestplate", 1).AssignDefaultRarity(ItemRarity.Uncommon).AssignDropWarningLevel(DropWarningLevel.Warn).AssignEquipmentSlot(EquipmentSlotType.Armour).AssignSkinId("body/iron_armor_chest");
        BarsateArmor = CreateItem("Sprites/IronArmor.png", "barsate_armor", "Barsate Chestplate", 1).AssignDefaultRarity(ItemRarity.Uncommon).AssignDropWarningLevel(DropWarningLevel.Warn).AssignEquipmentSlot(EquipmentSlotType.Armour).AssignSkinId("body/iron_armor_chest");
        RunicArmor =   CreateItem("Sprites/IronArmor.png", "runic_armor",   "Runic Chestplate",   1).AssignDefaultRarity(ItemRarity.Rare).AssignDropWarningLevel(DropWarningLevel.Warn).AssignEquipmentSlot(EquipmentSlotType.Armour).AssignSkinId("body/iron_armor_chest");
        
        AshPile =   CreateItem("Sprites/AshPile.png", "ashes", "Ashes",     100).AssignDefaultRarity(ItemRarity.Common);
        Feather =   CreateItem("Sprites/Feather.png", "feather", "Feather",     999).AssignDefaultRarity(ItemRarity.Common);
        
        TroutRaw =    CreateItem("Sprites/TroutRaw.png",    "trout_raw",    "Raw Trout", 100).AssignDefaultRarity(ItemRarity.Common);
        TroutCooked = CreateItem("Sprites/TroutCooked.png", "trout_cooked", "Trout",     100).AssignDefaultRarity(ItemRarity.Common).AssignEdibleData(new EdibleItemData(6));

        ChickenRaw = CreateItem("Sprites/RawChicken.png", "chicken_raw", "Raw Chicken", 100).AssignDefaultRarity(ItemRarity.Common);
        ChickenCooked = CreateItem("Sprites/Chicken.png", "chicken_cooked", "Chicken",     100).AssignDefaultRarity(ItemRarity.Common).AssignEdibleData(new EdibleItemData(4));

        Anyox_ItemDefinition CreateItem(string icon, string id, string name, int stackSize)
        {
            var item = Item_Definition.Create(new ItemDescription { Icon = icon, Id = id, Name = name, StackSize = stackSize });
            AllItems.Add(item);
            return new Anyox_ItemDefinition() { Definition = item };
        }
    }
    
    public Entity SpawnLootInstance(Item_Definition itemDef, Vector2 dropStartingPoint, bool doLobAnimation, int? amountOverride = null, bool requireNavmesh = true, Player lockedOwner = null)
    {
        return Network.InstantiateAndSpawn(References.Instance.ItemPickupPrefab, entity =>
        {
            var dropDestination = (doLobAnimation) ? dropStartingPoint + Util.RandomPositionOnUnitCircle(ref GameManager.Instance.GlobalRng) * Random.Shared.NextFloat(1.5f, 3f) : dropStartingPoint;
            Navmesh.TryFindClosestPointOnAnyNavmesh(dropDestination, out dropDestination, out _);

            var pickup = entity.GetComponent<ItemPickup>();
            pickup.CallClient_Setup(itemDef.Id);

            if (amountOverride.HasValue)
            {
                pickup.CallClient_SetAmountOverride(amountOverride.Value);
            }

            if (lockedOwner != null)
            {
                pickup.CallClient_SetLockedOwner(lockedOwner);
            }

            if (doLobAnimation)
            {
                pickup.CallClient_LerpItem(dropStartingPoint, dropDestination, 0.35f, ItemPickup.LerpType.Lob);
            }
            else
            {
                pickup.CallClient_MoveToPosition(dropDestination);
            }
        });
    }

    public DropWarningLevel GetDropWarningLevelForItemDefinition(Item_Definition itemDef) => DropWarningLevelTable.GetValueOrDefault(itemDef, DropWarningLevel.None);
    public MyItemRarity GetDefaultRarityForItemDefinition(Item_Definition itemDef) => DefaultRarityTable.GetValueOrDefault(itemDef, MyItemRarity.Common);
    public EquipmentSlotType GetEquipmentSlotForItemDefinition(Item_Definition itemDef) => EquipmentSlotTable.GetValueOrDefault(itemDef, EquipmentSlotType.None);
    public string GetSkinIdForItemDefinition(Item_Definition itemDef) => SkinIdTable.GetValueOrDefault(itemDef, null);
    public HoldableItem GetHoldableForItemDefinition(Item_Definition itemDef) => HoldableTable.GetValueOrDefault(itemDef, null);
    public bool TryGetEdibleItemData(Item_Definition itemDef, out EdibleItemData edibleItemData) => EdibleTable.TryGetValue(itemDef, out edibleItemData);
    
    public bool TryGetItemDefinitionFromId(string id, out Item_Definition itemDef)
    {
        itemDef = null;
        
        foreach (var i in AllItems)
        {
            if (i.Id == id)
            {
                itemDef = i;
                return true;
            }
        }
        
        return false;
    }
}

public enum EquipmentSlotType
{
    None,
    Helmet,
    Armour,
    Aura,
}

public enum DropWarningLevel
{
    None,
    Warn,
    CannotDrop,
}

public struct EdibleItemData(int healAmt = 0, int damageAmt = 0)
{
    public int HealAmt => healAmt;
    public int DamageAmt => damageAmt;

    public void ServerConsume(MyPlayer target)
    {
        int healthDiff = HealAmt - DamageAmt;
        
        if (healthDiff > 0)
        {
            target.ServerHeal(healthDiff, target.Entity);
        }
        else if (healthDiff < 0)
        {
            target.ServerTakeDamage(Math.Abs(healthDiff), target.Entity);
        }
    }
}

public abstract class HoldableItem
{
    public const string META_ATTACK_RANGE = "attack_range";
    public const string META_ATTACK_WIDTH = "attack_width";
    public const string META_ATTACK_ANIM_TRIGGER = "anim_trigger";
    public const string META_ATTACK_SOUND = "attack_sound";
    public const string META_BASE_DAMAGE = "base_damage";
    
    public List<Type> ItemAbilities = new();

    public virtual string AbilitySprite => null;
    public virtual float AbilityCooldown => 1f;
    protected virtual Dictionary<string, object> Metadata => null;

    protected HoldableItem() => Init();
    
    private void Init()
    {
        CollectAbilities(ref ItemAbilities);
    }
    
    protected abstract void CollectAbilities(ref List<Type> list);

    public bool GetMetadataValue<T>(string key, out T value, T defaultValue = default)
    {
        value = defaultValue;
        
        if (Metadata == null || ! Metadata.ContainsKey(key))
            return false;

        value = (T)Metadata[key];
        return true;
    }
}