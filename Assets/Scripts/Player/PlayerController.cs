using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerCombat))]
[RequireComponent(typeof(CharacterAnimator))]
[RequireComponent(typeof(PlayerHealth))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private Transform _legs;
    [SerializeField] private LayerMask _groundMask;

    private PlayerMover _mover;
    private PlayerCombat _combat;
    private CharacterAnimator _animator;
    private PlayerHealth _health;

    public Vector2 Velocity => _mover.Velocity;
    public bool IsAttacking => _combat.IsAttacking;
    public bool CanDash => _mover.CanDash;
    public bool OnGround => _mover.OnGround;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _combat = GetComponent<PlayerCombat>();
        _animator = GetComponent<CharacterAnimator>();
        _health = GetComponent<PlayerHealth>();

        _mover.Init(_legs, _groundMask);
        _combat.Init(_attackPoint, _animator);
        _health.SetMaxHealth(PlayerAttributes.Instance.MaxHealth);
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
        PlayerAttributes.Instance.IncreaseAttributeTemporarily(AttributeNames.EvasionChance, PlayerConstants.MaxEvasionChance, PlayerConstants.BaseDashDuration);
    }

    public void StopMovement()
    {
        _mover.StopMovement();
    }
}