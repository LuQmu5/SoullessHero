public class PlayerDashTransition : PlayerTransition
{
    protected override void OnEnable()
    {
        base.OnEnable();

        PlayerInput.DashKeyPressed += OnDashKeyPressed;
    }

    private void OnDisable()
    {
        PlayerInput.DashKeyPressed -= OnDashKeyPressed;
    }

    private void OnDashKeyPressed()
    {
        if (PlayerController.CanDash)
            NeedTransit = true;
    }
}
