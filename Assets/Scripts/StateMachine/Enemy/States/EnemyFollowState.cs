public class EnemyFollowState : EnemyState
{
    public override void Enter()
    {
        base.Enter();

        EnemyController.StartFollowing();
    }

    public override void Exit()
    {
        base.Exit();

        EnemyController.StopFollowing();
    }
}