public static class PlayerStats
{
    // main
    public static float Strength { get; private set; } = 10;
    public static float Agility { get; private set; } = 10;
    public static float Intelligence { get; private set; } = 10;

    // seconday (based on main)
    public static float MaxHealth => GetMaxHealth();
    public static float MovementSpeed => GetMovementSpeed();
    public static float JumpPower => GetJumpPower();
    public static float DashPower => GetDashPower();
    public static float AttackDamage => GetAttackDamage();
    public static float DashCooldown => GetDashCooldown();
    public static float EvasionChance => GetEvasionChance();

    private static float GetEvasionChance()
    {
        return UnityEngine.Mathf.Clamp(PlayerConstants.EvasionChancePerAgility * Agility, 0, PlayerConstants.MaxEvasionChance);
    }

    private static float GetMaxHealth()
    {
        return PlayerConstants.HealthPerStrength * Strength;
    }

    private static float GetMovementSpeed()
    {
        return PlayerConstants.BaseMovementSpeed + PlayerConstants.MovementSpeedPerAgility * Agility;
    }

    private static float GetJumpPower()
    {
        return PlayerConstants.BaseJumpPower + PlayerConstants.JumpPowerPerAgility * Agility;
    }

    private static float GetDashPower()
    {
        return PlayerConstants.BaseDashPower + PlayerConstants.DashPowerPerAgility * Agility;
    }

    private static float GetDashCooldown()
    {
        return UnityEngine.Mathf.Clamp(PlayerConstants.BaseDashCooldown - PlayerConstants.DashCooldownCoeffPerStrength * Strength, 
            PlayerConstants.MinDashCooldown, 
            PlayerConstants.BaseDashCooldown);
    }

    private static float GetAttackDamage()
    {
        return PlayerConstants.AttackDamagePerStrength * Strength;
    }
}
