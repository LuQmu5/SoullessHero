using UnityEngine;

public class PlayerHealth : Health
{
    public override void ApplyDamage(float amount)
    {
        if (Random.Range(0, 100) < PlayerStats.EvasionChance)
        {
            print("MISS!");
            return;
        }

        base.ApplyDamage(amount);
    }
}
