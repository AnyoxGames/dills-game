using System.Collections;
using System.Numerics;
using System.Xml.Schema;
using AO;
using Assembly.scripts;
using Vector2 = AO.Vector2;
using Vector4 = AO.Vector4;

public partial class MyPlayer : Player
{
    public static string SAVE_ID_WORLD_POSITION = "world_pos";
    public static string SAVE_ID_CURRENT_HEALTH = "current_health";
    public static string SAVE_ID_EQUIPPED_HELMET = "current_helmet";
    public static string SAVE_ID_EQUIPPED_ARMOR = "current_armor";
    public static string SAVE_ID_EQUIPPED_AURA = "current_aura";
    
    public static MyPlayer LocalPlayer => (MyPlayer)Network.LocalPlayer;
    
    [NetSync] public int CurrentHealth;

    public Combat     CombatSkill;
    public Magic      MagicSkill;
    public Harvesting HarvestingSkill;
    public Crafting   CraftingSkill;
    public Mixology   MixologySkill;
    
    public CameraControl CameraControl;
    
    public Item_Instance CurrentHeldItem;
    public HoldableItem CurrentHoldableItem;

    public SyncVar<int> CurrentHeldSlot = new(0);
    public SyncVar<bool> Initialized = new(false);
    public SyncVar<string> HelmetId = new("");
    public SyncVar<string> ArmorId = new("");
    public SyncVar<string> AuraId = new("");
    
    public bool IsDead => HasEffect<Effect_Die>();

    public override void Awake()
    {
        CombatSkill     = new Combat(this);
        MagicSkill      = new Magic(this);
        HarvestingSkill = new Harvesting(this);
        CraftingSkill   = new Crafting(this);
        MixologySkill   = new Mixology(this);

        if (IsLocal)
        {
            CameraControl = CameraControl.Create(0);
        }

        CurrentHeldSlot.OnSync += (_, newSlot) =>
        {
            if (DefaultInventory == null)
                return;

            if (CurrentHeldItem != null)
            {
                var skinId = GameItems.Instance.GetSkinIdForItemDefinition(CurrentHeldItem.Definition);
                if (skinId != null)
                {
                    SpineAnimator.SpineInstance.DisableSkin(skinId);
                }
            }
            
            CurrentHeldItem = DefaultInventory.Items[newSlot];
            
            if (CurrentHeldItem != null)
            {
                CurrentHoldableItem = GameItems.Instance.GetHoldableForItemDefinition(CurrentHeldItem.Definition);
                
                var skinId = GameItems.Instance.GetSkinIdForItemDefinition(CurrentHeldItem.Definition);
                if (skinId != null)
                {
                    SpineAnimator.SpineInstance.EnableSkin(skinId);
                }
            }
            else
            {
                CurrentHoldableItem = null;
            }
            
            SpineAnimator.SpineInstance.RefreshSkins();
        };
        
        HelmetId.OnSync += (oldId, newId) => ProcessSlotUpdate(oldId, newId, "SFX/equip_helmet.wav", SAVE_ID_EQUIPPED_HELMET);
        ArmorId.OnSync += (oldId, newId) => ProcessSlotUpdate(oldId, newId, "SFX/equip_armor.wav", SAVE_ID_EQUIPPED_ARMOR);
        AuraId.OnSync += (oldId, newId) => ProcessSlotUpdate(oldId, newId, "SFX/equip_aura.wav", SAVE_ID_EQUIPPED_AURA);
        void ProcessSlotUpdate(string oldId, string newId, string equipSfx, string saveId)
        {
            if (Network.IsServer && Initialized)
            {
                Save.SetString(this, saveId, newId);                
            }
            else if (Initialized && LocalPlayer.Initialized)
            {
                SFX.Play(!newId.IsNullOrEmpty() ? Assets.GetAsset<AudioAsset>(equipSfx) : Assets.GetAsset<AudioAsset>("SFX/unequip.wav"), new SFX.PlaySoundDesc() { Positional = true, Position = Entity.Position, Volume = 0.75f });
            }

            if (newId.IsNullOrEmpty() && !oldId.IsNullOrEmpty())
            {
                if (GameItems.Instance.TryGetItemDefinitionFromId(oldId, out var itemDef))
                {
                    var skinId = GameItems.Instance.GetSkinIdForItemDefinition(itemDef);
                    if (!skinId.IsNullOrEmpty())
                    {
                        SpineAnimator.SpineInstance.DisableSkin(skinId);
                    }
                }
            }
            else if (!newId.IsNullOrEmpty())
            {
                if (GameItems.Instance.TryGetItemDefinitionFromId(newId, out var itemDef))
                {
                    var skinId = GameItems.Instance.GetSkinIdForItemDefinition(itemDef);
                    if (!skinId.IsNullOrEmpty())
                    {
                        SpineAnimator.SpineInstance.EnableSkin(skinId);
                    }
                }
            }
            
            SpineAnimator.SpineInstance.RefreshSkins();
        }
        
        //Setup Anims
        {
            var sm = SpineAnimator.SpineInstance.StateMachine;
            var baseLayer = sm.TryGetLayerByName("main"); 
            var idleState = baseLayer.TryGetStateByName("Idle");
            var runState = baseLayer.TryGetStateByName("Run_Fast");
            var useIk = sm.TryGetVariableByName("use_ik");
            var movingBool = sm.TryGetVariableByName("moving");
            
            baseLayer.CreateGlobalTransition(baseLayer.InitialState).CreateTriggerCondition(sm.CreateVariable("reset", StateMachineVariableKind.TRIGGER));
            baseLayer.CreateGlobalTransition(baseLayer.TryGetStateByName("Death_No_HP")).CreateTriggerCondition(sm.CreateVariable("die", StateMachineVariableKind.TRIGGER));
            
            var additiveLayer = sm.CreateLayer("additive_layer", 1);
            additiveLayer.InitialState = additiveLayer.CreateState("__CLEAR_TRACK__", 0, true);
            
            additiveLayer.AddSimpleTriggeredState("punch_attack", "Punch_AL", allowTransitionToSelf: true);
            additiveLayer.AddSimpleTriggeredState("sword_attack", "Attack_Melee_1_mIK_AL2", allowTransitionToSelf: true);
            additiveLayer.AddSimpleTriggeredState("swing_tool", "008BED/swing_pickaxe_AL");
            additiveLayer.AddSimpleTriggeredState("eat", "Eat_Food_Item");
        }
        
        if (Network.IsServer)
        {
            CurrentHealth = Save.GetInt(this, SAVE_ID_CURRENT_HEALTH, CombatSkill.MaxHealth);
            
            HelmetId.Set(Save.GetString(this, SAVE_ID_EQUIPPED_HELMET, ""));
            ArmorId.Set(Save.GetString(this, SAVE_ID_EQUIPPED_ARMOR, ""));
            AuraId.Set(Save.GetString(this, SAVE_ID_EQUIPPED_AURA, ""));
            
            var position = Save.GetString(this, SAVE_ID_WORLD_POSITION, null);

            if (position == null)
            {
                Teleport(GameManager.Instance.InitialSpawn.Position);
            }
            else
            {
                var args = position.Split("/");

                if (float.TryParse(args[0], out var x) && float.TryParse(args[1], out var y))
                {
                    Teleport(new Vector2(x, y));
                }
                else
                {
                    Teleport(GameManager.Instance.InitialSpawn.Position);
                }
            }
            
            Initialized.Set(true);
        }
    }

