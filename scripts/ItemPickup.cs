using AO;
using Assembly.scripts;

public partial class ItemPickup : Component
{
    public enum LerpType
    {
        Lob,
        Linear,
    }
    
    public virtual int BaseAmount => 1;
    public virtual int Amount => AmountOverride ?? BaseAmount;

    public Action<ItemPickup> OnPickedUp;

    [Serialized] public Interactable Interactable;
    [Serialized] public Sprite_Renderer ItemSprite;
    [Serialized] public Sprite_Renderer ShineSprite;
    
    public Sprite_Renderer InnerShineSprite;

    private float TimeSpawnedAt;
    private Player LockedOwner; // Useful if we want to prevent other players from picking up the item (ex: from the forge)

    public int? AmountOverride;
    
    private float LerpTime;
    private float MaxLerpTime;
    private Vector2 LerpStart;
    private Vector2 LerpEnd;
    private LerpType UseLerpType;
    private bool MarkedForDestroy;
    private float DestroyTimer;
    
    public const float ARC_MAX_HEIGHT = 0.35f;

    public Item_Definition Item;
    
    public override void Awake()
    {
        base.Awake();

        Interactable.CanUseCallback += p => LerpTime >= MaxLerpTime && !MarkedForDestroy && CheckIfPlayerCanPickUp((MyPlayer)p);
        Interactable.OnInteract += OnInteract;

        TimeSpawnedAt = Time.TimeSinceStartup;

        //SFX.Play(Assets.GetAsset<AudioAsset>("sounds/drop_item.wav"), new SFX.PlaySoundDesc() { EntityToFollow = Entity, SpeedPerturb = 0.1f });
    }
    
    [ClientRpc]
    public void LerpItem(Vector2 fromLocation, Vector2 toLocation, float time, LerpType type)
    {
        LerpTime = 0;
        MaxLerpTime = time;
        LerpStart = fromLocation;
        LerpEnd = toLocation;
        UseLerpType = type;
    }

    [ClientRpc]
    public void MoveToPosition(Vector2 position)
    {
        Entity.Position = position;
    }

    [ClientRpc]
    public void Setup(string item_id)
    {
        foreach (var itemDef in GameItems.Instance.AllItems)
        {
            if (itemDef.Id == item_id)
            {
                Item = itemDef;
            }
        }
        
        ShineSprite.Tint = MyUtil.GetColorForRarity(GameItems.Instance.GetDefaultRarityForItemDefinition(Item));
        InnerShineSprite = Entity.Create().AddComponent<Sprite_Renderer>();
        InnerShineSprite.Entity.SetParent(ShineSprite.Entity, false);
        InnerShineSprite.Sprite = ShineSprite.Sprite;
        InnerShineSprite.Entity.Scale = ShineSprite.Entity.Scale * 0.5f;
        InnerShineSprite.Tint = new Vector4(MathF.Min(ShineSprite.Tint.X * 2, 1f), MathF.Min(ShineSprite.Tint.Y * 2, 1f), MathF.Min(ShineSprite.Tint.Z * 2, 1f), 1f);
        ItemSprite.Sprite = Assets.GetAsset<Texture>(Item.Icon);
    }

    [ClientRpc]
    public void SetAmountOverride(int amount)
    {
        AmountOverride = amount;
    }

    [ClientRpc]
    public void SetLockedOwner(Player player)
    {
        LockedOwner = player;
    }

    public bool CheckIfPlayerCanPickUp(MyPlayer player)
    {
        return !LockedOwner.Alive() || LockedOwner == player;
    }
    
    public override void Update()
    {
        if (Network.IsServer)
        {
            if (TimeSpawnedAt + 60 < Time.TimeSinceStartup && LerpTime >= MaxLerpTime)
            {
                MarkedForDestroy = true;
            }
            
            if (MarkedForDestroy)
            {
                DestroyTimer -= Time.DeltaTime;

                if (DestroyTimer <= 0)
                {
                    Network.Despawn(Entity);
                    Entity.Destroy();
                }
            }
        }

        if (Item != null)
        {
            Interactable.Text = $"Grab {Item.Name}";
            Interactable.PromptOffset = new Vector2(-Interactable.Text.Length / 2f * 0.1f, 1.5f);
        }

        var shineOffset = MathF.Sin(Time.TimeSinceStartup * 2f) * 0.15f + 0.15f;
        var spriteOffset = MathF.Sin(Time.TimeSinceStartup * 2f + 0.6f) * 0.15f + 0.15f;
        
        ShineSprite.Entity.Rotation = Time.TimeSinceStartup * 60;
        ShineSprite.Entity.LocalY = shineOffset;
        ItemSprite.Entity.LocalY = spriteOffset;
        ItemSprite.Entity.Rotation = MathF.Sin(Time.TimeSinceStartup * 2f) * 7 - 2.5f;

        ItemSprite.DepthOffset = -spriteOffset - 0.4f;
        ShineSprite.DepthOffset = -shineOffset + 0.1f;
        InnerShineSprite.DepthOffset = ShineSprite.DepthOffset - 0.2f;
        
        if (LerpTime < MaxLerpTime)
        {
            var ratio = LerpTime / MaxLerpTime;
            
            switch (UseLerpType)
            { 
                case LerpType.Lob:
                    var range = Vector2.Distance(LerpStart, LerpEnd);
                    var distanceTravelled = range * ratio;
                    if (distanceTravelled <= range)
                    {
                        var height = ParabolaArcHeight(ARC_MAX_HEIGHT * range, range, distanceTravelled);
                        ItemSprite.Entity.LocalY = height;
                        ShineSprite.Entity.LocalY = height;
                        ItemSprite.Entity.Rotation = 180 * ratio;
                    }
                    Entity.Position = Vector2.Lerp(LerpStart, LerpEnd, ratio);
                    break;
                default:
                    Entity.Position = Vector2.Lerp(LerpStart, LerpEnd, ratio);
                    break;
            }
            
            LerpTime += Time.DeltaTime;
            if (LerpTime >= MaxLerpTime)
            {
                Entity.Position = LerpEnd;
                ItemSprite.Entity.Rotation = 0;
            }
        }
    }
    
    public float ParabolaArcHeight(float height, float range, float x)
    {
        return -height * MathF.Pow(x / (0.5f * range) - 1, 2) + height;
    }
    
    public void OnInteract(Player player)
    {
        /*if (player.IsLocal)
        {
            // Use the same sound as when the player drops an item
            SFX.Play(Assets.GetAsset<AudioAsset>("sounds/drop_item.wav"), new SFX.PlaySoundDesc(){ SpeedPerturb = 0.1f });
        }*/

        if (!Network.IsServer) return;

        if (ServerTryGrantItem((MyPlayer)player))
        {
            DestroyTimer = 0.075f;

            MarkedForDestroy = true;
            LerpItem(Entity.Position, player.Position, 0.075f, LerpType.Linear);

            OnPickedUp?.Invoke(this);
        }
        else
        {
            var myPlayer = (MyPlayer)player;
            myPlayer.ServerSendNotification("You can't pick that up! Try clearing some space!");
        }
    }

    public virtual bool ServerTryGrantItem(MyPlayer player)
    {
        if (!Network.IsServer) return false;

        return player.ServerTryAddItem(Item, Amount);
    }
}