public class PlayerCastState : PlayerState
{
    private void Start()
    {
        
    }

    public override void Enter()
    {
        base.Enter();

        Controller.TryCastSpell();
        Controller.StopMovement();
    }
}