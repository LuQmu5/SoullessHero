using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    protected float MaxHealth;
    protected float CurrentHealth;
    protected AttributesManager AttributesManager;

    public event UnityAction Damaged;
    public event UnityAction Over;

    public void Init(AttributesManager attributesManager)
    {
        AttributesManager = attributesManager;
        MaxHealth = AttributesManager.MaxHealth;
        CurrentHealth = MaxHealth;
    }

    public void ApplyDamage(float amount, DamageType damageType = DamageType.Physical)
    {
        float maxValue = 100;
        float minValue = 0;

        if (Random.Range(minValue, maxValue) < AttributesManager.EvasionChance && damageType == DamageType.Physical)
        {
            // print("Miss!");
            return;
        }

        amount = GetDecreasedDamage(amount, damageType, maxValue, minValue);

        if (amount <= 0)
            return;

        CurrentHealth -= amount;
        Damaged?.Invoke();
        print($"{amount} ед. урона от {damageType} типа урона");

        if (CurrentHealth <= 0)
        {
            Over?.Invoke();
            gameObject.SetActive(false);
        }
    }

    private float GetDecreasedDamage(float amount, DamageType damageType, float maxValue, float minValue)
    {
        switch (damageType)
        {
            case DamageType.Physical:
                amount *= Mathf.Clamp((maxValue - AttributesManager.PhysicalResistance) / maxValue, minValue, amount);
                break;

            case DamageType.Fire:
                amount *= Mathf.Clamp((maxValue - AttributesManager.FireResistance) / maxValue, minValue, amount);
                break;

            case DamageType.Frost:
                amount *= Mathf.Clamp((maxValue - AttributesManager.FrostResistance) / maxValue, minValue, amount);
                break;

            case DamageType.Nature:
                amount *= Mathf.Clamp((maxValue - AttributesManager.NatureResistance) / maxValue, minValue, amount);
                break;

            case DamageType.Shadow:
                amount *= Mathf.Clamp((maxValue - AttributesManager.ShadowResistance) / maxValue, minValue, amount);
                break;

            case DamageType.Diabolic:
                amount *= Mathf.Clamp((maxValue - AttributesManager.DiabolicResistance) / maxValue, minValue, amount);
                break;

            case DamageType.Blood:
                amount *= Mathf.Clamp((maxValue - AttributesManager.BloodResistance) / maxValue, minValue, amount);
                break;

            case DamageType.Arcane:
                amount *= Mathf.Clamp((maxValue - AttributesManager.ArcaneResistance) / maxValue, minValue, amount);
                break;

            case DamageType.Holy:
                amount *= Mathf.Clamp((maxValue - AttributesManager.HolyResistance) / maxValue, minValue, amount);
                break;

            case DamageType.Mental:
                amount *= Mathf.Clamp((maxValue - AttributesManager.MentalResistance) / maxValue, minValue, amount);
                break;
        }

        return amount;
    }

    public void StartPeriodicDamage(float damagePerTick, float duration, DamageType damageType)
    {
        StartCoroutine(PeriodicDamaging(damagePerTick, duration, damageType));
    }

    private IEnumerator PeriodicDamaging(float damagePerTick, float duration, DamageType damageType)
    {
        float tickTime = 1;
        WaitForSeconds tick = new WaitForSeconds(tickTime);

        while (duration > 0)
        {
            duration -= tickTime;
            ApplyDamage(damagePerTick, damageType);

            yield return tick;
        }
    }
}