    public override void OnDestroy()
    {
        if (Network.IsServer)
        {
            Save.SetString(this, SAVE_ID_WORLD_POSITION, $"{Entity.Position.X}/{Entity.Position.Y}");
        }
    }

    public override void Update()
    {
        if (IsLocal)
        {
            DrawPlayerUI();
            CameraControl.Zoom = AOMath.Lerp(CameraControl.Zoom, AdditiveZoom, 10 * Time.DeltaTime);
            CameraControl.Position = Entity.Position + Vector2.Up * 0.5f;

            if (Input.GetMouseDown(Input.MouseButton.MOUSE_LEFT, true))
            {
                float distance = float.MaxValue;
                Mob mob = null;
                foreach (var other in Mob.ActiveMobs)
                {
                    var pos = Input.GetMousePosition();
                    var dist = Vector2.Distance(other.CenterMassAnchor.Position, pos);
                    if (dist > distance || dist > 1f)
                        continue;

                    mob = other;
                    distance = dist;
                }

                if (mob != null)
                {
                    Effect_TargetMob.CallServer_RequestAddToPlayer(this, mob.Entity);
                }
            }
        }
        else if (!Network.IsServer)
        {
            RemoteDrawCombatLevel();
        }
    }
    
    public void ServerSendNotification(string message)
    {
        CallClient_ReceiveNotification(message, new RPCOptions { Target = this });
    }

    public bool ServerCheckRequirements(List<(SkillType, int)> requirements, string action)
    {
        string failMessage = "You need ";
        int missingStats = 0;
        
        foreach (var requirement in requirements)
        {
            if (GetSkillFromType(requirement.Item1).CurrentLevel < requirement.Item2)
            {
                if (missingStats > 0)
                {
                    failMessage += ", ";
                }
                
                failMessage += $"{requirement.Item2} {requirement.Item1}";
                missingStats++;
            }
        }

        if (missingStats > 0)
        {
            failMessage += $" to {action} that";
            ServerSendNotification(failMessage);
            return false;
        }

        return true;
    }

    public void MovePlayer(Vector2 targetPosition)
    {
        if (!Navmesh.TryFindClosestPointOnAnyNavmesh(targetPosition, out var newPosition, out var newNavmesh))
        {
            return;
        }

        Teleport(newPosition);
        Agent.NavmeshToLockTo = newNavmesh;

        if (IsLocal)
        {
            CameraControl.Position = targetPosition;
        }
    }
    
    [ClientRpc]
    public void ReceiveNotification(string message)
    {
        if (IsLocal)
        {
            Notifications.Show(message);
        }
    }
    
