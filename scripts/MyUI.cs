using System.Buffers;
using AO;
using Assembly.scripts;

public static class MyUI
{
    public const int XP_DROP_LAYER = 50;
    public const float XP_DROP_LIFESPAN = 1.5f;

    public static bool IsUIBlockingWindowOpen = false;
    
    public static UI.TextSettings GetTextSettings(float size, Vector4? textColor = null, UI.HorizontalAlignment halign = UI.HorizontalAlignment.Center, UI.VerticalAlignment valign = UI.VerticalAlignment.Center, float offset = 0, bool wrap = false, float xOffset = 0)
    {
        return new UI.TextSettings
        {
            Font = UI.Fonts.BarlowBold,
            Size = size,
            Color = textColor ?? Vector4.White,
            DropShadow = true,
            Offset = new Vector2(xOffset, offset),
            DropShadowColor = new Vector4(0f,0f,0.02f,0.5f),
            DropShadowOffset = new Vector2(0f,-3f),
            HorizontalAlignment = halign,
            VerticalAlignment = valign,
            WordWrap = wrap,
            WordWrapOffset = 0,
            OverflowWrap = wrap,
            Outline = true,
            OutlineThickness = 3,
            AutofitIters = 10,
        };
    }
    
    public static UI.ButtonSettings GetButtonSettings(string asset, bool slice = true, Vector4? bgTint = null, float pressScaling = 0)
    {
        return new UI.ButtonSettings
        {
            PressScaling = pressScaling,
            Sprite = Assets.GetAsset<Texture>(asset),
            Slice = slice ? new UI.NineSlice { slice = new Vector4(34, 34, 34, 34), sliceScale = 0.5f } : default,
            BackgroundColorMultiplier = bgTint ?? Vector4.White
        };
    }
}

public partial class MyPlayer
{
    private List<UIXPDrop> ActiveXPDrops = new();
    private List<PopUpMessage> ActivePopupMessages = new();

    private float AdditiveZoom = 1.5f;

    private void DrawPlayerUI()
    {
        DrawHotbar();
        DrawXPDrops();
        DrawPopupMessages();
        DrawHealthBar();
        DrawAbilities();
        
        if (UI.IsBlockingWindowOpen == false)
        {
            bool zoomChanged;
            float nextZoom = ZoomSliderUI.DrawRightZoomSlider(AdditiveZoom, 0.3f, 5f, out zoomChanged);
            if (zoomChanged)
            {
                AdditiveZoom = nextZoom;
            }
        }
    }

    private void DrawAbilities()
    {
        List<Ability> abilities = new List<Ability>();

        if (CurrentHeldItem != null)
        {
            var holdable = GameItems.Instance.GetHoldableForItemDefinition(CurrentHeldItem.Definition);
            if (holdable != null)
            {
                foreach (var ability in holdable.ItemAbilities)
                {
                    abilities.Add(GetAbility(ability));
                }
            }
            else
            {
                abilities.Add(GetAbility<Ability_Punch>());    
            }
        }
        else
        {
            abilities.Add(GetAbility<Ability_Punch>());
        }
        
        abilities.Add(GetAbility<Ability_Eat>());

        if (abilities.Count > 0)
        {
            DrawDefaultAbilityUI(new AbilityDrawOptions() { AbilityElementSize = 75, Abilities = abilities.ToArray() });
        }
    }

    private void RemoteDrawCombatLevel()
    {
        if (!Camera.GetCurrentCameraWorldRect().Overlaps(FinalNameRect)) return;
        
        using var _1 = UI.PUSH_CONTEXT(UI.Context.World);
        using var _2 = IM.PUSH_Z(GetZOffset() - 0.0001f); // minus an epsilon so the health bar draws over the player
        using var _3 = UI.PUSH_SCALE_FACTOR(5.0f / 540.0f);
        var rect = FinalNameRect.TopCenterRect().Offset(0, 5).Grow(13, 70, 0, 70).Offset(0, 0);

        Vector4 levelTint = new Vector4(0, 1, 0, 1);
        switch (CombatSkill.CurrentLevel - LocalPlayer.CombatSkill.CurrentLevel)
        {
            case > 10:
                levelTint = new Vector4(1, 0, 0f, 1f);
                break;
            case > 6:
                levelTint = new Vector4(1, 0.188f, 0, 1f);
                break;
            case > 3:
                levelTint = new Vector4(1, 0.439f, 0, 1f);
                break;
            case > 0:
                levelTint = new Vector4(1, 0.69f, 0, 1f);
                break;
            case 0:
                levelTint = new Vector4(1, 1, 0f, 1f);
                break;
            case > -4:
                levelTint = new Vector4(0.753f, 1, 0, 1f);
                break;
            case > -7:
                levelTint = new Vector4(0.502f, 1, 0, 1f);
                break;
            case > -10:
                levelTint = new Vector4(0.251f, 1, 0, 1f);
                break;
        }

        UI.TextAsync(rect, $"Level: {CombatSkill.CurrentLevel}", MyUI.GetTextSettings(30, levelTint));
    }

