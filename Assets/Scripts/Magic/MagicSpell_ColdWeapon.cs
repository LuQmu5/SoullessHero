public class MagicSpell_ColdWeapon : MagicSpell
{
    public override void Use(AttributesManager playerAttributes)
    {
        playerAttributes.IncreaseDamageTypeTemporarily(DamageType.Frost, 10, 5);

        float currentAttackSpeed = playerAttributes.AttackSpeed;
        float decreaseMultiplier = -0.5f;
        playerAttributes.IncreaseAttributeTemporarily(AttributeNames.AttackSpeed, currentAttackSpeed * decreaseMultiplier, 5);

        Destroy(gameObject);
    }
}