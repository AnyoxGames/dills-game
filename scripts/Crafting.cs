using AO;

namespace Assembly.scripts;

public abstract partial class ACraftingStation : Component
{
    public static Dictionary<Type, List<Recipe>> AllRecipes;
    
    [Serialized] public Interactable Interactable;
    
    public abstract string WindowName { get; }
    
    public override void Awake()
    {
        Interactable.OnInteract += p =>
        {
            p.AddEffect<Effect_Crafting>(preInit: e =>
            {
                e.CraftingStation = this;
                e.StationEntity = Entity;
            });
        };
    }
    
    public virtual void LocalRequestProcess(MyPlayer player, int recipeIndex) => CallServer_RequestProcess(player, recipeIndex);
    [ServerRpc]
    public void RequestProcess(MyPlayer player, int recipeIndex) => ServerProcessRecipe(player, AllRecipes[GetType()][recipeIndex], recipeIndex);

    protected virtual bool ServerProcessRecipe(MyPlayer player, Recipe recipe, int recipeIndex)
    {
        if (recipe.TryProcess(player))
        {
            CallClient_OnRecipeProcessed(recipeIndex, new RPCOptions() { Target = player });
            return true;
        }

        return false;
    }

    [ClientRpc]
    public void OnRecipeProcessed(int recipeIndex) => LocalOnRecipeProcessed(AllRecipes[GetType()][recipeIndex]);

    protected abstract void LocalOnRecipeProcessed(Recipe recipe);
}

public partial class Anvil : ACraftingStation
{
    public override string WindowName => "Smithing";

    public static void InitRecipes(List<Recipe> recipes)
    {
        recipes.Add(new() { Name = "Iron Sword",  Action = "smith", Sound = "SFX/smith.wav", Requirements = new[] { (SkillType.Crafting, 5) }, XPGranted = new[] { (SkillType.Crafting, 30)  }, Ingredients = new[] { (GameItems.Instance.IronIngot, 1) },     Result = new [] { (GameItems.Instance.IronSword,  1)}});
        recipes.Add(new() { Name = "Iron Helmet", Action = "smith", Sound = "SFX/smith.wav", Requirements = new[] { (SkillType.Crafting, 7) }, XPGranted = new[] { (SkillType.Crafting, 60)  }, Ingredients = new[] { (GameItems.Instance.IronIngot, 2) },     Result = new [] { (GameItems.Instance.IronHelmet, 1)}});
        recipes.Add(new() { Name = "Iron Armor",  Action = "smith", Sound = "SFX/smith.wav", Requirements = new[] { (SkillType.Crafting, 9) }, XPGranted = new[] { (SkillType.Crafting, 120) }, Ingredients = new[] { (GameItems.Instance.IronIngot, 4) },     Result = new [] { (GameItems.Instance.IronArmor,  1)}});
        
        recipes.Add(new() { Name = "Steel Sword",  Action = "smith", Sound = "SFX/smith.wav", Requirements = new[] { (SkillType.Crafting, 20) }, XPGranted = new[] { (SkillType.Crafting, 50)  }, Ingredients = new[] { (GameItems.Instance.SteelIngot, 1) },   Result = new [] { (GameItems.Instance.SteelSword,  1)}});
        recipes.Add(new() { Name = "Steel Helmet", Action = "smith", Sound = "SFX/smith.wav", Requirements = new[] { (SkillType.Crafting, 25) }, XPGranted = new[] { (SkillType.Crafting, 100) }, Ingredients = new[] { (GameItems.Instance.SteelIngot, 2) },   Result = new [] { (GameItems.Instance.SteelHelmet, 1)}});
        recipes.Add(new() { Name = "Steel Armor",  Action = "smith", Sound = "SFX/smith.wav", Requirements = new[] { (SkillType.Crafting, 29) }, XPGranted = new[] { (SkillType.Crafting, 200) }, Ingredients = new[] { (GameItems.Instance.SteelIngot, 4) },   Result = new [] { (GameItems.Instance.SteelArmor,  1)}});
        
        recipes.Add(new() { Name = "Mithril Sword", Action = "smith", Sound = "SFX/smith.wav", Requirements = new[] { (SkillType.Crafting, 30) }, XPGranted = new[] { (SkillType.Crafting, 80)  }, Ingredients = new[] { (GameItems.Instance.MithrilIngot, 1) }, Result = new [] { (GameItems.Instance.MithrilSword, 1)}});
        recipes.Add(new() { Name = "Mithril Helmet",Action = "smith", Sound = "SFX/smith.wav", Requirements = new[] { (SkillType.Crafting, 35) }, XPGranted = new[] { (SkillType.Crafting, 160) }, Ingredients = new[] { (GameItems.Instance.MithrilIngot, 2) }, Result = new [] { (GameItems.Instance.MithrilHelmet, 1)}});
        recipes.Add(new() { Name = "Mithril Armor", Action = "smith", Sound = "SFX/smith.wav", Requirements = new[] { (SkillType.Crafting, 39) }, XPGranted = new[] { (SkillType.Crafting, 320) }, Ingredients = new[] { (GameItems.Instance.MithrilIngot, 4) }, Result = new [] { (GameItems.Instance.MithrilArmor, 1)}});
        
        recipes.Add(new() { Name = "Barsate Sword",  Action = "smith", Sound = "SFX/smith.wav", Requirements = new[] { (SkillType.Crafting, 40) }, XPGranted = new[] { (SkillType.Crafting, 128) }, Ingredients = new[] { (GameItems.Instance.BarsateIngot, 1) }, Result = new [] { (GameItems.Instance.BarsateSword,  1)}});
        recipes.Add(new() { Name = "Barsate Helmet", Action = "smith", Sound = "SFX/smith.wav", Requirements = new[] { (SkillType.Crafting, 45) }, XPGranted = new[] { (SkillType.Crafting, 256) }, Ingredients = new[] { (GameItems.Instance.BarsateIngot, 2) }, Result = new [] { (GameItems.Instance.BarsateHelmet, 1)}});
        recipes.Add(new() { Name = "Barsate Armor",  Action = "smith", Sound = "SFX/smith.wav", Requirements = new[] { (SkillType.Crafting, 49) }, XPGranted = new[] { (SkillType.Crafting, 512) }, Ingredients = new[] { (GameItems.Instance.BarsateIngot, 4) }, Result = new [] { (GameItems.Instance.BarsateArmor,  1)}});
        
        recipes.Add(new() { Name = "Runic Sword",  Action = "smith", Sound = "SFX/smith.wav", Requirements = new[] { (SkillType.Crafting, 50) }, XPGranted = new[] { (SkillType.Crafting, 204) }, Ingredients = new[] { (GameItems.Instance.RunicIngot, 1) },   Result = new [] { (GameItems.Instance.RunicSword,  1)}});
        recipes.Add(new() { Name = "Runic Helmet", Action = "smith", Sound = "SFX/smith.wav", Requirements = new[] { (SkillType.Crafting, 55) }, XPGranted = new[] { (SkillType.Crafting, 408) }, Ingredients = new[] { (GameItems.Instance.RunicIngot, 2) },   Result = new [] { (GameItems.Instance.RunicHelmet, 1)}});
        recipes.Add(new() { Name = "Runic Armor",  Action = "smith", Sound = "SFX/smith.wav", Requirements = new[] { (SkillType.Crafting, 59) }, XPGranted = new[] { (SkillType.Crafting, 816) }, Ingredients = new[] { (GameItems.Instance.RunicIngot, 4) },   Result = new [] { (GameItems.Instance.RunicArmor,  1)}});
    }

