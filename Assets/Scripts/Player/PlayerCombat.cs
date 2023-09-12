using System;
using System.Collections;
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

        yield return new WaitForEndOfFrame();

        _animator.SetAttackSpeed(_attributesManager.AttackSpeed);
        float animationTime = _animator.GetCurrentAnimationLength();
        float animationTimeReduce = 2;

        yield return new WaitForSeconds(animationTime / animationTimeReduce);

        DealDamage();

        yield return new WaitForSeconds(animationTime / animationTimeReduce);

        IsAttacking = false;
    }

    private void DealDamage()
    {
        // var hits = Physics2D.OverlapCircleAll(_attackPoint.position, Constants.BaseAttackRange);
        var hits = Physics2D.OverlapCircleAll(_attackPoint.position, 0.5f);

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


