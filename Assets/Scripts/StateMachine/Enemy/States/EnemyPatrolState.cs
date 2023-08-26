public class EnemyPatrolState : EnemyState
{
    public override void Enter()
    {
        base.Enter();

        EnemyController.SwitchPatrolingState(true);
    }

    public override void Exit()
    {
        base.Exit();

        EnemyController.SwitchPatrolingState(false);
    }
}