    protected override void LocalOnRecipeProcessed(Recipe recipe)
    {
        SFX.Play(Assets.GetAsset<AudioAsset>(recipe.Sound), new SFX.PlaySoundDesc() { Positional = false, Volume = 0.3f, Speed = Random.Shared.NextFloat(0.8f, 1.2f) });
    }
}

public partial class Fire : ACraftingStation
{
    [Serialized] public Spine_Animator Spine;
    public float ExpireTime;
    public float TimeAlive;
    public ulong LoopId;
    public bool PlayingLoop;
    
    public override string WindowName => "Cooking";
    
    public static void InitRecipes(List<Recipe> recipes)
    {
        recipes.Add(new() { Name = "Trout",   Action = "cook", Sound = "SFX/cook.wav", Requirements = [(SkillType.Crafting, 1)], XPGranted = [(SkillType.Crafting, 20)], Ingredients = [(GameItems.Instance.TroutRaw, 1)],   Result = [(GameItems.Instance.TroutCooked, 1)]   });
        recipes.Add(new() { Name = "Chicken", Action = "cook", Sound = "SFX/cook.wav", Requirements = [(SkillType.Crafting, 1)], XPGranted = [(SkillType.Crafting, 20)], Ingredients = [(GameItems.Instance.ChickenRaw, 1)], Result = [(GameItems.Instance.ChickenCooked, 1)] });
    }
    
    protected override void LocalOnRecipeProcessed(Recipe recipe)
    {
        SFX.Play(Assets.GetAsset<AudioAsset>(recipe.Sound), new SFX.PlaySoundDesc() { Positional = false, Volume = 0.3f, Speed = Random.Shared.NextFloat(0.8f, 1.2f) });
    }

    public override void Awake()
    {
        base.Awake();
        
        ExpireTime = Time.TimeSinceStartup + 30;
        
        var sm = StateMachine.Create();
        Spine.Awaken();
        Spine.SpineInstance.SetStateMachine(sm, false);
        var baseLayer = sm.CreateLayer("main");
        var idle = baseLayer.CreateState("Loop", 0, true);
        baseLayer.InitialState = baseLayer.CreateState("Spawn", 0, false);
        baseLayer.CreateTransition(baseLayer.InitialState, idle, true);
        baseLayer.CreateTransition(idle, baseLayer.CreateState("Despawn", 0, false), false).CreateTriggerCondition(sm.CreateVariable("outro", StateMachineVariableKind.TRIGGER));
        
        SFX.Play(Assets.GetAsset<AudioAsset>("SFX/fire_start.wav"), new SFX.PlaySoundDesc() { Positional = true, EntityToFollow = Entity, Volume = 0.25f });
    }

