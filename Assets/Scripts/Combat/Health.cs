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

    public virtual void ApplyDamage(float amount, DamageType damageType = DamageType.Physical)
    {
        CurrentHealth -= amount;
        Damaged?.Invoke();

        if (CurrentHealth <= 0)
        {
            Over?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
