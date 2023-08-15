﻿using UnityEngine;

public class IdleTransition : Transition
{
    private void Update()
    {
        if (PlayerController.Velocity.sqrMagnitude < 0.1f && PlayerController.IsAttacking == false)
        {
            NeedTransit = true;
        }
    }
}