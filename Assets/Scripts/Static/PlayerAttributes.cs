using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public static PlayerAttributes Instance { get; private set; }

    public float Agility => GetAgillity();
    public float AttackDamage => GetAttackDamage();
    public float AttackSpeed => GetAttackSpeed();
    public float DashCooldown => GetDashCooldown();
    public float DashPower => GetDashPower();
    public float EvasionChance => GetEvasionChance();
    public float Intelligence => GetIntelligence();
    public float JumpPower => GetJumpPower();
    public float MaxHealth => GetMaxHealth();
    public float MovementSpeed => GetMovementSpeed();
    public float Strength => GetStrength();
    public float FireResistance => GetFireResistance();
    public float FrostResistance => GetFrostResistance();
    public float NatureResistance => GetNatureResistance();

    private Dictionary<AttributeNames, float> _attributesMap = new Dictionary<AttributeNames, float>();

    private void Awake()
    {
        Instance = this;

        _attributesMap.Add(AttributeNames.Agility, PlayerConstants.BaseAgility);
        _attributesMap.Add(AttributeNames.AttackDamage, PlayerConstants.BaseAttackDamage);
        _attributesMap.Add(AttributeNames.AttackSpeed, PlayerConstants.BaseAttackSpeed);
        _attributesMap.Add(AttributeNames.DashPower, PlayerConstants.BaseDashPower);
        _attributesMap.Add(AttributeNames.EvasionChance, PlayerConstants.BaseEvasionChance);
        _attributesMap.Add(AttributeNames.Intelligence, PlayerConstants.BaseIntelligence);
        _attributesMap.Add(AttributeNames.JumpPower, PlayerConstants.BaseJumpPower);
        _attributesMap.Add(AttributeNames.MaxHealth, PlayerConstants.BaseMaxHealth);
        _attributesMap.Add(AttributeNames.MovementSpeed, PlayerConstants.BaseMovementSpeed);
        _attributesMap.Add(AttributeNames.Strength, PlayerConstants.BaseStrength);

        _attributesMap.Add(AttributeNames.FireResistance, PlayerConstants.BaseFireResistance);
        _attributesMap.Add(AttributeNames.FrostResistance, PlayerConstants.BaseFrostResistance);
        _attributesMap.Add(AttributeNames.NatureResistance, PlayerConstants.BaseNatureResistance);

        PrintAllAttributes();
    }

    private float GetFireResistance()
    {
        return _attributesMap[AttributeNames.FireResistance] + PlayerConstants.MagicResistancePerIntelligence * _attributesMap[AttributeNames.Intelligence];
    }

    private float GetFrostResistance()
    {
        return _attributesMap[AttributeNames.FrostResistance] + PlayerConstants.MagicResistancePerIntelligence * _attributesMap[AttributeNames.Intelligence];
    }

    private float GetNatureResistance()
    {
        return _attributesMap[AttributeNames.NatureResistance] + PlayerConstants.MagicResistancePerIntelligence * _attributesMap[AttributeNames.Intelligence];
    }

    private float GetAgillity()
    {
        return _attributesMap[AttributeNames.Agility];
    }

    private float GetAttackDamage()
    {
        return PlayerConstants.AttackDamagePerStrength * _attributesMap[AttributeNames.Strength] + _attributesMap[AttributeNames.AttackDamage];
    }

    private float GetAttackSpeed()
    {
        return PlayerConstants.AttackSpeedPerAgility * _attributesMap[AttributeNames.Agility] + _attributesMap[AttributeNames.AttackSpeed];
    }

    private float GetDashCooldown()
    {
        return Mathf.Clamp(PlayerConstants.BaseDashCooldown - PlayerConstants.DashCooldownCoeffPerStrength * _attributesMap[AttributeNames.Strength], 
            PlayerConstants.MinDashCooldown, 
            PlayerConstants.BaseDashCooldown);
    }

    private float GetDashPower()
    {
        return PlayerConstants.DashPowerPerAgility * _attributesMap[AttributeNames.Agility] + _attributesMap[AttributeNames.DashPower];
    }

    private float GetEvasionChance()
    {
        return Mathf.Clamp(PlayerConstants.EvasionChancePerAgility * _attributesMap[AttributeNames.Agility] + _attributesMap[AttributeNames.EvasionChance], 
            0, 
            PlayerConstants.MaxEvasionChance);
    }

    private float GetIntelligence()
    {
        return _attributesMap[AttributeNames.Intelligence];
    }

    private float GetJumpPower()
    {
        return PlayerConstants.JumpPowerPerStrength * _attributesMap[AttributeNames.Strength] + _attributesMap[AttributeNames.JumpPower];
    }

    private float GetMaxHealth()
    {
        return _attributesMap[AttributeNames.MaxHealth];
    }

    private float GetMovementSpeed()
    {
        return PlayerConstants.MovementSpeedPerAgility * _attributesMap[AttributeNames.Agility] + _attributesMap[AttributeNames.MovementSpeed];
    }

    private float GetStrength()
    {
        return _attributesMap[AttributeNames.Strength];
    }

    private IEnumerator IncreasingAttributeTemporarily(AttributeNames attributeName, float amount, float duration)
    {
        _attributesMap[attributeName] += amount;

        yield return new WaitForSeconds(duration);

        _attributesMap[attributeName] -= amount;
    }

    public void IncreaseAttributeTemporarily(AttributeNames attributeName, float amount, float duration)
    {
        StartCoroutine(IncreasingAttributeTemporarily(attributeName, amount, duration));
    }
    public void IncreaseAttributePermanently(AttributeNames attributeName, float amount)
    {
        _attributesMap[attributeName] += amount;
    }

    public void PrintAllAttributes()
    {
        print("Сила: " + GetStrength());
        print("Ловкость: " + GetAgillity());
        print("Интеллект: " + GetIntelligence());
        print("Максимальное здоровье: " + GetMaxHealth());
        print("Скорость движения: " + GetMovementSpeed());
        print("Сила прыжка: " + GetJumpPower());
        print("Сила рывка: " + GetDashPower());
        print("Шанс уклонения: " + GetEvasionChance());
        print("Сила атаки: " + GetAttackDamage());
    }
    public float GetAttributeValue(AttributeNames attributeName)
    {
        return _attributesMap[attributeName];
    }
}
