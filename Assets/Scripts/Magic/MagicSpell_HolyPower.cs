public class MagicSpell_HolyPower : MagicSpell
{
    public override void Use(AttributesManager playerAttributes)
    {
        playerAttributes.IncreaseAttributeTemporarily(AttributeNames.Strength, 100, 5);
        playerAttributes.IncreaseAttributeTemporarily(AttributeNames.PhysicalResistance, 100, 5);

        Destroy(gameObject);
    }
}