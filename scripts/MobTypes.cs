using AO;

namespace Assembly.scripts;

public partial class Mob_Chicken : Mob
{
    protected override int CombatLevel => 1;
    protected override float MaxHealthMultiplier => 0.8f;
    public override string MobName => "Chicken";
    protected override string DeathSound => "SFX/chicken_death.wav";

    protected override void SetupSpine(StateMachine sm)
    {
        var layer = sm.CreateLayer("main");
        
        layer.InitialState = layer.CreateState("FUSE105/idle", 0, true);
        var move = layer.CreateState("FUSE105/run", 0, true);
        
        var moveBool = sm.CreateVariable("moving", StateMachineVariableKind.BOOLEAN);
        layer.CreateTransition(layer.InitialState, move, false).CreateBoolCondition(moveBool, true);
        layer.CreateTransition(move, layer.InitialState, false).CreateBoolCondition(moveBool, false);
    }

    public override void DecideNextAction()
    {
        this.RoamAroundSpawnPackage();
    }

    public override bool TryHit(int damage, HitsplatType splatType, MyPlayer source)
    {
        if (!base.TryHit(damage, splatType, source))
        {
            return false;
        }

        if (Network.IsServer)
        {
            ServerSetBehaviour(new FleeBehaviour(source));
        }

        return true;
    }
}