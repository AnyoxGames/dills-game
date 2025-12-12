using System.Reflection;
using AO;

namespace Assembly.scripts;

public class GameManager : Component
{
    public ulong GlobalRng = 123124123512L;
    
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                foreach (var component in Scene.Components<GameManager>())
                {
                    _instance = component;
                    _instance.Awaken();
                    break;
                }
            }
            return _instance;
        }
    }

    [Serialized] public Entity InitialSpawn;
    
    private readonly List<HitsplatData> ActiveHitsplats = new();
    
    public override void Awake()
    {
        GameItems.Init();
        Mob.InitDropTables(GameItems.Instance);
        
        var craftingStation = typeof(ACraftingStation).GetField(nameof(ACraftingStation.AllRecipes));
        
        if (craftingStation == null)
        {
            throw new NullReferenceException($"Could not find static property \"{nameof(ACraftingStation.AllRecipes)}\"");
        }
        
        Dictionary<Type, List<Recipe>> allRecipies = new();
        
        foreach (var type in typeof(ACraftingStation).Assembly.GetTypes())
        {
            if (type.IsSubclassOf(typeof(ACraftingStation)))
            {
                allRecipies.Add(type, new List<Recipe>());
                
                var methodInfo = type.GetMethod("InitRecipes");
                methodInfo.Invoke(null, [allRecipies[type]]);
            }
        }
        
        craftingStation.SetValue(null, allRecipies);
    }
    
    public override void Update()
    {
        if (Network.IsClient)
        {
            ProcessHitsplats();
        }
    }

    public void AddHitsplat(Vector2 startPosition, HitsplatType type, string line1, string line2 = null, Vector4 color = default, Vector4 outlineColor = default, string sound = null, string sprite = null, float spriteScale = 1f, float? yDir = null, float? xDir = null, Vector2 spriteOffset = default)
    {
        switch (type)
        {
            case HitsplatType.Damage:
                Internal_AddHitsplat(startPosition, Vector4.Red, Vector4.Black, line1, sound: sound, sprite: "Sprites/Hitsplats/Damage.png");
                break;
            case HitsplatType.Critical:
                Internal_AddHitsplat(startPosition, Vector4.Red, Vector4.Black, "Crit!", line2: line1, sound: "SFX/critical_hit.wav", sprite: "Sprites/Hitsplats/Critical.png");
                break;
            default:
                Internal_AddHitsplat(startPosition, color, outlineColor, line1, line2, sound, sprite, spriteScale, yDir, xDir, spriteOffset);
                break;
        }
    }

    private void Internal_AddHitsplat(Vector2 startPosition, Vector4 color, Vector4 outlineColor, string line1, string line2 = null, string sound = null, string sprite = null, float spriteScale = 1f, float? yDir = null, float? xDir = null, Vector2? spriteOffset = null)
    {
        var pulseText = new HitsplatData
        {
            Line = line1,
            Line2 = line2,
            Sprite = sprite,
            SpriteScale = spriteScale,
            Outline = outlineColor,
            Position = startPosition,
            Color = color,
            Time = 0
        };

        if (spriteOffset.HasValue)
        {
            pulseText.SpriteOffset = spriteOffset.Value;
        }
        
        if (yDir.HasValue)
        {
            pulseText.YDir = yDir.Value;
        }

        if (xDir.HasValue)
        {
            pulseText.XDir = xDir.Value;
        }
        
        ActiveHitsplats.Add(pulseText);
        
        if (!sound.IsNullOrEmpty())
        {
            SFX.Play(Assets.GetAsset<AudioAsset>(sound), new(){ Position = startPosition, Positional = true, SpeedPerturb = 0.2f });
        }
    }

    private void ProcessHitsplats()
    {
        using var _1 = UI.PUSH_CONTEXT(UI.Context.World);
            
        var ts = MyUI.GetTextSettings(0.55f);
        for (int i = ActiveHitsplats.Count-1; i >= 0; i -= 1)
        {
            var result = ActiveHitsplats[i];
            result.Time += Time.DeltaTime * 0.75f;
            if (result.Time >= 0.75f)
            {
                ActiveHitsplats.UnorderedRemoveAt(i);
                continue;
            }
                
            using var _2 = UI.PUSH_LAYER(500 - (int)(result.Time));
                
            var pos = result.Position;
            pos.Y += AOMath.Lerp(0, result.YDir, Ease.OutQuart(result.Time));
            pos.X += AOMath.Lerp(0, result.XDir, Ease.OutQuart(result.Time));
                
            var rect = new Rect(pos, pos);
            ts.OutlineColor = result.Outline;
            ts.Color = result.Color;
            ts.Size = 0.55f * Ease.OutElastic(Math.Clamp(result.Time * 2f, 0f, 1f));

            if (!result.Sprite.IsNullOrEmpty())
            {
                var asset = Assets.GetAsset<Texture>(result.Sprite);
                UI.Image(rect.FitAspect(asset.Aspect).Offset(result.SpriteOffset.X, result.SpriteOffset.Y).Grow(0.5f * result.SpriteScale * Ease.OutElastic(Math.Clamp(result.Time * 2f, 0f, 1f))), asset);
            }

            if (result.Line2.IsNullOrEmpty())
            {
                UI.TextAsync(rect, result.Line, ts);
            }
            else
            {
                UI.TextAsync(rect.Offset(0, 0.2f), result.Line, ts);
                UI.TextAsync(rect.Offset(0, -0.2f), result.Line2, ts);
            }
        }
    }
}