    private void DrawHealthBar()
    {
        var rect = UI.SafeRect.TopCenterRect().Grow(0, 300, 40, 300).Offset(0, -30);
        var healthBarAsset = Assets.GetAsset<Texture>("Sprites/UI/HealthBar.png");
        var healthIconAsset = Assets.GetAsset<Texture>("Sprites/UI/Health.png");
        UI.Image(rect.Grow(3), healthBarAsset, tint: new Vector4(0.2f, 0.2f, 0.2f, 1f));

        var maskRect = rect.SubRect(0f, 0f, CurrentHealth / (float)CombatSkill.MaxHealth, 1f);
        var maskScope = IM.MakeMaskScope(maskRect);
        {
            using var _123 = IM.BUILD_MASK_SCOPE(maskScope);
            UI.Image(maskRect, null);
        }
        {
            using var _323 = IM.USE_MASK_SCOPE(maskScope);
            UI.Image(rect, healthBarAsset, tint: new Vector4(1f, 0.2f, 0.2f, 1f));
        }
        
        var iconRect = rect.LeftCenterRect().Offset(-20, 0).Grow(50).FitAspect(healthIconAsset.Aspect);
        UI.Image(iconRect, healthIconAsset);
        UI.TextAsync(iconRect, CurrentHealth.ToString(), MyUI.GetTextSettings(50, offset: 5));
    }

    private void DrawXPDrops()
    {
        using var _1 = UI.PUSH_CONTEXT(UI.Context.World);
        using var _2 = UI.PUSH_LAYER(MyUI.XP_DROP_LAYER);

        for (int i = ActiveXPDrops.Count - 1; i >= 0; i--)
        {
            var drop = ActiveXPDrops[i];
            
            var pos = drop.Origin + drop.Direction * Ease.OutQuart(MathF.Min(drop.TimeAlive / (MyUI.XP_DROP_LIFESPAN * 0.5f), 1f));
            var rect = new Rect(pos, pos);
            
            UI.TextAsync(rect, $"+{drop.Amount} XP", MyUI.GetTextSettings(Ease.OutElastic(MathF.Min(drop.TimeAlive / (MyUI.XP_DROP_LIFESPAN * 0.75f), 1f)) * 0.25f, drop.Skill.SkillColor));
            
            drop.TimeAlive += Time.DeltaTime;
            if (drop.TimeAlive > MyUI.XP_DROP_LIFESPAN)
            {
                ActiveXPDrops.Remove(drop);
            }
        }
    }
    
    private void DrawPopupMessages()
    {
        using var _1 = UI.PUSH_CONTEXT(UI.Context.World);
        using var _2 = UI.PUSH_LAYER(MyUI.XP_DROP_LAYER);

        for (int i = ActivePopupMessages.Count - 1; i >= 0; i--)
        {
            var message = ActivePopupMessages[i];
            
            var pos = message.Origin + (Vector2.Up * Ease.OutQuart(MathF.Min(message.TimeAlive / (MyUI.XP_DROP_LIFESPAN * 0.5f), 1f)) * 0.5f);
            var rect = new Rect(pos, pos);
            
            UI.TextAsync(rect, $"{message.Message}", MyUI.GetTextSettings(0.25f));
            
            message.TimeAlive += Time.DeltaTime;
            if (message.TimeAlive > MyUI.XP_DROP_LIFESPAN)
            {
                ActivePopupMessages.Remove(message);
            }
        }
    }

