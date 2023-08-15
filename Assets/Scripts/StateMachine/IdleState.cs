using UnityEngine;

public class IdleState : State
{
    public override void Enter()
    {
        base.Enter();

        Debug.Log("Idle");
    }

    public override void Exit()
    {
        base.Exit();
    }
}
