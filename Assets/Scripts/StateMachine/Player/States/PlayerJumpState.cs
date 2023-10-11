using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public override void Enter()
    {
        base.Enter();

        Controller.Jump();
        PlayerInput.MoveKeyPressing += OnMoveKeyPressing;
    }

    public override void Exit()
    {
        base.Exit();

        PlayerInput.MoveKeyPressing -= OnMoveKeyPressing;
    }

    private void OnMoveKeyPressing(Vector2 direction)
    {
        Controller.Move(direction);
    }
}
