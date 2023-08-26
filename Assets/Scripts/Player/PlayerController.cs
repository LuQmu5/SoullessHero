using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerCombat _combat;
    [SerializeField] private CharacterAnimator _animator;

    [Header("Combat Properties")]
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange;

    [Header("Movement Properties")]
    [SerializeField] private Transform _legs;
    [SerializeField] private LayerMask _groundMask;

    public Vector2 Velocity => _mover.Velocity;
    public bool IsAttacking => _combat.IsAttacking;
    public bool CanDash => _mover.CanDash;
    public bool OnGround => _mover.OnGround;

    private void Awake()
    {
        _mover.Init(_legs, _groundMask);
        _combat.Init(_attackPoint, _attackRange);
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

    public void StopMovement()
    {
        _mover.StopMovement();
    }
}