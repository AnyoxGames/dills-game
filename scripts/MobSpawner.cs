using AO;

namespace Assembly.scripts;

public class MobSpawner : Component
{
    [Serialized] public Prefab MobPrefab;
    [Serialized] public float RespawnTime;

    private Entity Mob;
    private float RespawnTimeRemaining;
    
    public override void Awake()
    {
        if (Entity.TryGetComponent(out Sprite_Renderer renderer))
        {
            renderer.LocalEnabled = false;
        }
    }

    public override void Update()
    {
        if (Network.IsServer && Entity.LocalEnabled)
        {
            if (!Mob.Alive())
            {
                if (RespawnTimeRemaining > 0)
                {
                    RespawnTimeRemaining -= Time.DeltaTime;
                    return;
                }

                RespawnTimeRemaining = RespawnTime;
                Mob = Network.InstantiateAndSpawn(MobPrefab, e => e.Position = Entity.Position);
            }
        }
    }
}