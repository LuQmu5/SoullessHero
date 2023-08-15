using UnityEngine;

public class RunState : State
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

        PlayerController.Move(Vector2.zero);
        PlayerInput.MoveKeyPressing -= OnMoveKeyPressing;
    }

    private void OnMoveKeyPressing(Vector2 direction)
    {
        PlayerController.Move(direction);
    }
}