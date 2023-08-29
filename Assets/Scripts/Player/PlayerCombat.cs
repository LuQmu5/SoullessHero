using System;
using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Transform _attackPoint;
    private CharacterAnimator _animator;

    public bool IsAttacking { get; private set; }

    public void Init(Transform attackPoint, CharacterAnimator animator)
    {
        _attackPoint = attackPoint;
        _animator = animator;
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
        var hits = Physics2D.OverlapCircleAll(_attackPoint.position, PlayerConstants.BaseAttackRange);

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out Health health) && hit.TryGetComponent(out PlayerController player) == false)
            {
                health.ApplyDamage(PlayerAttributes.Instance.AttackDamage);
            }
        }
    }

    public void Attack()
    {
        StartCoroutine(Attacking());
    }
}
