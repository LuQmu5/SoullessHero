public class MagicSpell_Windfurry : MagicSpell
{
    public override void Use(AttributesManager casterAttributes)
    {
        float currentAttackDamage = casterAttributes.AttackDamage;
        float currentAttackSpeed = casterAttributes.AttackSpeed;

        casterAttributes.IncreaseAttributeTemporarily(AttributeNames.AttackDamage, currentAttackDamage / -2, 5);
        casterAttributes.IncreaseAttributeTemporarily(AttributeNames.AttackSpeed, currentAttackSpeed, 5);

        gameObject.SetActive(false);
    }
}
