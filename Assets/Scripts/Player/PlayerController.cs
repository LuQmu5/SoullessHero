using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerCombat))]
[RequireComponent(typeof(CharacterAnimator))]
[RequireComponent(typeof(Health))]
public class PlayerController : MonoBehaviour
{
    [Header("Combat Properties")]
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange;

    [Header("Movement Properties")]
    [SerializeField] private Transform _legs;
    [SerializeField] private LayerMask _groundMask;

    private PlayerMover _mover;
    private PlayerCombat _combat;
    private CharacterAnimator _animator;
    private Health _health;

    public Vector2 Velocity => _mover.Velocity;
    public bool IsAttacking => _combat.IsAttacking;
    public bool CanDash => _mover.CanDash;
    public bool OnGround => _mover.OnGround;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _combat = GetComponent<PlayerCombat>();
        _animator = GetComponent<CharacterAnimator>();
        _health = GetComponent<Health>();

        _mover.Init(_legs, _groundMask);
        _combat.Init(_attackPoint, _animator, _attackRange);
        _health.Init(PlayerStats.MaxHealth);
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

    public void Dash()
    {
        _mover.Dash();
    }

    public void StopMovement()
    {
        _mover.StopMovement();
    }
}