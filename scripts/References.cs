using AO;

namespace Assembly.scripts;

public class References : Component
{
    private static References _instance;
    public static References Instance
    {
        get
        {
            if (_instance == null)
            {
                foreach (var component in Scene.Components<References>())
                {
                    _instance = component;
                    _instance.Awaken();
                    break;
                }
            }
            return _instance;
        }
    }

    [Serialized] public Prefab ItemPickupPrefab;
}