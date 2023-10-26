public class MagicSpell_CatAgillity : MagicSpell
{
    public override void Use(AttributesManager casterAttributes)
    {
        casterAttributes.IncreaseAttributeTemporarily(AttributeNames.MovementSpeed, 10, 5);
        casterAttributes.IncreaseAttributeTemporarily(AttributeNames.JumpPower, 10, 5);
        casterAttributes.IncreaseAttributeTemporarily(AttributeNames.EvasionChance, 100, 5);

        Destroy(gameObject);
    }
}