public abstract class MyEffect : AEffect
{
    public new MyPlayer Player => (MyPlayer)base.Player;
    public new MyPlayer Caster => (MyPlayer)base.Caster;
}

public abstract class MyAbility : Ability
{
    public new MyPlayer Player => (MyPlayer)base.Player;

    public override bool CanTarget(Player p)
    {
        return true;
    }

    public override bool CanUse()
    {
        return true;
    }
}

public enum HitsplatType
{
    None = 0,
    Damage = 1,
    Critical = 2,
    Poison = 3,
    Burn = 4,
    Venom = 5,
}

public class HitsplatData
{
    public string  Line;
    public Vector2 Position;
    public Vector4 Color;
    public Vector4 Outline = Vector4.Black;
    public float   Time;
    public float   XDir = Random.Shared.NextFloat(-0.5f, 0.5f);
    public float   YDir = 0.5f;
    public string  Sprite;
    public float   SpriteScale;
    public Vector2 SpriteOffset;
    public string  Line2;
}

public class Recipe
{
    public string Name;
    public string Action;
    public string Sound;
    public (SkillType, int)[] Requirements;
    public (SkillType, int)[] XPGranted;
    public (Item_Definition, int)[] Ingredients;
    public (Item_Definition, int)[] Result;

    public bool TryProcess(MyPlayer player)
    {
        if (!player.ServerCheckRequirements(Requirements.ToList(), Action))
        {
            return false;
        }
     
        foreach (var recipeIngredient in Ingredients)
        {
            long count = player.GetItemCount(recipeIngredient.Item1);

            if (count < recipeIngredient.Item2)
            {
                player.ServerSendNotification($"You don't have enough {recipeIngredient.Item1.Name} for that");
                return false;
            }
        }

        List<Item_Definition> resultItems = new();
        foreach (var result in Result)
        {
            resultItems.Add(result.Item1);
        }
        
        if (!player.CanInventoryTakeItems(resultItems.ToArray()))
        {
            player.ServerSendNotification($"Inventory is full, You cannot craft that!");
            return false;
        }
        
        foreach (var recipeIngredient in Ingredients)
        {
            player.ServerConsumeItemWithCount(recipeIngredient.Item1, recipeIngredient.Item2);
        }
        
        foreach (var recipeResult in Result)
        {
            player.ServerTryAddItem(recipeResult.Item1, recipeResult.Item2);
        }

        foreach (var recipeXpGrant in XPGranted)
        {
            player.GetSkillFromType(recipeXpGrant.Item1).ServerAwardXp(recipeXpGrant.Item2);
        }
        
        return true;
    }
}

public class GameManagerSystem : System<GameManagerSystem>
{
    public override void Awake()
    {
        //if (!Network.IsServer && Game.GetGameID() == GameManager.GAME_ID_MAIN_GAME)
        //{
        //    Analytics.EnableAutomaticAnalytics("bc9f00999f786c6bb0049a1b8cc7e031", "4a848bd3dd91f8907549e4fcb193c61beadb75b5");
        //}

        if (!Game.IsMobile)
        {
            Keybinds.OverrideKeybindDefault("Ability 1", Input.UnifiedInput.KEYCODE_SPACE);
        }
    }
}