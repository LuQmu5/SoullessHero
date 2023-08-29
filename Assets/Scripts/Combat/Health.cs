﻿using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    private float _maxHealth;
    private float _currentHealth;

    public event UnityAction Damaged;
    public event UnityAction Over;

    public void SetMaxHealth(float maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
    }

    public virtual void ApplyDamage(float amount)
    {
        _currentHealth -= amount;
        Damaged?.Invoke();

        if (_currentHealth <= 0)
        {
            Over?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
