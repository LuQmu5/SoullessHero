﻿using UnityEngine;

public class RunTransition : Transition
{
    protected override void OnEnable()
    {
        base.OnEnable();

        PlayerInput.MoveKeyPressing += OnMoveKeyPressing;
    }

    private void OnDisable()
    {
        PlayerInput.MoveKeyPressing -= OnMoveKeyPressing;
    }

    private void OnMoveKeyPressing(Vector2 direction)
    {
        if (direction != Vector2.zero && PlayerController.OnGround)
            NeedTransit = true;
    }
}