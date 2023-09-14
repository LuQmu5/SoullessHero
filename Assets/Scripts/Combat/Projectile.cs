using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _speed = 5;
    private float _damage;
    private DamageType _damageType;

    public void Init(float damage, DamageType damageType)
    {
        transform.parent = null;
        _damage = damage;
        _damageType = damageType;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.right, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            health.ApplyDamage(_damage, _damageType);
        }

        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}