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

        if (Random.Range(minValue, maxValue) < AttributesManager.EvasionChance)
        {
            // print("Miss!");
            return;
        }

        switch (damageType)
        {
            case DamageType.Physical:
                amount *= Mathf.Clamp((maxValue - AttributesManager.PhysicalResistance) / maxValue, minValue, amount);
                break;

            case DamageType.Fire:
                amount *= Mathf.Clamp((maxValue - AttributesManager.FireResistance) / maxValue, minValue, amount);
                break;
        }

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
}
