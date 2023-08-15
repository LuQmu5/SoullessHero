using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerCombat _combat;
    [SerializeField] private PlayerAnimator _animator;

    [Header("Movement Settings")]
    [SerializeField] private Transform _legs;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _legsRadius = 0.1f;

    public Vector2 Velocity => _mover.Velocity;
    public bool IsAttacking => _combat.IsAttacking;
    public bool OnGround { get; private set; }

    private void FixedUpdate()
    {
        OnGround = Physics2D.OverlapCircle(_legs.position, _legsRadius, _groundMask);
    }

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
        _combat.Attack();
    }

    public void PlayAnimation(string name)
    {
        _animator.PlayAnimation(name);
    }
}
