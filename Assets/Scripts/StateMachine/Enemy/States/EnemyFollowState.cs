public class EnemyFollowState : EnemyState
{
    public override void Enter()
    {
        base.Enter();

        EnemyController.SwitchFollowingState(true);
    }

    public override void Exit()
    {
        base.Exit();

        EnemyController.SwitchFollowingState(false);
    }
}
