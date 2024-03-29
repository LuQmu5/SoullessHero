﻿using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public static event UnityAction<Vector2> MoveKeyPressing;
    public static event UnityAction JumpKeyPressed;
    public static event UnityAction DashKeyPressed;
    public static event UnityAction AttackKeyPressed;
    public static event UnityAction CastKeyPressed;
    public static event UnityAction SwitchTargetKeyPressed;
    public static event UnityAction OpenSpellBookKeyPressed;

    private void Update()
    {
        CheckMoveKeysPressing();

        if (Input.GetKeyDown(KeyCode.B))
        {
            OpenSpellBookKeyPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpKeyPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashKeyPressed?.Invoke();
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            AttackKeyPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            CastKeyPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchTargetKeyPressed?.Invoke();
        }
    }

    private static void CheckMoveKeysPressing()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveKeyPressing?.Invoke(Vector2.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveKeyPressing?.Invoke(Vector2.right);
        }
        else
        {
            MoveKeyPressing?.Invoke(Vector2.zero);
        }
    }
}
