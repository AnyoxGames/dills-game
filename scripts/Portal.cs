using AO;

public class Portal : Component
{
    [Serialized] public Portal Destination;
    [Serialized] public Entity ExitAnchor;
    [Serialized] public Interactable Interactable;

    public override void Awake()
    {
        Interactable.OnInteract += p =>
        {
            if (!Network.IsServer)
                return;

            var player = (MyPlayer)p;
            player.MovePlayer(Destination.ExitAnchor.Position);
        };
    }
}