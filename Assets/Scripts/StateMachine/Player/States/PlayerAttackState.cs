using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public override void Enter()
    {
        base.Enter();

        PlayerController.Attack();
        PlayerController.StopMovement();
    }
}