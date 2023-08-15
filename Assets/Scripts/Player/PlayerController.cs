using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerCombat _combat;

    [Header("Movement Settings")]
    [SerializeField] private Transform _legs;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _legsRadius = 0.1f;

    public Vector2 Velocity => _mover.Velocity;
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
}