    public override void Update()
    {
        TimeAlive += Time.DeltaTime;
        if (Util.OneTime(TimeAlive > 0.96f, ref PlayingLoop))
        {
            LoopId = SFX.Play(Assets.GetAsset<AudioAsset>("SFX/fire_loop.wav"), new SFX.PlaySoundDesc() { Positional = true, EntityToFollow = Entity, Volume = 0.25f, Loop = true });
        }
        
        if (Time.TimeSinceStartup > ExpireTime)
        {
            Spine.SpineInstance.StateMachine.SetTrigger("outro");
            SFX.Play(Assets.GetAsset<AudioAsset>("SFX/fire_end.wav"), new SFX.PlaySoundDesc() { Positional = true, EntityToFollow = Entity, Volume = 0.25f });
            SFX.Stop(LoopId);
            
            if (Network.IsServer && ExpireTime - Time.TimeSinceStartup < -1)
            {
                GameItems.Instance.SpawnLootInstance(GameItems.Instance.AshPile, Entity.Position, true);
                Network.DespawnAndDestroy(Entity);
            }
        }
    }
}

public partial class Furnace : ACraftingStation
{
    public override string WindowName => "Smelting";

    public static void InitRecipes(List<Recipe> recipes)
    {
        recipes.Add(new() { Name = "Iron Ingot",    Action = "smelt", Sound = "SFX/smelt.wav", Requirements = new[] { (SkillType.Crafting, 1)  }, XPGranted = new[] { (SkillType.Crafting, 15) }, Ingredients = new[] { (GameItems.Instance.IronOre,    1) },                                                                      Result = new [] { (GameItems.Instance.IronIngot,    1)}});
        recipes.Add(new() { Name = "Steel Ingot",   Action = "smelt", Sound = "SFX/smelt.wav", Requirements = new[] { (SkillType.Crafting, 20) }, XPGranted = new[] { (SkillType.Crafting, 35) }, Ingredients = new[] { (GameItems.Instance.IronOre,    1), (GameItems.Instance.CoalOre, 1) },                                     Result = new [] { (GameItems.Instance.SteelIngot,   1)}});
        recipes.Add(new() { Name = "Mithril Ingot", Action = "smelt", Sound = "SFX/smelt.wav", Requirements = new[] { (SkillType.Crafting, 30) }, XPGranted = new[] { (SkillType.Crafting, 45) }, Ingredients = new[] { (GameItems.Instance.MithrilOre, 1), (GameItems.Instance.CoalOre, 2) },                                     Result = new [] { (GameItems.Instance.MithrilIngot, 1)}});
        recipes.Add(new() { Name = "Barsate Ingot", Action = "smelt", Sound = "SFX/smelt.wav", Requirements = new[] { (SkillType.Crafting, 40) }, XPGranted = new[] { (SkillType.Crafting, 55) }, Ingredients = new[] { (GameItems.Instance.BarsateOre, 1), (GameItems.Instance.CoalOre, 3) },                                     Result = new [] { (GameItems.Instance.BarsateIngot, 1)}});
        recipes.Add(new() { Name = "Runic Ingot",   Action = "smelt", Sound = "SFX/smelt.wav", Requirements = new[] { (SkillType.Crafting, 50) }, XPGranted = new[] { (SkillType.Crafting, 65) }, Ingredients = new[] { (GameItems.Instance.RunicOre,   1), (GameItems.Instance.BarsateOre, 1), (GameItems.Instance.CoalOre, 4) }, Result = new [] { (GameItems.Instance.RunicIngot,   1)}});
    } 
    
    protected override void LocalOnRecipeProcessed(Recipe recipe)
    {
        SFX.Play(Assets.GetAsset<AudioAsset>(recipe.Sound), new SFX.PlaySoundDesc() { Positional = false, Volume = 0.3f, Speed = Random.Shared.NextFloat(0.8f, 1.2f) });
    }
}

public partial class BrewingTable : ACraftingStation
{
    public override string WindowName => "Mixology";

    public static void InitRecipes(List<Recipe> recipes)
    {
        recipes.Add(new() { Name = "Swift Potion",    Action = "brew", Sound = "SFX/brew.wav", Requirements = [(SkillType.Mixology, 1)], XPGranted = [(SkillType.Mixology, 15)], Ingredients = [(GameItems.Instance.Feather, 1)], Result = [(GameItems.Instance.IronIngot,    1)] });
    } 
    
    protected override void LocalOnRecipeProcessed(Recipe recipe)
    {
        SFX.Play(Assets.GetAsset<AudioAsset>(recipe.Sound), new SFX.PlaySoundDesc() { Positional = false, Volume = 0.3f, Speed = Random.Shared.NextFloat(0.8f, 1.2f) });
    }
}