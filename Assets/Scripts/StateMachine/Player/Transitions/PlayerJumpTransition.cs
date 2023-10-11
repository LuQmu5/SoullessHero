public class PlayerJumpTransition : PlayerTransition
{
    protected override void OnEnable()
    {
        base.OnEnable();

        PlayerInput.JumpKeyPressed += OnJumpKeyPressed;
    }

    private void OnDisable()
    {
        PlayerInput.JumpKeyPressed -= OnJumpKeyPressed;
    }

    private void OnJumpKeyPressed()
    {
        if (Controller.OnGround)
            NeedTransit = true;
    }
}
