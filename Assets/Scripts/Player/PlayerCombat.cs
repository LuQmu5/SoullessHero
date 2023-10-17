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
    }

    private IEnumerator Attacking()
    {
        IsAttacking = true;

        yield return new WaitForEndOfFrame();

        _animator.SetAttackSpeed(_attributesManager.AttackSpeed);
        float animationTime = _animator.GetCurrentAnimationLength() / _attributesManager.AttackSpeed;

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

    public void AddDamageTypePermanently(DamageType damageType, float value)
    {
        if (_damageTypesMap.ContainsKey(damageType))
        {
            _damageTypesMap[damageType] += value;
        }
        else
        {
            _damageTypesMap.Add(damageType, value);
        }
    }

    public void AddDamageTypeTemporarily(DamageType damageType, float value, float duration)
    {
        StartCoroutine(AddingDamageTypeTemporarily(damageType, value, duration));
    }

    private IEnumerator AddingDamageTypeTemporarily(DamageType damageType, float value, float duration)
    {
        if (_damageTypesMap.ContainsKey(damageType))
        {
            _damageTypesMap[damageType] += value;
        }
        else
        {
            _damageTypesMap.Add(damageType, value);
        }
        
        yield return new WaitForSeconds(duration);

        _damageTypesMap[damageType] -= value;
    }
}