    private void DrawHotbar()
    {
        var hotbarResult = Inventory.DrawHotbar(DefaultInventory.Id, new Inventory.DrawOptions()
        {
            HotbarItemCount = 6,
            AllowDragDrop = !UI.IsBlockingWindowOpen,
            ScrollItemSelection = !UI.IsBlockingWindowOpen && !MyUI.IsUIBlockingWindowOpen,
            KeyboardItemSelection = !UI.IsBlockingWindowOpen,
            EnableUseFromHotbar = false,
            EnableSelection = true,
            
            OnBeforeDraw = (item, rect) =>
            {
                if (item != null)
                {
                    // Try to parse the rarity from the metadata first
                    var rarityMetadata = item.GetMetadata("rarity");
                    MyItemRarity rarity = Enum.TryParse<MyItemRarity>(rarityMetadata, out var parsedRarity) ? parsedRarity : GameItems.Instance.GetDefaultRarityForItemDefinition(item.Definition);

                    // Colour in the background of the item to show its rarity
                    var rarityColor = MyUtil.GetColorForRarity(rarity);
                    rarityColor.W = 0.8f;
                    var highlightRect = rect.Inset(8);
                    UI.Image(highlightRect, Assets.GetAsset<Texture>("$AO/new/in_game/inventory/inventory_v2/inventory_bubble.png"), rarityColor);

                    // Draw a series of star icons to represent the rarity as well
                    int starCount = (int)rarity + 1;
                    bool isEven = starCount % 2 == 0;
                    var starSize = 12;
                    var starRect = rect.BottomCenterRect().Grow(starSize, starSize / 2f, 0, starSize / 2f);
                        
                    // The stars are centered along the bottom
                    // So, we need to know how many on each side of the middle
                    // When even, there are 2 stars in the middle. Odd just has the 1 centered one
                    int countExcludingMiddle = starCount;
                    countExcludingMiddle = isEven ? countExcludingMiddle - 2 : countExcludingMiddle - 1;

                    if (isEven)
                    {
                        // Offset by half a star to the left if even so they're centered
                        starRect = starRect.Slide(-0.5f, 0);
                    }

                    starRect = starRect.Slide(-countExcludingMiddle / 2f, 0);

                    rarityColor.W = 1.0f;
                    for (int i = 0; i < starCount; i++)
                    {
                        UI.Image(starRect, Assets.GetAsset<Texture>("$AO/new/Shop Modal/Premium_Shop/full_star.png"), rarityColor);
                        starRect = starRect.Slide(1, 0);
                    }
                }
            }
        });

        if (hotbarResult.SelectedItemIndex != CurrentHeldSlot)
        {
            CallServer_RequestUpdateCurrentHoveredSlot(hotbarResult.SelectedItemIndex);
        }
        
        bool dropItem = hotbarResult.DroppedItem != null;
        
        if (hotbarResult.InventoryOpen)
        {
            Rect rect = hotbarResult.EntireRect.TopLeftRect().Grow(40).Offset(40, -165);
            
            DoEquipmentSlot(EquipmentSlotType.Helmet);
            DoEquipmentSlot(EquipmentSlotType.Armour);
            DoEquipmentSlot(EquipmentSlotType.Aura);
            
            void DoEquipmentSlot(EquipmentSlotType equipmentSlot)
            {
                string bgSprite = "Sprites/inventory_armor_empty.png";
                string foregroundSprite = null;
                Item_Definition itemDefinition = null;
                
                switch (equipmentSlot)
                {
                    case EquipmentSlotType.Helmet:
                    {
                        if (!HelmetId.Value.IsNullOrEmpty())
                        {
                            bgSprite = "$AO/new/in_game/inventory/inventory_v2/inventory_bubble.png";
                            if (GameItems.Instance.TryGetItemDefinitionFromId(HelmetId, out itemDefinition))
                            {
                                foregroundSprite = itemDefinition.Icon;
                            }
                        }
                        else
                        {
                            bgSprite = "Sprites/inventory_helmet_empty.png";
                        }
                        break;
                    }
                    case EquipmentSlotType.Armour:
                    {
                        if (!ArmorId.Value.IsNullOrEmpty())
                        {
                            bgSprite = "$AO/new/in_game/inventory/inventory_v2/inventory_bubble.png";
                            if (GameItems.Instance.TryGetItemDefinitionFromId(HelmetId, out itemDefinition))
                            {
                                foregroundSprite = itemDefinition.Icon;
                            }
                        }
                        else
                        {
                            bgSprite = "Sprites/inventory_armor_empty.png";
                        }
                        break;
                    }
                    case EquipmentSlotType.Aura:
                    {
                        if (!AuraId.Value.IsNullOrEmpty())
                        {
                            bgSprite = "$AO/new/in_game/inventory/inventory_v2/inventory_bubble.png";
                            if (GameItems.Instance.TryGetItemDefinitionFromId(AuraId, out itemDefinition))
                            {
                                foregroundSprite = itemDefinition.Icon;
                            }
                        }
                        else
                        {
                            bgSprite = "Sprites/inventory_aura_empty.png";
                        }
                        break;
                    }
                }

                var color = MyUtil.GetColorForRarity(itemDefinition != null ? GameItems.Instance.GetDefaultRarityForItemDefinition(itemDefinition) : MyItemRarity.Common);
                color.W = hotbarResult.InventoryOpen01;

                var result = UI.Button(rect, equipmentSlot.ToString(), MyUI.GetButtonSettings(bgSprite, false, color), MyUI.GetTextSettings(0));

                if (foregroundSprite != null)
                {
                    var icon = Assets.GetAsset<Texture>(foregroundSprite);
                    UI.Image(rect.Inset(8).FitAspect(icon.Aspect), icon);
                }

                if (result.JustPressed && !dropItem)
                {
                    CallServer_TryUnwearItem(equipmentSlot);
                    return;
                }

                if (rect.Contains(Input.GetMouseScreenPosition()))
                {
                    if (dropItem)
                    {
                        CallServer_TryWearItem(hotbarResult.DroppedItem.InventorySlot, equipmentSlot);
                        dropItem = false;
                    }
                }
                
                rect = rect.Offset(0, -95);
            }
        }
        
        if (dropItem)
        {
            CallServer_TryDropItem(hotbarResult.DroppedItem.InventorySlot);
        }
        
        //Skills

        float width = hotbarResult.EntireRect.Width / 5;
        var skillsRect = hotbarResult.EntireRect.TopRect().GrowTopUnscaled(width);

        DrawXPOrb(skillsRect.CutLeftUnscaled(width).Inset(15), CombatSkill);
        DrawXPOrb(skillsRect.CutLeftUnscaled(width).Inset(15), MagicSkill);
        DrawXPOrb(skillsRect.CutLeftUnscaled(width).Inset(15), HarvestingSkill);
        DrawXPOrb(skillsRect.CutLeftUnscaled(width).Inset(15), CraftingSkill);
        DrawXPOrb(skillsRect.CutLeftUnscaled(width).Inset(15), MixologySkill);

        void DrawXPOrb(Rect rect, Skill skill)
        {
            UI.Image(rect, Assets.GetAsset<Texture>("Sprites/UI/XPOrbBack.png"));
            
            var maskScope = IM.MakeMaskScope(rect.SubRect(0f, 0.5f, 1f, 1f));
            {
                using var _123 = IM.BUILD_MASK_SCOPE(maskScope);
                UI.Image(rect.SubRect(0f, 0.5f, 1f, 1f), null);
            }
            {
                using var _323 = IM.USE_MASK_SCOPE(maskScope);

                var tint = skill.ProgressToNextLevel > 0.5f ? Vector4.Lerp(new Vector4(1f, 1f, 0f, 1f), Vector4.Green, MyUtil.GetNormalizedValue(skill.ProgressToNextLevel, 0.5f, 1f)) : 
                                                                     Vector4.Lerp(Vector4.Red, new Vector4(1f, 1f, 0f, 1f), MyUtil.GetNormalizedValue(skill.ProgressToNextLevel, 0.0f, 0.5f));
                skill.RotationValue = AOMath.Lerp(skill.RotationValue, AOMath.Lerp(180, 0, skill.ProgressToNextLevel), 10 * Time.DeltaTime);
                    
                UI.Image(rect, Assets.GetAsset<Texture>("Sprites/UI/XPOrbFill.png"), tint: tint, rotationDegrees: skill.RotationValue);
            }
            
            var skillIcon = Assets.GetAsset<Texture>(skill.Icon);
            
            UI.Image(rect.Inset(10), Assets.GetAsset<Texture>("Sprites/UI/XPOrbFront.png"));    
            UI.Image(rect.Inset(20).FitAspect(skillIcon.Aspect), skillIcon);
            UI.TextAsync(rect.Offset(0, 15), skill.CurrentLevel.ToString(), MyUI.GetTextSettings(64, skill.SkillColor));
            
            UI.TextAsync(rect.BottomCenterRect().Offset(0, 25), skill.Name, MyUI.GetTextSettings(32, skill.SkillColor));
        }
    }
    
