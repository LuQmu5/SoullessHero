﻿using UnityEngine;

public class PlayerHealth : Health
{
    public override void ApplyDamage(float amount, DamageType damageType)
    {
        float maxValue = 100;
        float minValue = 0;

        if (Random.Range(minValue, maxValue) < AttributesManager.EvasionChance)
        {
            print("Miss!");
            return;
        }

        switch (damageType)
        {
            case DamageType.Physical:
                amount = Mathf.Clamp((maxValue - AttributesManager.PhysicalResistance) / maxValue, minValue, amount);
                break;
        }

        print(amount);
        base.ApplyDamage(amount, damageType);
    }
}