    public bool CanInventoryTakeItems(params Item_Definition[] itemDefinitions)
    {
        int slotsNeeded = itemDefinitions.Length;
        List<Item_Definition> emptySlotsConsumedBy = new List<Item_Definition>();     
        
        foreach (var itemDef in itemDefinitions)
        {
            foreach (var item in DefaultInventory.Items)
            {
                if (item == null || (item.Definition == itemDef && item.Quantity < itemDef.StackSize) || emptySlotsConsumedBy.Contains(itemDef))
                {
                    if (item == null)
                    {
                        emptySlotsConsumedBy.Add(itemDef);
                    }
                    
                    slotsNeeded--;
                }
            }
        }

        return slotsNeeded <= 0;
    }
    
    public bool ServerTryAddItem(Item_Definition itemDef, int count = 1, bool sendMessage = false, List<(string, string)> metadata = null)
    {
        if (!Network.IsServer) return false;
        if (itemDef == null) return false;

        int numStacks = (count / itemDef.StackSize) + 1;
        int numItemsLeftToAdd = count;

        // If the number of items is bigger than one stack size, we'll keep adding stacks until we have everything added
        for (int i = 0; i < numStacks && numItemsLeftToAdd > 0; i++)
        {
            int numItemsInThisStack = Math.Min(itemDef.StackSize, numItemsLeftToAdd);
            var itemInstance = Inventory.CreateItem(itemDef, numItemsInThisStack);

            numItemsLeftToAdd -= numItemsInThisStack;

            if (itemInstance != null && Inventory.CanMoveItemToInventory(itemInstance, DefaultInventory, out _))
            {
                Inventory.MoveItemToInventory(itemInstance, DefaultInventory);

                if (metadata != null && itemDef.StackSize == 1) // Can only set metadata on non-stackable items
                {
                    foreach (var (key, value) in metadata)
                    {
                        itemInstance.SetMetadata(key, value);
                    }
                }
            }
            else
            {
                return false;
            }
        }

        if (sendMessage)
        {
            Chat.SendMessage(this, $"Added x{count} {itemDef.Name}{(numStacks > 1 ? $" split into {numStacks} stacks." : ".")}");
        }

        RequestUpdateCurrentHoveredSlot(CurrentHeldSlot.Value);
        return true;
    }
    
    [ServerRpc]
    public void TryDropItem(long itemIndex)
    {
        var items = DefaultInventory.Items;
        if (itemIndex < 0 || itemIndex >= items.Length) return;

        var player = (MyPlayer)Network.GetRemoteCallContextPlayer();
        if (!player.Alive()) return;

        var item = items[itemIndex];
        if (item == null) return;
        if (item.Inventory != player.DefaultInventory) return;

        var dropLevel = GameItems.Instance.GetDropWarningLevelForItemDefinition(item.Definition);
        
        if (dropLevel == DropWarningLevel.CannotDrop)
        {
            ServerSendNotification("You cannot drop that item.");
            return;
        }

        if (dropLevel == DropWarningLevel.Warn)
        {
            ServerSendNotification("TODO - Add warning popup when dropping high value items");
            return;
        }

        Inventory.RemoveItemFromInventory(item, player.DefaultInventory);
        ServerDropItems(new List<Item_Instance>(){item});
    }
    
    public void ServerDropItems(List<Item_Instance> itemsToDrop)
    {
        if (!Network.IsServer) return;
        if (itemsToDrop.Count <= 0) return;

        foreach (var item in itemsToDrop)
        {
            GameItems.Instance.SpawnLootInstance(item.Definition, Entity.Position, true, (int)item.Quantity);
        }

        RequestUpdateCurrentHoveredSlot(CurrentHeldSlot.Value);
    }

    [ServerRpc]
    public void RequestUpdateCurrentHoveredSlot(int slot)
    {
        CurrentHeldSlot.Set(slot, true);
    }
    
    [ServerRpc]
    public void TryWearItem(long itemIndex, EquipmentSlotType targetSlot)
    {
        var items = DefaultInventory.Items;
        if (itemIndex < 0 || itemIndex >= items.Length) return;

        var player = (MyPlayer)Network.GetRemoteCallContextPlayer();
        if (!player.Alive()) return;

        var item = items[itemIndex];
        if (item == null) return;
        if (item.Inventory != player.DefaultInventory) return;

        var itemSlot = GameItems.Instance.GetEquipmentSlotForItemDefinition(item.Definition);
        
        if (itemSlot == EquipmentSlotType.None)
        {
            ServerSendNotification("You can't wear that");
            return;
        }

        if (itemSlot != targetSlot)
        {
            ServerSendNotification($"You cannot wear an {item.Definition.Name} in the {targetSlot.ToString()} slot");
            return;
        }
        
        Inventory.RemoveItemFromInventory(item, player.DefaultInventory);
        RequestUpdateCurrentHoveredSlot(CurrentHeldSlot.Value);

        switch (targetSlot)
        {
            case EquipmentSlotType.Helmet:
                HelmetId.Set(item.Definition.Id);
                break;
            case EquipmentSlotType.Armour:
                ArmorId.Set(item.Definition.Id);
                break;
            case EquipmentSlotType.Aura:
                AuraId.Set(item.Definition.Id);
                break;
        }
    }

