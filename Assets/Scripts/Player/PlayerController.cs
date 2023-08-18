using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerCombat _combat;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private PlayerCollisionHandler _collisionHandler;

    public Vector2 Velocity => _mover.Velocity;
    public bool IsAttacking => _combat.IsAttacking;
    public bool CanDash => _mover.CanDash;
    public bool OnGround => _mover.OnGround;

    public void Move(Vector2 direction)
    {
        _mover.Move(direction);
    }

    public void Jump()
    {
        _mover.Jump();
    }

    public void Attack()
    {
        _combat.Attack(_animator);
    }

    public void PlayAnimation(string name)
    {
        _animator.PlayAnimation(name);
    }

    public void Dash()
    {
        _mover.Dash();
    }
}