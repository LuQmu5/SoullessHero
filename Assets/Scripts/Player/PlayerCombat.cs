using System;
using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Transform _attackPoint;
    private CharacterAnimator _animator;
    private float _attackRange;

    public bool IsAttacking { get; private set; }

    public void Init(Transform attackPoint, CharacterAnimator animator, float attackRange)
    {
        _attackPoint = attackPoint;
        _animator = animator;
        _attackRange = attackRange;
    }

    private IEnumerator Attacking()
    {
        IsAttacking = true;

        yield return new WaitForEndOfFrame();

        float animationTime = _animator.GetCurrentAnimationLength();
        float animationTimeReduce = 2;

        yield return new WaitForSeconds(animationTime / animationTimeReduce);

        DealDamage();

        yield return new WaitForSeconds(animationTime / animationTimeReduce);

        IsAttacking = false;
    }

    private void DealDamage()
    {
        var hits = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange);

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out Health health) && hit.TryGetComponent(out PlayerController player) == false)
            {
                health.ApplyDamage(PlayerStats.AttackDamage);
            }
        }
    }

    public void Attack()
    {
        StartCoroutine(Attacking());
    }
}
