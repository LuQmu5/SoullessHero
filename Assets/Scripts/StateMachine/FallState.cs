using UnityEngine;

public class FallState : State
{
    private void Start()
    {
        print("qq");
    }

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

    private void OnMoveKeyPressing(Vector2 direction)
    {
        PlayerController.Move(direction);
    }
}