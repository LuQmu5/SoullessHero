﻿using UnityEngine;

public class EnemyRangeCombatSystem : EnemyCombatSystem
{
    [SerializeField] private Projectile _projectile;

    protected override void DealDamage(Transform attackPoint, float attackRange, float attackDamage)
    {
        var projectile = Instantiate(_projectile, attackPoint);
        projectile.Init(attackDamage);
    }
}