    [ServerRpc]
    public void TryUnwearItem(EquipmentSlotType slot)
    {
        Item_Definition itemDef = null;
        
        switch (slot)
        {
            case EquipmentSlotType.Helmet:
                if (!GameItems.Instance.TryGetItemDefinitionFromId(HelmetId, out itemDef)) throw new ArgumentOutOfRangeException($"Cannot find item definition for {HelmetId.Value}");
                break;
            case EquipmentSlotType.Armour:
                if (!GameItems.Instance.TryGetItemDefinitionFromId(ArmorId, out itemDef)) throw new ArgumentOutOfRangeException($"Cannot find item definition for {ArmorId.Value}");
                break;
            case EquipmentSlotType.Aura:
                if (!GameItems.Instance.TryGetItemDefinitionFromId(AuraId, out itemDef)) throw new ArgumentOutOfRangeException($"Cannot find item definition for {AuraId.Value}");
                break;
        }

        if (!CanInventoryTakeItems(itemDef))
        {
            CallClient_ReceiveNotification("You don't have enough inventory space!", new RPCOptions() { Target = this });
            return;
        }

        if (!ServerTryAddItem(itemDef))
        {
            CallClient_ReceiveNotification("Something horrible has happened.", new RPCOptions() { Target = this });
            return;
        }
        
        switch (slot)
        {
            case EquipmentSlotType.Helmet:
                HelmetId.Set("");
                break;
            case EquipmentSlotType.Armour:
                ArmorId.Set("");
                break;
            case EquipmentSlotType.Aura:
                AuraId.Set("");
                break;
        }
    }

    public long GetItemCount(Item_Definition itemDefinition)
    {
        long count = 0;
        
        foreach (var item in DefaultInventory.Items)
        {
            if (item != null && item.Definition != null && item.Definition.Id == itemDefinition.Id) 
                count += item.Quantity;
        }
        
        return count;
    }
    
    // Removes X amount of an item from the inventory
    public void ServerConsumeItemWithCount(Item_Definition itemDef, long count = 1)
    {
        if (!Network.IsServer) return;

        // Find the slot with the lowest quantity of the item
        // We'll remove from this slot first, and then if there's still more to remove,
        // we'll call this function again with the leftover quantity
        int slotWithLowestQuantity = -1;
        long lowestQuantity = long.MaxValue;

        for (int i = 0; i < DefaultInventory.Items.Length; i++)
        {
            var item = DefaultInventory.Items[i];

            if (item != null && item.Definition == itemDef)
            {
                if (item.Quantity < lowestQuantity)
                {
                    lowestQuantity = item.Quantity;
                    slotWithLowestQuantity = i;
                }
            }
        }

        if (slotWithLowestQuantity != -1)
        {   
            // If this is negative, we will have to consume more from another slot
            var leftoverQuantity = lowestQuantity - count; 

            if (leftoverQuantity <= 0)
            {
                // Eliminate this stack entirely if it's now empty
                Inventory.RemoveItemFromInventory(DefaultInventory.Items[slotWithLowestQuantity], DefaultInventory);
                RequestUpdateCurrentHoveredSlot(CurrentHeldSlot.Value);
            }
            else
            {
                // Otherwise, just reduce the quantity of this stack
                CallClient_SetSlotNewQuantity(slotWithLowestQuantity, leftoverQuantity);
            }

            // If there's still more to consume, we'll consume from the next smallest stack until we have consumed the total amount
            if (leftoverQuantity < 0)
            {
                ServerConsumeItemWithCount(itemDef, Math.Abs(leftoverQuantity));
            }
        }
        else
        {
            Log.Warn($"No slot found for {itemDef.Name} after trying to consume {count} of them");
        }
    }
    
    [ClientRpc]
    public void SetSlotNewQuantity(long slot, long newQuantity)
    {
        var instance = DefaultInventory.Items[slot];
        if (instance == null)
            return;

        instance.Quantity = newQuantity;
    }

    public Skill GetSkillFromType(SkillType type) => type switch
    {
        SkillType.Combat => CombatSkill,
        SkillType.Magic => MagicSkill,
        SkillType.Harvesting => HarvestingSkill,
        SkillType.Crafting => CraftingSkill,
        SkillType.Mixology => MixologySkill,
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
    };

    public void ServerTakeDamage(int damage, Entity source)
    {
        CurrentHealth = Math.Clamp(CurrentHealth - damage, 0, CombatSkill.MaxHealth);

        if (CurrentHealth == 0)
        {
            Effect_Die.CallClient_AddToPlayer(this);
        }
    }
    
    public void ServerHeal(int amountRestored, Entity source, bool spawnHealFX = true)
    {
        int newHealth = Math.Clamp(CurrentHealth + amountRestored, 0, CombatSkill.MaxHealth);

        if (newHealth == CurrentHealth)
            return;
        
        if (spawnHealFX)
        {
            CallClient_OnHealthRestored(newHealth - CurrentHealth, source);
        }
        
        CurrentHealth = Math.Clamp(CurrentHealth + amountRestored, 0, CombatSkill.MaxHealth);
    }

