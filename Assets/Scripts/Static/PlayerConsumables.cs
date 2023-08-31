public static class PlayerConsumables
{
    public static int SkillPoints { get; private set; }
    public static int AttributePoints { get; private set; } = 55;

    public static void SpendAttributePoint()
    {
        AttributePoints--;
    }

    public static void AddAttributePoint()
    {
        AttributePoints++;
    }
}