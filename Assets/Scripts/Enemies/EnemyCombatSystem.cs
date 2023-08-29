using System.Collections;
using UnityEngine;

public abstract class EnemyCombatSystem : MonoBehaviour
{
    private CharacterAnimator _animator;
    private Transform _attackPoint;
    private float _attackRange;
    private float _attackDamage;

    private Coroutine _attackingCoroutine;

    public bool IsPlayerInAttackRange { get; private set; }

    public void Init(CharacterAnimator animator, Transform attackPoint, float attackRange, float attackDamage)
    {
        _animator = animator;
        _attackPoint = attackPoint;
        _attackRange = attackRange;
        _attackDamage = attackDamage;
    }

    private void Update()
    {
        IsPlayerInAttackRange = CheckPlayerInAttackRange();
    }

    private bool CheckPlayerInAttackRange()
    {
        var hit = Physics2D.Raycast(_attackPoint.position, transform.right, _attackRange);
        Debug.DrawRay(_attackPoint.position, transform.right * _attackRange, Color.red);

        return (hit.collider != null && hit.collider.TryGetComponent(out PlayerController player));
    }

    private IEnumerator Attacking()
    {
        yield return new WaitForEndOfFrame();

        float animationTime = _animator.GetCurrentAnimationLength();
        float animationTimeReduce = 2;

        while (true)
        {
            yield return new WaitForSeconds(animationTime / animationTimeReduce);

            DealDamage(_attackPoint, _attackRange, _attackDamage);

            yield return new WaitForSeconds(animationTime / animationTimeReduce);
        }
    }

    protected abstract void DealDamage(Transform attackPoint, float attackRange, float attackDamage);

    public void SwitchAttackingState(bool state)
    {
        if (state)
            _attackingCoroutine = StartCoroutine(Attacking());
        else
            StopCoroutine(_attackingCoroutine);
    }
}