    [ClientRpc]
    public void OnHealthRestored(int amountRestored, Entity source)
    {
        var instance = VFX.Instance.CreateHealFX(Entity);
        instance.Offset = Vector2.Up * 0.25f;
        instance.Animator.DepthOffset = -0.26f;
    }
}

public class Ability_Punch : MyAbility
{
    public override TargettingMode TargettingMode => TargettingMode.Self;
    public override Texture Icon => Assets.GetAsset<Texture>("Sprites/AbilityIcons/Punch.png");
    public override float Cooldown => 0.4f;
    
    public override bool OnTryActivate(Player.AbilityActivationInfo info)
    {
        Player.SpineAnimator.SpineInstance.StateMachine.SetTrigger("punch_attack");
        SFX.Play(Assets.GetAsset<AudioAsset>("SFX/punch.wav"), new SFX.PlaySoundDesc() { EntityToFollow = Player.Entity, Speed = Random.Shared.NextFloat(0.9f, 1.05f) });

        if (Network.IsServer)
        {
            Vector2 dir = Player.GetFacingDirection() ? Vector2.Right : Vector2.Left;
            if (Player.TryGetEffect(out Effect_TargetMob targetingEffect))
            {
                dir = (targetingEffect.TargetedMob.Entity.Position - Player.Entity.Position).Normalized;
            }

            int damage = 1;
            
            Physics.RaycastHit[] hits = new Physics.RaycastHit[18];

            for (int i = 0; i < Physics.BoxCast(Player.Entity.Position + Vector2.Up * 0.2f, Vector2.Zero, Vector2.One * 1f, dir, 2f, ref hits); i++)
                ProcessHit(hits[i]);
            for (int i = 0; i < Physics.OverlapCircle(Player.Entity.Position, 0.5f, ref hits); i++)
                ProcessHit(hits[i]);
            
            void ProcessHit(Physics.RaycastHit hit)
            {
                if (!hit.Collider.Alive() || !hit.Collider.Entity.Alive())
                    return;

                HitsplatType splatType = HitsplatType.Damage;
                
                if (Random.Shared.NextFloat() > 0.9f)
                {
                    damage *= 2;
                    splatType = HitsplatType.Critical;
                }
                
                var entity = hit.Collider.Entity;
                if (entity.TryGetComponent(out Mob mob))
                {
                    mob.CallClient_TryHit(damage, splatType, Player);
                }
            }
        }

        return true;
    }
}

public partial class Effect_UntargetedAttack : MyEffect
{
    [ServerRpc]
    public static void RequestAddToPlayer(MyPlayer player, Vector2 dir) => CallClient_AddToPlayer(player, dir); 
    [ClientRpc]
    public static void AddToPlayer(MyPlayer player, Vector2 dir)
    {
        if (!player.Alive() || player.IsDead)
            return;

        if (player.HasEffect<Effect_UntargetedAttack>())
        {
            player.RemoveEffect<Effect_UntargetedAttack>(true);
        }

        player.AddEffect<Effect_UntargetedAttack>(preInit: e => e.Direction = dir);
    }
    
    public override bool IsActiveEffect => true;

    private Vector2 Direction;

    public override void OnEffectUpdate()
    {
        Player.SetFacingDirection(Direction.X > 0);
    }
}

public class Ability_Attack : MyAbility
{
    public override TargettingMode TargettingMode => TargettingMode.Self;

    public override Texture Icon => Assets.GetAsset<Texture>(Player.CurrentHoldableItem.AbilitySprite);
    public override float Cooldown => Player.CurrentHoldableItem.AbilityCooldown;

    public override bool OnTryActivate(Player.AbilityActivationInfo info)
    {
        if (Player.CurrentHoldableItem == null) 
            return false;

        if (Player.CurrentHoldableItem.GetMetadataValue(HoldableItem.META_ATTACK_ANIM_TRIGGER, out var trigger, ""))
        {
            Player.SpineAnimator.SpineInstance.StateMachine.SetTrigger(trigger);    
        }

        if (Player.CurrentHoldableItem.GetMetadataValue(HoldableItem.META_ATTACK_SOUND, out var sound, ""))
        {
            SFX.Play(Assets.GetAsset<AudioAsset>(sound), new SFX.PlaySoundDesc() { EntityToFollow = Player.Entity, Speed = Random.Shared.NextFloat(0.9f, 1.05f) });
        }

        if (Network.IsServer)
        {
            Player.CurrentHoldableItem.GetMetadataValue(HoldableItem.META_ATTACK_RANGE, out var range, 2f);
            Player.CurrentHoldableItem.GetMetadataValue(HoldableItem.META_ATTACK_WIDTH, out var width, 1f);
            Player.CurrentHoldableItem.GetMetadataValue(HoldableItem.META_BASE_DAMAGE, out var damage, 1);
            
            Vector2 dir = Player.GetFacingDirection() ? Vector2.Right : Vector2.Left;
            if (Player.TryGetEffect(out Effect_TargetMob targetingEffect))
            {
                dir = (targetingEffect.TargetedMob.Entity.Position - Player.Entity.Position).Normalized;
            }

            Physics.RaycastHit[] hits = new Physics.RaycastHit[18];
            
            for (int i = 0; i < Physics.BoxCast(Player.Entity.Position, Vector2.Zero, new Vector2(range, width), dir, range, ref hits); i++)
                ProcessHit(hits[i]);
            for (int i = 0; i < Physics.OverlapCircle(Player.Entity.Position + dir * 0.5f, 0.5f, ref hits); i++)
                ProcessHit(hits[i]);

            void ProcessHit(Physics.RaycastHit hit)
            {
                if (!hit.Collider.Alive() || !hit.Collider.Entity.Alive())
                    return;

                HitsplatType splatType = HitsplatType.Damage;

                if (Random.Shared.NextFloat() > 0.9f)
                {
                    damage *= 2;
                    splatType = HitsplatType.Critical;
                }
                
                var entity = hit.Collider.Entity;
                if (entity.TryGetComponent(out Mob mob))
                {
                    mob.CallClient_TryHit(damage, splatType, Player);
                }
            }
        }

        return true;
    }
}

