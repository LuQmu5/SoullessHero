public class PlayerAttackState : PlayerState
{
    public override void Enter()
    {
        base.Enter();

        PlayerController.Attack();
    }
}