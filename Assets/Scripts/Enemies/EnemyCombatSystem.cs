using System.Collections;
using UnityEngine;

public abstract class EnemyCombatSystem : MonoBehaviour
{
    private CharacterAnimator _animator;
    private Transform _attackPoint;
    private float _attackRange;
    private float _attackDamage;
    private DamageType _damageType;
    private AttributesManager _attributesManager;

    private Coroutine _attackingCoroutine;

    public bool IsPlayerInAttackRange { get; private set; }

    public void Init(CharacterAnimator animator, Transform attackPoint, float attackRange, float attackDamage, DamageType damageType, AttributesManager attributesManager)
    {
        _animator = animator;
        _attackPoint = attackPoint;
        _attackRange = attackRange;
        _attackDamage = attackDamage;
        _damageType = damageType;
        _attributesManager = attributesManager;
    }

    private void Update()
    {
        IsPlayerInAttackRange = CheckPlayerInAttackRange();
    }

    private bool CheckPlayerInAttackRange()
    {
        var hits = Physics2D.RaycastAll(_attackPoint.position, transform.right, _attackRange);
        Debug.DrawRay(_attackPoint.position, transform.right * _attackRange, Color.red);

        foreach (var hit in hits)
            if (hit.collider.TryGetComponent(out PlayerController player))
                return true;

        return false;
    }

    /// <summary>
    /// Running in animation
    /// </summary>
    public void Attack()
    {
        _animator.SetAttackSpeed(_attributesManager.AttackSpeed);
        DealDamage(_attackPoint, _attackRange, _attackDamage, _damageType);
    }

    protected abstract void DealDamage(Transform attackPoint, float attackRange, float attackDamage, DamageType damageType);
}
