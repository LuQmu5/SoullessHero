using System;
using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange;

    public bool IsAttacking { get; private set; }

    private IEnumerator Attacking(PlayerAnimator animator)
    {
        IsAttacking = true;

        yield return new WaitForEndOfFrame();

        float delay = animator.GetCurrentAnimationLength();
        float delayReduction = 2;

        yield return new WaitForSeconds(delay / delayReduction);

        DealDamage();

        yield return new WaitForSeconds(delay / delayReduction);

        IsAttacking = false;
    }

    private void DealDamage()
    {
        var hits = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange);

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out Health health) && hit.TryGetComponent(out PlayerController player) == false)
            {
                health.ApplyDamage(PlayerStats.Instance.Damage, transform);
            }
        }
    }

    public void Attack(PlayerAnimator animator)
    {
        StartCoroutine(Attacking(animator));
    }
}
