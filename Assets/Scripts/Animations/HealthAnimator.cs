using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]  
[RequireComponent(typeof(SpriteRenderer))]  
public class HealthAnimator : MonoBehaviour
{
    private Health _health;
    private SpriteRenderer _spriteRenderer;
    private WaitForSeconds _damagedAnimationDelay;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _damagedAnimationDelay = new WaitForSeconds(0.1f);
    }

    private void OnEnable()
    {
        _health.Damaged += OnDamaged;
    }

    private void OnDisable()
    {
        _health.Damaged -= OnDamaged;
    }

    private void OnDamaged()
    {
        StartCoroutine(Damaging());
    }

    private IEnumerator Damaging()
    {
        _spriteRenderer.color = Color.red;

        yield return _damagedAnimationDelay;

        _spriteRenderer.color = Color.white;
    }
}
