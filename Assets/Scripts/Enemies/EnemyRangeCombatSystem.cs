﻿using UnityEngine;

public class EnemyRangeCombatSystem : EnemyCombatSystem
{
    [SerializeField] private EnemyProjectile _projectile;

    protected override void Attack(Transform attackPoint, float attackRange, float attackDamage, DamageType damageType)
    {
        var projectile = Instantiate(_projectile, attackPoint);
        projectile.Init(attackDamage, damageType);
    }
}
