public class AttackState : State
{
    public override void Enter()
    {
        base.Enter();

        PlayerController.Attack();
    }
}