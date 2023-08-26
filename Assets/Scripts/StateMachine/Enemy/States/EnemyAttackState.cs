public class EnemyAttackState : EnemyState
{
    public override void Enter()
    {
        base.Enter();

        EnemyController.SwitchAttackingState(true);
    }

    public override void Exit()
    {
        base.Exit();

        EnemyController.SwitchAttackingState(false);
    }
}
