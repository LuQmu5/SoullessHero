using UnityEngine;

public class MagicSpell_Plague : MagicSpell
{
    [SerializeField] private float _damagePerTick = 0.4f;
    [SerializeField] private float _duration = 5;

    public override void Use(AttributesManager casterAttributes)
    {
        _damagePerTick += (Constants.SpellPowerPerIntelligence * casterAttributes.Intelligence) / Constants.PeriodicDamageSpellPowerReduceCoeff;

        if (casterAttributes.TryGetComponent(out PlayerController player))
        {
            if (player.ClosestEnemy != null && player.ClosestEnemy.TryGetComponent(out Health health))
            {
                health.StartPeriodicDamage(_damagePerTick, _duration, DamageType.Shadow);
            }
        }
        else if (casterAttributes.TryGetComponent(out EnemyController enemy))
        {
            if (enemy.Player != null && enemy.Player.TryGetComponent(out Health health))
            {
                health.StartPeriodicDamage(_damagePerTick, _duration, DamageType.Shadow);
            }
        }

        gameObject.SetActive(false);
    }
}