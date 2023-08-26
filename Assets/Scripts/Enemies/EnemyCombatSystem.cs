using System.Collections;
using UnityEngine;

public class EnemyCombatSystem : MonoBehaviour
{
    private Animator _animator;
    private Transform _attackPoint;
    private float _attackRange;
    private float _attackDamage;

    private Coroutine _attackingCoroutine;

    public bool IsPlayerInAttackRange { get; private set; }

    public void Init(Animator animator, Transform attackPoint, float attackRange, float attackDamage)
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
        float delay = 0.1f;
        float animationTimeReduce = 2;

        yield return new WaitForSeconds(delay);

        float animationTime = _animator.GetCurrentAnimatorStateInfo(0).length;

        while (true)
        {
            yield return new WaitForSeconds(animationTime / animationTimeReduce);

            DealDamage();

            yield return new WaitForSeconds(animationTime / animationTimeReduce);
        }
    }

    private void DealDamage()
    {
        var hits = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange);

        foreach (var hit in hits)
            if (hit.TryGetComponent(out Health health) && hit.TryGetComponent(out EnemyController enemy) == false)
                health.ApplyDamage(_attackDamage);
    }

    public void SwitchAttackingState(bool state)
    {
        if (state)
            _attackingCoroutine = StartCoroutine(Attacking());
        else
            StopCoroutine(_attackingCoroutine);
    }
}
