public class MagicSpell_HolyPower : MagicSpell
{
    public override void Use(AttributesManager casterAttributes)
    {
        casterAttributes.IncreaseAttributeTemporarily(AttributeNames.Strength, 100, 5);
        casterAttributes.IncreaseAttributeTemporarily(AttributeNames.PhysicalResistance, 100, 5);

        gameObject.SetActive(false);
    }
}
