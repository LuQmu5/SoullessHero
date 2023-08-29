public static class PlayerStats
{
    // main
    public static float Strength { get; private set; } = 10;
    public static float Agility { get; private set; } = 10;
    public static float Intelligence { get; private set; } = 10;

    // seconday (based on main)
    public static float MaxHealth { get; private set; } = 10;
    public static float MovementSpeed { get; private set; } = 5;
    public static float JumpPower { get; private set; } = 12;
    public static float DashPower { get; private set; } = 25;
    public static float DashCooldown { get; private set; } = 1;
    public static float Damage { get; private set; } = 1;
}
