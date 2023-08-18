public class PlayerDashState : PlayerState
{
    public override void Enter()
    {
        base.Enter();

        PlayerController.Dash();
    }
}