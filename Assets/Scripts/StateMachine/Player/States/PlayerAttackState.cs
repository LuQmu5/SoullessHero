using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public override void Enter()
    {
        AnimationNameExtension = Random.Range(1, 3).ToString();

        base.Enter();

        PlayerController.Attack();
        PlayerController.StopMovement();
    }
}