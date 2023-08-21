using UnityEngine;

public class PlayerFallState : PlayerState
{
    public override void Enter()
    {
        base.Enter();

        PlayerInput.MoveKeyPressing += OnMoveKeyPressing;
    }

    public override void Exit()
    {
        base.Exit();

        PlayerInput.MoveKeyPressing -= OnMoveKeyPressing;
    }

    /*
    private void FixedUpdate()
    {
        if (PlayerController.OnGround)
            PlayerInput.MoveKeyPressing -= OnMoveKeyPressing;
    }
    */

    private void OnMoveKeyPressing(Vector2 direction)
    {
        PlayerController.Move(direction);
    }
}
