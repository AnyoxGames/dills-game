using AO;

namespace Assembly.scripts;

public class FleeBehaviour : AIBehaviour
{
    private MyPlayer FleeFrom;
    private float NextDestinationCalculation;

    public FleeBehaviour(MyPlayer fleeFrom)
    {
        FleeFrom = fleeFrom;
    }

    public override void OnStarted()
    {
        CalculateNextDestination();
    }

    protected override void Update()
    {
        if (!FleeFrom.Alive() || Vector2.Distance(FleeFrom.Entity.Position, Mob.Entity.Position) > 10)
        {
            CompleteBehaviour();
            return;
        }
        
        if (TimeElapsed > NextDestinationCalculation)
        {
            CalculateNextDestination();
        }
    }

    private void CalculateNextDestination()
    {
        var dir = (Mob.Entity.Position - FleeFrom.Entity.Position).Normalized;
        Mob.Agent.NavmeshToLockTo.TryFindClosestPointOnNavmesh(Mob.Entity.Position + dir * 4, out var destination);
        Mob.Destination.Set(destination);
        NextDestinationCalculation = TimeElapsed + 1f;
    }
}