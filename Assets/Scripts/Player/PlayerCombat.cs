using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Transform _attackPoint;
    private CharacterAnimator _animator;
    private AttributesManager _attributesManager;
    private Dictionary<DamageType, float> _damageTypesMap;

    public bool IsAttacking { get; private set; }

    public void Init(Transform attackPoint, CharacterAnimator animator, AttributesManager attributesManager)
    {
        _attributesManager = attributesManager;
        _attackPoint = attackPoint;
        _animator = animator;

        _damageTypesMap = new Dictionary<DamageType, float>();
        _damageTypesMap.Add(DamageType.Physical, attributesManager.AttackDamage);
        _damageTypesMap.Add(DamageType.Fire, 3);
        // везде получается почему-то 0.99 ед. урона
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
        float baseAttackRange = 0.5f;
        var hits = Physics2D.OverlapCircleAll(_attackPoint.position, baseAttackRange);

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out Health health) && hit.TryGetComponent(out PlayerController player) == false)
            {
                foreach (var item in _damageTypesMap)
                {
                    health.ApplyDamage(item.Value, item.Key);
                }
            }
        }
    }

    public void Attack()
    {
        StartCoroutine(Attacking());
    }
}
