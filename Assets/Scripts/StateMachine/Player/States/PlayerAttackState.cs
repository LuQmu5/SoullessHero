using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public override void Enter()
    {
        int animationVariationsCount = 2;
        AnimationNameExtension = (Random.Range(0, animationVariationsCount) + 1).ToString();

        base.Enter();

        Controller.Attack();
        Controller.StopMovement();
    }
}
