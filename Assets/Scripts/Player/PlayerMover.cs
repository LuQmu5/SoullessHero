using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Transform _legs;
    [SerializeField] private LayerMask _groundMask;

    private Rigidbody2D _rigidbody;
    private Coroutine _dashReloadingCoroutine;
    private WaitForSeconds _dashDuration;
    private Vector2 _legsHitBoxSize;

    public Vector2 Velocity => _rigidbody.velocity;
    public bool CanDash => _dashReloadingCoroutine == null;
    public bool OnGround { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        float dashingTime = 0.1f;
        _dashDuration = new WaitForSeconds(dashingTime);

        float legsSizeY = 0.1f;
        float _legsSizeX = 0.75f;
        _legsHitBoxSize = new Vector2(_legsSizeX, legsSizeY);
    }

    private void FixedUpdate()
    {
        float legsHitBoxAngle = 0;

        OnGround = Physics2D.OverlapBox(_legs.position, _legsHitBoxSize, legsHitBoxAngle, _groundMask);
    }

    private IEnumerator DashReloading()
    {
        yield return new WaitForSeconds(PlayerStats.Instance.DashCooldown);

        _dashReloadingCoroutine = null;
    }

    private IEnumerator Dashing()
    {
        yield return _dashDuration;

        _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
    }

    private void TransformRotation(Vector2 direction)
    {
        Vector3 normalRotation = Vector3.zero;
        Vector3 flippedRotation = new Vector3(0, 180, 0);

        if (direction == Vector2.right)
            transform.rotation = Quaternion.Euler(normalRotation);
        else if (direction == Vector2.left)
            transform.rotation = Quaternion.Euler(flippedRotation);
    }

    public void Move(Vector2 direction)
    {
        if (direction != Vector2.zero)
            TransformRotation(direction);

        _rigidbody.velocity = new Vector2(direction.x * PlayerStats.Instance.MovementSpeed, _rigidbody.velocity.y);
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector2.up * PlayerStats.Instance.JumpPower, ForceMode2D.Impulse);
    }

    public void Dash()
    {
        _rigidbody.AddForce(transform.rotation.y == 0 ? 
            Vector2.right * PlayerStats.Instance.DashPower : 
            Vector2.left * PlayerStats.Instance.DashPower, 
            ForceMode2D.Impulse);

        _dashReloadingCoroutine = StartCoroutine(DashReloading());
        StartCoroutine(Dashing());
    }

    public void StopMovement()
    {
        _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
    }
}
