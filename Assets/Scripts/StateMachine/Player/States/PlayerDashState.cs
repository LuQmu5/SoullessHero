public class PlayerDashState : PlayerState
{
    public override void Enter()
    {
        base.Enter();

        Controller.Dash();
    }
}