using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerCombat))]
[RequireComponent(typeof(PlayerMagic))]
[RequireComponent(typeof(CharacterAnimator))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(AttributesManager))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private Transform _legs;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private SpriteRenderer _targetMark;
    [SerializeField] private float _minDetectRange = 10;

    private AttributesManager _attributesManager;
    private PlayerMover _mover;
    private PlayerMagic _magic;
    private PlayerCombat _combat;
    private CharacterAnimator _animator;
    private PlayerTargetSystem _targetSystem;
    private Health _health;

    public Vector2 Velocity => _mover.Velocity;
    public bool IsAttacking => _combat.IsAttacking;
    public bool IsCasting => _magic.IsCasting;
    public bool CanDash => _mover.CanDash;
    public bool OnGround => _mover.OnGround;

    private void Awake()
    {
        _attributesManager = GetComponent<AttributesManager>();
        _mover = GetComponent<PlayerMover>();
        _combat = GetComponent<PlayerCombat>();
        _magic = GetComponent<PlayerMagic>();
        _animator = GetComponent<CharacterAnimator>();
        _health = GetComponent<Health>();
        _targetSystem = GetComponentInChildren<PlayerTargetSystem>();   

        _attributesManager.Init();
        _mover.Init(_legs, _groundMask, _attributesManager);
        _combat.Init(_attackPoint, _animator, _attributesManager);
        _health.Init(_attributesManager);
        _targetSystem.Init(_targetMark, _minDetectRange);
        _magic.Init(_animator, _attributesManager);
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

    public void TryCastSpell()
    {
        _magic.TryCastSpell();
    }
}