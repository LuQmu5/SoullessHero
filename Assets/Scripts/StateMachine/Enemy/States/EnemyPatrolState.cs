public class EnemyPatrolState : EnemyState
{
    public override void Enter()
    {
        base.Enter();

        EnemyController.StartPatroling();
    }

    public override void Exit()
    {
        base.Exit();

        EnemyController.StopPatroling();
    }
}