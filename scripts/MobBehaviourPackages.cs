using AO;

namespace Assembly.scripts;

public static class BehaviourPackages
{
    public static void IdlePackage(this Mob mob, float min = 2f, float high = 6f)
    {
        if (mob.TryOverridePackages()) return;

        mob.ServerSetBehaviour(new IdleBehaviour { Time = Random.Shared.NextFloat(min, high) });
    }

    public static void RoamAroundSpawnPackage(this Mob mob, float roamRange = 2f, float idleMin = 2f, float idleHigh = 6f)
    {
        if (mob.TryOverridePackages()) return;

        if (mob.ServerCurrentBehaviour is MoveToDestinationBehaviour)
        {
            mob.ServerSetBehaviour(new IdleBehaviour { Time = Random.Shared.NextFloat(idleMin, idleHigh) });
            return;
        }

        mob.ServerSetBehaviour(new MoveToDestinationBehaviour { Destination = mob.InitialPosition + MyUtil.RandomPosition(roamRange) });
    }

    private static bool TryOverridePackages(this Mob mob)
    {
        return false;
    }
}