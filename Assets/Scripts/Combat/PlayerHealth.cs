using UnityEngine;

public class PlayerHealth : Health
{
    public override void ApplyDamage(float amount)
    {
        if (Random.Range(0, 100) < PlayerAttributes.Instance.EvasionChance)
        {
            print("Miss!");
            return;
        }

        amount = Mathf.Clamp((100 - PlayerAttributes.Instance.PhysicalResistance) / 100, 0, amount);
        print(amount);

        base.ApplyDamage(amount);
    }
}
