using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _health = 10;

    public void ApplyDamage(float amount)
    {
        _health -= amount;

        if (_health <= 0)
            gameObject.SetActive(false);
    }
}