    [ClientRpc]
    public void SpawnXPDrop(SkillType skillType, int amount, Vector2 origin)
    {
        if (!IsLocal)
        {
            return;
        }
  
        ActiveXPDrops.Add(new UIXPDrop()
        {
            Skill = GetSkillFromType(skillType),
            Amount = amount,
            Origin = origin,
            Direction = new Vector2(Random.Shared.NextFloat(-0.5f, 0.5f), Random.Shared.NextFloat(0.9f, 1.1f)).Normalized,
        });
    }

    public void CreatePopupMessage(Vector2 origin, string message)
    {
        if (!IsLocal)
        {
            return;
        }
  
        ActivePopupMessages.Add(new PopUpMessage()
        {
            Message = message,
            Origin = origin,
        });
    }
} 

public class PopUpMessage
{
    public string Message;
    public float TimeAlive;
    public Vector2 Origin;
}

public class UIXPDrop
{
    public Skill Skill;
    public int Amount;
    public float TimeAlive;
    public Vector2 Origin;
    public Vector2 Direction;
}

public static class ZoomSliderUI
{
	public static float DrawRightZoomSlider(float currentZoom, float minZoom, float maxZoom, out bool changed)
	{
		var panel = UI.SafeRect.RightCenterRect().Grow(160, 0, 160, 80).Offset(-10, 0);
		return DrawVerticalSliderWithButtons("zoom_slider", panel, currentZoom, minZoom, maxZoom, out changed);
	}

