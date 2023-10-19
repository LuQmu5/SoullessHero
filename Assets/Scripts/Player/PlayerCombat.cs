using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Transform _attackPoint;
    private CharacterAnimator _animator;
    private AttributesManager _attributesManager;

    public bool IsAttacking { get; private set; }

    public void Init(Transform attackPoint, CharacterAnimator animator, AttributesManager attributesManager)
    {
        _attributesManager = attributesManager;
        _attackPoint = attackPoint;
        _animator = animator;
    }

    private IEnumerator Attacking()
    {
        IsAttacking = true;
        _animator.SetAttackSpeed(_attributesManager.AttackSpeed);

        yield return new WaitForEndOfFrame();

        float animationTime = _animator.GetCurrentAnimationLength();
        print(animationTime);

        yield return new WaitForSeconds(animationTime);

        IsAttacking = false;
    }

    /// <summary>
    /// running in animations
    /// </summary>
    public void DealDamage()
    {
        float baseAttackRange = 0.5f;
        var hits = Physics2D.OverlapCircleAll(_attackPoint.position, baseAttackRange);

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out Health health) && hit.TryGetComponent(out PlayerController player) == false)
            {
                health.ApplyDamage(_attributesManager.AttackDamage);
            }
        }
    }

    public void Attack()
    {
        StartCoroutine(Attacking());
    }
}
