public class AttackTransition : Transition
{
    protected override void OnEnable()
    {
        base.OnEnable();

        PlayerInput.AttackKeyPressed += OnAttackKeyPressed;
    }

    private void OnDisable()
    {
        PlayerInput.AttackKeyPressed -= OnAttackKeyPressed;
    }

    private void OnAttackKeyPressed()
    {
        NeedTransit = true;
    }
}
