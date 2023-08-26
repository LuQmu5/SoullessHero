using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _speed = 5;
    private float _damage;

    public void Init(float damage)
    {
        transform.parent = null;
        _damage = damage;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.right, _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Health health))
        {
            health.ApplyDamage(_damage);
        }

        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}