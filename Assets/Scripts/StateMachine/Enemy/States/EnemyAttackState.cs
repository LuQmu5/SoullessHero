public class EnemyAttackState : EnemyState
{
    public override void Enter()
    {
        base.Enter();

        EnemyController.StartAttacking();
    }

    public override void Exit()
    {
        base.Exit();

        EnemyController.StopAttacking();
    }
}