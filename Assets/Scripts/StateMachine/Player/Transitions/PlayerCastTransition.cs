public class PlayerCastTransition : PlayerTransition
{
    protected override void OnEnable()
    {
        base.OnEnable();

        PlayerInput.CastKeyPressed += OnCastKeyPressed;
    }

    private void OnDisable()
    {
        PlayerInput.CastKeyPressed -= OnCastKeyPressed;
    }

    private void OnCastKeyPressed()
    {
        NeedTransit = true;
    }
}
