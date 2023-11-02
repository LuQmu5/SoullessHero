public class MagicSpell_ColdWeapon : MagicSpell
{
    public override void Use(AttributesManager casterAttributes)
    {
        casterAttributes.IncreaseDamageTypeTemporarily(DamageType.Frost, 10, 5);

        float currentAttackSpeed = casterAttributes.AttackSpeed;
        float decreaseMultiplier = -0.5f;
        casterAttributes.IncreaseAttributeTemporarily(AttributeNames.AttackSpeed, currentAttackSpeed * decreaseMultiplier, 5);

        gameObject.SetActive(false);
    }
}