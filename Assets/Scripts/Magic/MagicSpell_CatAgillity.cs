public class MagicSpell_CatAgillity : MagicSpell
{
    public override void Use(AttributesManager playerAttributes)
    {
        playerAttributes.IncreaseAttributeTemporarily(AttributeNames.MovementSpeed, 10, 5);
        playerAttributes.IncreaseAttributeTemporarily(AttributeNames.JumpPower, 10, 5);
        playerAttributes.IncreaseAttributeTemporarily(AttributeNames.EvasionChance, 100, 5);

        Destroy(gameObject);
    }
}
