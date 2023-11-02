using System.Collections;
using UnityEngine;

public class MagicSpell_Fireball : MagicSpell
{
    [SerializeField] private float _baseDamage = 2;
    [SerializeField] private float _speed = 5;

    private Vector3 _direction;
    private float _damage;

    public override void Use(AttributesManager casterAttributes)
    {
        // object pool for fireballs projectile

        _damage = _baseDamage + Constants.SpellPowerPerIntelligence * casterAttributes.Intelligence;
        _direction = casterAttributes.transform.right;  
        transform.position = casterAttributes.transform.position;
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            health.ApplyDamage(_damage, DamageType.Fire);
            gameObject.SetActive(false);
        }
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}