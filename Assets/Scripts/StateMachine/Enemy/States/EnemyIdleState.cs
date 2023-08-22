public class EnemyIdleState : EnemyState
{
    public override void Enter()
    {
        base.Enter();

        EnemyController.StartIdling();
    }

    public override void Exit()
    {
        base.Exit();

        EnemyController.StopIdling();
    }
}