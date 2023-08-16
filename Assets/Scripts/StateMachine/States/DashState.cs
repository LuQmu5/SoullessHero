public class DashState : State
{
    public override void Enter()
    {
        base.Enter();

        PlayerController.Dash();
    }
}