	private static float DrawVerticalSliderWithButtons(string id, Rect rect, float value, float min, float max, out bool changed)
	{
		changed = false;
		if (max <= min) return value;

		// Background
		UI.Image(rect, Assets.GetAsset<Texture>("Sprites/barzoom.png"), new Vector4(1, 1, 1, 1f));

		// this is the center of the zoom slider (green part)
		var track = rect.Inset(80, 24, 50, 24).Offset(0, 10);

		var ir = UI.InvisibleButton(track, id);
		float handleRadiusDraw = 12f;
		if (ir.Active || ir.Pressed || ir.JustPressed)
		{
			float y = ir.MousePosition.Y;
			float usableMinY = track.Min.Y + handleRadiusDraw;
			float usableMaxY = track.Max.Y - handleRadiusDraw;
			float usableHeight = Math.Max(1f, usableMaxY - usableMinY);
			// float t = (y - usableMinY) / usableHeight; down to zoom in
			float t = 1f - ((y - usableMinY) / usableHeight);
			t = Math.Clamp(t, 0f, 1f);
			value = min + (max - min) * t;
			changed = true;
		}

        //float curT = Math.Clamp((value - min) / (max - min), 0f, 1f); down to zoom in
		float curT = 1f - Math.Clamp((value - min) / (max - min), 0f, 1f);
	
		float drawMinY = track.Min.Y + handleRadiusDraw;
		float drawMaxY = track.Max.Y - handleRadiusDraw;
		float drawHeight = Math.Max(1f, drawMaxY - drawMinY);
		float yCenter = drawMinY + curT * drawHeight;

		var handle = new Rect(
			new Vector2(track.Center.X, yCenter),
			new Vector2(track.Center.X, yCenter)
		).Grow(handleRadiusDraw);

		var handle2 = new Rect(
			new Vector2(track.Center.X - handle.Width, yCenter - handle.Height),
			new Vector2(track.Center.X + handle.Width, yCenter + handle.Height)
		);

		UI.Image(handle2, Assets.GetAsset<Texture>("Sprites/barzoommiddle.png"), new Vector4(1f, 1f, 1f, 0.98f));
		return value;
	}

	// [UIPreview]
	// public static void Preview()
	// {
	// 	float dummy = 0.9f;
	// 	DrawRightZoomSlider(dummy, 0.5f, 1.4f, out _);
	// }
}