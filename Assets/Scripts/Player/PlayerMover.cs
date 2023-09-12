using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private Transform _legs;
    private LayerMask _groundMask;
    private Rigidbody2D _rigidbody;
    private Coroutine _dashReloadingCoroutine;
    private WaitForSeconds _dashDuration;
    private Vector2 _legsHitBoxSize;
    private AttributesManager _attributesManager;

    public Vector2 Velocity => _rigidbody.velocity;
    public bool CanDash => _dashReloadingCoroutine == null;
    public bool OnGround { get; private set; }

    public void Init(Transform legs, LayerMask groundMask, AttributesManager attributesManager)
    {
        _attributesManager = attributesManager;

        _rigidbody = GetComponent<Rigidbody2D>();
        // _rigidbody.gravityScale = Constants.BaseGravityScale;
        _rigidbody.gravityScale = 2;

        _legs = legs;
        _groundMask = groundMask;

        // _dashDuration = new WaitForSeconds(Constants.BaseDashDuration);
        _dashDuration = new WaitForSeconds(0.1f);

        float legsSizeY = 0.1f;
        float legsSizeX = 0.75f;
        _legsHitBoxSize = new Vector2(legsSizeX, legsSizeY);
    }

    private void FixedUpdate()
    {
        float legsHitBoxAngle = 0;

        OnGround = Physics2D.OverlapBox(_legs.position, _legsHitBoxSize, legsHitBoxAngle, _groundMask);
    }

    private IEnumerator DashReloading()
    {
        // float dashCooldown = Constants.BaseDashCooldown - PlayerAttributes.Instance.Strength * Constants.DashCooldownCoeffPerStrength;
        float dashCooldown = 4 - _attributesManager.Strength * Constants.DashCooldownCoeffPerStrength;

        yield return new WaitForSeconds(dashCooldown);

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

        _rigidbody.velocity = new Vector2(direction.x * _attributesManager.MovementSpeed, _rigidbody.velocity.y);
    }

    public void Jump()
    {
        float jumpPower = 5 + _attributesManager.Strength * Constants.JumpPowerPerStrength;

        _rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    public void Dash()
    {
        float dashPower = 15 + _attributesManager.Agility * Constants.DashPowerPerAgility;

        _rigidbody.AddForce(transform.rotation.y == 0 ? 
            Vector2.right * dashPower : 
            Vector2.left * dashPower, 
            ForceMode2D.Impulse);

        _dashReloadingCoroutine = StartCoroutine(DashReloading());
        StartCoroutine(Dashing());
    }

    public void StopMovement()
    {
        _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
    }
}
