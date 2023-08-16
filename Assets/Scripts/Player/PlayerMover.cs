using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Coroutine _dashReloadingCoroutine;

    public Vector2 Velocity => _rigidbody.velocity;
    public bool CanDash => _dashReloadingCoroutine == null;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction)
    {
        _rigidbody.velocity = new Vector2(direction.x * PlayerStats.Instance.MovementSpeed, _rigidbody.velocity.y);
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector2.up * PlayerStats.Instance.JumpPower, ForceMode2D.Impulse);
    }

    public void StopMovement()
    {
        _rigidbody.velocity = Vector2.zero;
    }

    public void Dash()
    {
        _rigidbody.AddForce(transform.rotation.y == 0? Vector2.right * PlayerStats.Instance.DashPower : Vector2.left * PlayerStats.Instance.DashPower, ForceMode2D.Impulse);

        _dashReloadingCoroutine = StartCoroutine(DashReloading());
        StartCoroutine(Dashing());
    }

    private IEnumerator DashReloading()
    {
        yield return new WaitForSeconds(PlayerStats.Instance.DashCooldown);

        _dashReloadingCoroutine = null;
    }

    private IEnumerator Dashing()
    {
        yield return new WaitForSeconds(0.1f);

        StopMovement();
    }
}
