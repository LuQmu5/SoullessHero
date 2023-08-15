using UnityEngine;

public class JumpState : State
{
    private void Start()
    {
        print("qq");
    }

    public override void Enter()
    {
        base.Enter();

        PlayerController.Jump();
        PlayerInput.MoveKeyPressing += OnMoveKeyPressing;
    }

    public override void Exit()
    {
        base.Exit();

        PlayerInput.MoveKeyPressing -= OnMoveKeyPressing;
    }

    private void OnMoveKeyPressing(Vector2 direction)
    {
        PlayerController.Move(direction);
    }
}
