using UnityEngine;

public class EnemyMeleeCombatSystem : EnemyCombatSystem
{
    protected override void Attack(Transform attackPoint, float attackRange, float attackDamage, DamageType damageType)
    {
        var hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);

        foreach (var hit in hits)
            if (hit.TryGetComponent(out Health health) && hit.TryGetComponent(out EnemyController enemy) == false)
                health.ApplyDamage(attackDamage, damageType);
    }
}
