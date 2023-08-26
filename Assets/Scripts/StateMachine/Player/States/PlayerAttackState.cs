using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public override void Enter()
    {
        int animationVariationsCount = 2;
        AnimationNameExtension = (Random.Range(0, animationVariationsCount) + 1).ToString();

        base.Enter();

        PlayerController.Attack();
        PlayerController.StopMovement();
    }
}