public partial class Ability_Eat : MyAbility
{
    public override Texture Icon => Assets.GetAsset<Texture>("Sprites/AbilityIcons/Eat.png");
    public override TargettingMode TargettingMode => TargettingMode.Self;
    public override float Cooldown => 0.2f;

    public override bool OnTryActivate(Player.AbilityActivationInfo info)
    {
        if (Network.IsServer)
        {
            Dictionary<Item_Definition, EdibleItemData> edibleItems = new();

            foreach (var item in Player.DefaultInventory.Items)
            {
                if (item == null || edibleItems.ContainsKey(item.Definition) || !GameItems.Instance.TryGetEdibleItemData(item.Definition, out var data))
                    continue;
                
                edibleItems.Add(item.Definition, data);
            }

            if (edibleItems.Count == 0)
            {
                Player.CallClient_ReceiveNotification("You're out of food!", new() { Target = Player });
                return false;
            }

            Item_Definition highestIndex = null;
            
            foreach (var item in edibleItems) if (highestIndex == null || edibleItems[item.Key].HealAmt > edibleItems[highestIndex].HealAmt)
            {
                highestIndex = item.Key;
            }
            
            CallClient_OnEat(Player);
            GameItems.Instance.TryGetEdibleItemData(highestIndex, out EdibleItemData edibleItem);
            Player.ServerConsumeItemWithCount(highestIndex);
            edibleItem.ServerConsume(Player);
        }
        
        return true;
    }

    [ClientRpc]
    public static void OnEat(MyPlayer player)
    {
        SFX.Play(Assets.GetAsset<AudioAsset>("SFX/eat.wav"), new SFX.PlaySoundDesc() { Positional = true, EntityToFollow = player.Entity, Speed = Random.Shared.NextFloat(0.95f, 1.05f) });
        player.SpineAnimator.SpineInstance.StateMachine.SetTrigger("eat");
    }
}

public partial class Effect_TargetMob : MyEffect
{
    [ServerRpc]
    public static void RequestAddToPlayer(MyPlayer player, Entity mobEntity) => CallClient_AddToPlayer(player, mobEntity); 
    [ClientRpc]
    public static void AddToPlayer(MyPlayer player, Entity mobEntity)
    {
        if (!player.Alive() || !mobEntity.Alive() || player.IsDead || !mobEntity.TryGetComponent(out Mob mob))
            return;

        if (player.TryGetEffect(out Effect_TargetMob effect))
        {
            effect.SetMob(mob);
        }
        else
        {
            player.AddEffect<Effect_TargetMob>(preInit: e => e.SetMob(mob));
        }
    }
    
    public override bool IsActiveEffect => true;
    public override bool BlockAbilityActivation => false;

    public Mob TargetedMob;
    public Sprite_Renderer Renderer;

    public override void OnEffectUpdate()
    {
        if (!TargetedMob.Alive() || !TargetedMob.CanHit())
        {
            Player.RemoveEffect<Effect_TargetMob>(true);
            return;
        }

        if (Renderer.Alive())
            Renderer.Entity.Position = TargetedMob.CenterMassAnchor.Position;
        
        Player.SetFacingDirection(TargetedMob.Position.X > Player.Position.X);
    }

    public override void OnEffectEnd(bool interrupt)
    {
        if (Player.IsLocal && TargetedMob.Entity.Alive() && TargetedMob.Health == TargetedMob.MaxHealth)
        {
            TargetedMob.LocalIsBeingTargeted = false;
        }

        if (Renderer.Alive())
        {
            Tween.Scale(Renderer.Entity, Vector2.Zero, 0.2f, Ease.Linear);
            DestroyAfter.Start(Renderer.Entity, 0.2f);
        }
    }

    private void SetMob(Mob mob)
    {
        if (TargetedMob.Alive() && TargetedMob.Health == TargetedMob.MaxHealth)
        {
            TargetedMob.LocalIsBeingTargeted = false;
        }
        
        TargetedMob = mob;
        TargetedMob.LocalIsBeingTargeted = true;

        if (!Player.IsLocal)
            return;
        
        if (!Renderer.Alive())
        {
            Renderer = Entity.Create().AddComponent<Sprite_Renderer>();
            Renderer.Entity.Scale = Vector2.Zero;
            Renderer.Sprite = Assets.GetAsset<Texture>("Sprites/Target.png");
            Renderer.DepthOffset = 10;
        }
        
        Renderer.Entity.Scale = Vector2.Zero;
        Tween.Scale(Renderer.Entity, Vector2.One * 2f, 0.5f, Ease.OutElastic);
    }
}

