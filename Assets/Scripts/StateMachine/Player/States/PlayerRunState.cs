using UnityEngine;

public class PlayerRunState : PlayerState
{
    public override void Enter()
    {
        base.Enter();

        PlayerInput.MoveKeyPressing += OnMoveKeyPressing;
    }

    public override void Exit()
    {
        base.Exit();

        PlayerController.StopMovement();
        PlayerInput.MoveKeyPressing -= OnMoveKeyPressing;
    }

    private void OnMoveKeyPressing(Vector2 direction)
    {
        PlayerController.Move(direction);
    }
}