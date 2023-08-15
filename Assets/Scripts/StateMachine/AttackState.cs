public class AttackState : State
{
    private void Start()
    {
        print("qq");
    }
    public override void Enter()
    {
        base.Enter();

        PlayerController.Attack();
    }
}