public partial class Effect_Die : MyEffect
{
    [ClientRpc]
    public static void AddToPlayer(MyPlayer player)
    {
        if (player.IsDead)
            return;

        player.ClearAllEffects();
        player.AddEffect<Effect_Die>();
    }
    
    public override bool IsActiveEffect => true;
    public override bool BlockAbilityActivation => true;
    public override bool BlockInteractables => true;
    public override bool FreezePlayer => true;
    public override bool DisableMovementInput => true;
    public override bool IsValidTarget => false;
    public override float DefaultDuration => 2.5f;

    public override void OnEffectStart(bool isDropIn)
    {
        if (!isDropIn)
        {
            Player.CurrentHealth = 0;
            Player.SpineAnimator.SpineInstance.StateMachine.SetTrigger("die");
            SFX.Play(Assets.GetAsset<AudioAsset>("SFX/0hp_death.wav"), new SFX.PlaySoundDesc() { Positional = true, Position = Player.Entity.Position });
        }
    }

    public override void OnEffectEnd(bool interrupt)
    {
        Player.SpineAnimator.SpineInstance.StateMachine.SetTrigger("reset");
        Player.MovePlayer(GameManager.Instance.InitialSpawn.Position);
        Player.CurrentHealth = Player.CombatSkill.MaxHealth;
    }
}

public partial class Effect_LevelUp : MyEffect
{
    [ClientRpc]
    public static void AddToPlayer(MyPlayer player, SkillType skillType)
    {
        if (player.HasEffect<Effect_LevelUp>())
            return;
        
        player.AddEffect<Effect_LevelUp>(preInit: e => e.Skill = player.GetSkillFromType(skillType));
    }
    
    public override bool IsActiveEffect => false;
    public override float DefaultDuration => 3;

    private Skill Skill;
    
    public override void OnEffectStart(bool isDropIn)
    {
        if (Player.IsLocal)
        {
            if (Skill.CurrentLevel >= 70)
            {
                SFX.Play(Assets.GetAsset<AudioAsset>("SFX/level-up-high.wav"), new SFX.PlaySoundDesc() { Positional = false });
            }
            else if (Skill.CurrentLevel >= 30)
            {
                SFX.Play(Assets.GetAsset<AudioAsset>("SFX/level-up-medium.wav"), new SFX.PlaySoundDesc() { Positional = false });
            }
            else
            {
                SFX.Play(Assets.GetAsset<AudioAsset>("SFX/level-up-low.wav"), new SFX.PlaySoundDesc() { Positional = false });
            }
        }
    }
}

public partial class Effect_Crafting : MyEffect
{
    public override bool IsActiveEffect => true;
    public override bool BlockAbilityActivation => true;
    public override bool BlockInteractables => true;
    public override bool FreezePlayer => true;

    public ACraftingStation CraftingStation;
    public Entity StationEntity;
    
    private List<Recipe> Recipes;

    public override void OnEffectStart(bool isDropIn)
    {
        if (Player.IsLocal)
        {
            MyUI.IsUIBlockingWindowOpen = true;
            Recipes = ACraftingStation.AllRecipes[CraftingStation.GetType()];
        }
    }

    public override void OnEffectEnd(bool interrupt)
    {
        if (Player.IsLocal)
        {
            MyUI.IsUIBlockingWindowOpen = false;
        }
    }
    
    [ServerRpc]
    public static void RequestCloseMenu(MyPlayer player) => CallClient_CloseMenu(player);
    [ClientRpc]
    public static void CloseMenu(MyPlayer player)
    {
        player.RemoveEffect<Effect_Crafting>(false);   
    }

