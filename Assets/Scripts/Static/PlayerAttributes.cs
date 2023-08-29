using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public static PlayerAttributes Instance { get; private set; }

    // main
    public float Strength => GetStrength();
    public float Agility => GetAgillity();
    public float Intelligence => GetIntelligence();

    // seconday (based on main)
    public float MaxHealth => GetMaxHealth();
    public float MovementSpeed => GetMovementSpeed();
    public float JumpPower => GetJumpPower();
    public float DashPower => GetDashPower();
    public float AttackDamage => GetAttackDamage();
    public float DashCooldown => GetDashCooldown();
    public float EvasionChance => GetEvasionChance();

    // map
    private Dictionary<AttributeNames, float> _attributesMap = new Dictionary<AttributeNames, float>();

    private void Awake()
    {
        Instance = this;   

        _attributesMap.Add(AttributeNames.Strength, PlayerConstants.BaseStrength);
        _attributesMap.Add(AttributeNames.Agility, PlayerConstants.BaseAgility);
        _attributesMap.Add(AttributeNames.Intelligence, PlayerConstants.BaseIntelligence);

        _attributesMap.Add(AttributeNames.MaxHealth, PlayerConstants.BaseMaxHealth);
        _attributesMap.Add(AttributeNames.MovementSpeed, PlayerConstants.BaseMovementSpeed);
        _attributesMap.Add(AttributeNames.JumpPower, PlayerConstants.BaseJumpPower);
        _attributesMap.Add(AttributeNames.DashPower, PlayerConstants.BaseDashPower);
        _attributesMap.Add(AttributeNames.AttackDamage, PlayerConstants.BaseAttackDamage);
        _attributesMap.Add(AttributeNames.EvasionChance, PlayerConstants.BaseEvasionChance);
    }

    private float GetStrength()
    {
        return _attributesMap[AttributeNames.Strength];
    }

    private float GetAgillity()
    {
        return _attributesMap[AttributeNames.Agility];
    }

    private float GetIntelligence()
    {
        return _attributesMap[AttributeNames.Intelligence];
    }

    private float GetEvasionChance()
    {
        return Mathf.Clamp(PlayerConstants.EvasionChancePerAgility * _attributesMap[AttributeNames.Agility] + _attributesMap[AttributeNames.EvasionChance], 
            0, 
            PlayerConstants.MaxEvasionChance);
    }

    private float GetMaxHealth()
    {
        return PlayerConstants.HealthPerStrength * _attributesMap[AttributeNames.Strength] + _attributesMap[AttributeNames.MaxHealth];
    }

    private float GetMovementSpeed()
    {
        return PlayerConstants.BaseMovementSpeed + PlayerConstants.MovementSpeedPerAgility * _attributesMap[AttributeNames.Agility] + _attributesMap[AttributeNames.MovementSpeed];
    }

    private float GetJumpPower()
    {
        return PlayerConstants.BaseJumpPower + PlayerConstants.JumpPowerPerAgility * _attributesMap[AttributeNames.Agility] + _attributesMap[AttributeNames.JumpPower];
    }

    private float GetDashPower()
    {
        return PlayerConstants.BaseDashPower + PlayerConstants.DashPowerPerAgility * _attributesMap[AttributeNames.Agility] + _attributesMap[AttributeNames.DashPower];
    }

    private float GetDashCooldown()
    {
        return Mathf.Clamp(PlayerConstants.BaseDashCooldown - PlayerConstants.DashCooldownCoeffPerStrength * _attributesMap[AttributeNames.Strength], 
            PlayerConstants.MinDashCooldown, 
            PlayerConstants.BaseDashCooldown);
    }

    private float GetAttackDamage()
    {
        return PlayerConstants.AttackDamagePerStrength * _attributesMap[AttributeNames.Strength] + _attributesMap[AttributeNames.AttackDamage];
    }

    private IEnumerator IncreasingStatTemprary(AttributeNames attributeName, float amount, float duration)
    {
        _attributesMap[attributeName] += amount;
        print(attributeName + " : " + _attributesMap[attributeName]);

        yield return new WaitForSeconds(duration);

        _attributesMap[attributeName] -= amount;
        print(attributeName + " : " + _attributesMap[attributeName]);
    }

    public void IncreaseStatTemprary(AttributeNames attributeName, float amount, float duration)
    {
        StartCoroutine(IncreasingStatTemprary(attributeName, amount, duration));
    }
}
