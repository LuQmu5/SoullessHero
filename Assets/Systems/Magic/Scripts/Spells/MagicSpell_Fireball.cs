using System.Collections;
using UnityEngine;

public class MagicSpell_Fireball : MagicSpell
{
    [SerializeField] private float _baseDamage = 2;

    public override void Use(AttributesManager casterAttributes)
    {
        _baseDamage += Constants.SpellPowerPerIntelligence * casterAttributes.Intelligence;

        StartCoroutine(Moving(casterAttributes.transform.right));     
    }

    private IEnumerator Moving(Vector3 direction)
    {
        float speed = 5;

        while (true)
        {
            transform.Translate(direction * speed * Time.deltaTime);

            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            health.ApplyDamage(_baseDamage, DamageType.Fire);
            print(collision.gameObject.name);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}