    public override void OnEffectUpdate()
    {
        if (!StationEntity.Alive())
        {
            Player.RemoveEffect<Effect_Crafting>(false);
        }
        
        if (Player.IsLocal)
        {
            var windowRect = UI.ScreenRect.CenterRect().Grow(300, 500, 300, 500).Offset(-50, 50);
        
            UI.Image(windowRect, Assets.GetAsset<Texture>("Sprites/modal-9slice.png"), nineSlice: new UI.NineSlice { slice = new Vector4(34, 34, 34, 34), sliceScale = 0.5f }, tint: new Vector4(0.3f, 0.3f, 0.3f, 1f));
            UI.TextAsync(windowRect.TopCenterRect().Grow(100), CraftingStation.WindowName, MyUI.GetTextSettings(64));

            var gridRect = windowRect.Inset(10).GrowTop(-30);
            var scrollView = UI.PushScrollView("mainScrollView", gridRect, new UI.ScrollViewSettings() { Horizontal = true });
            {
                var grid = UI.GridLayout.Make(gridRect, 3, 6, UI.GridLayout.SizeSource.ElementCount, padding: 6);

                for (int i = 0; i < Recipes.Count; i++)
                {
                    var recipe = Recipes[i];
                    var rect = grid.Next();
                    UI.PushId(recipe.Name);
                    
                    var button = UI.Button(rect, "", MyUI.GetButtonSettings("Sprites/modal-9slice.png"), MyUI.GetTextSettings(0));
                    if (button.JustPressed)
                    {
                        CraftingStation.LocalRequestProcess(Player, i);
                    }

                    var circleAsset = Assets.GetAsset<Texture>("$AO/circle.png");
                    var iconRect = rect.CutLeft(100).FitAspect(circleAsset.Aspect).Inset(5);
                    UI.Image(iconRect.Grow(AOMath.Lerp(0, 5, button.Active01)), circleAsset, tint: Vector4.Black);
                    UI.Image(iconRect.Inset(5).Grow(AOMath.Lerp(0, 5, button.Active01)), circleAsset);

                    var asset = Assets.GetAsset<Texture>(recipe.Result[0].Item1.Icon);
                    UI.Image(iconRect.FitAspect(asset.Aspect).Inset(5).Grow(AOMath.Lerp(0, 5, button.Active01)), asset);

                    var infoRect = rect;
                    UI.TextAsync(infoRect.TopLeftRect().Grow(30, 1000, 30, 0).Offset(-10, -15), recipe.Name, MyUI.GetTextSettings(32, halign: UI.HorizontalAlignment.Left, valign: UI.VerticalAlignment.Center));

                    var ingredientGridRect = infoRect.InsetTop(25).Offset(-10, 0);
                    var ingredientGrid = UI.GridLayout.Make(ingredientGridRect.CutLeft(75 * recipe.Ingredients.Length), recipe.Ingredients.Length, 1, UI.GridLayout.SizeSource.ElementCount, padding: 6);
                    foreach (var recipeIngredient in recipe.Ingredients)
                    {
                        bool playerHasIngredient = Player.GetItemCount(recipeIngredient.Item1) > recipeIngredient.Item2;
                        
                        var ingredientRect = ingredientGrid.Next();
                        var iconAsset = Assets.GetAsset<Texture>(recipeIngredient.Item1.Icon);
                        UI.Image(ingredientRect.CutLeft(40).FitAspect(iconAsset.Aspect), iconAsset);
                        UI.TextAsync(ingredientRect, $"x{recipeIngredient.Item2}", MyUI.GetTextSettings(25, playerHasIngredient ? Vector4.White : Vector4.Red));
                    }
                    
                    UI.PopId();
                }
            }
            UI.PopScrollView();
            
            if (UI.Button(windowRect.TopRightRect().Offset(50, -25).Grow(40), "Close", MyUI.GetButtonSettings("$AO/new/log_in/close_button.png", bgTint: Vector4.Red, slice: false), MyUI.GetTextSettings(0, offset: 7)).JustPressed)
            {
                CallServer_RequestCloseMenu(MyPlayer.LocalPlayer);
            }
        }
    }
}

public class Effect_Harvesting : MyEffect
{
    public override bool IsActiveEffect => true;

    private float NextHarvestTick;
    public Harvestable Harvestable;

    public override void OnEffectStart(bool isDropIn)
    {
        if (!Harvestable.Alive() || Harvestable.IsDepleted.Value)
        {
            Player.RemoveEffect(this, false);
            return;
        }

        NextHarvestTick = Harvestable.BaseHarvestRate;

        Player.SpineAnimator.SpineInstance.EnableSkin("008BED/weapons/iron_pickaxe");
        Player.SpineAnimator.SpineInstance.RefreshSkins();
    }

    public override void OnEffectEnd(bool interrupt)
    {
        Player.SpineAnimator.SpineInstance.DisableSkin("008BED/weapons/iron_pickaxe");
        Player.SpineAnimator.SpineInstance.RefreshSkins();
    }

    public override void OnEffectUpdate()
    {
        if (Vector2.Distance(Player.Entity.Position, Harvestable.Entity.Position) > Harvestable.Interactable.Radius)
        {
            CancelHarvesting("Harvesting aborted");
            return;
        }
        
        if (!Harvestable.Alive() || Harvestable.IsDepleted.Value)
        {
            CancelHarvesting("Resource depleted");
            return;
        }
        
        if (Network.IsServer)
        {
            NextHarvestTick += Time.DeltaTime;

            if (NextHarvestTick > Harvestable.BaseHarvestRate)
            {
                if (Random.Shared.NextFloat() < Harvestable.BaseHarvestChance)
                {
                    Harvestable.ServerOnHarvest(Player);
                }
                else
                {
                    Harvestable.ServerOnHarvestFail(Player);
                }
            
                NextHarvestTick = 0;    
            }
        }
    }

    private void CancelHarvesting(string message)
    {
        if (Player.IsLocal)
        {
            SFX.Play(Assets.GetAsset<AudioAsset>("SFX/resource-depleted.wav"), new SFX.PlaySoundDesc() { Positional = false, Volume = 0.5f });
            Player.CreatePopupMessage(Harvestable.Entity.Position, message);
        }
        
        Player.RemoveEffect(this, false);
    }
}