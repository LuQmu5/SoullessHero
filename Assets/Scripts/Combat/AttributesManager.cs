using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesManager : MonoBehaviour
{
    [SerializeField] private AttributesData _data;

    private Dictionary<AttributeNames, float> _attributesMap = new Dictionary<AttributeNames, float>();
    private Dictionary<DamageType, float> _additionalDamageTypesMap = new Dictionary<DamageType, float>();

    public Dictionary<DamageType, float> AdditionalDamageTypesMap => _additionalDamageTypesMap;

    public float Agility => GetAgillity();
    public float AttackDamage => GetAttackDamage();
    public float AttackSpeed => GetAttackSpeed();
    public float EvasionChance => GetEvasionChance();
    public float Intelligence => GetIntelligence();
    public float MaxHealth => GetMaxHealth();
    public float MovementSpeed => GetMovementSpeed();
    public float JumpPower => GetJumpPower();
    public float Strength => GetStrength();
    public float FireResistance => GetFireResistance();
    public float FrostResistance => GetFrostResistance();
    public float NatureResistance => GetNatureResistance();
    public float ShadowResistance => GetShadowResistance();
    public float DiabolicResistance => GetDiabolicResistance();
    public float BloodResistance => GetBloodResistance();
    public float ArcaneResistance => GetArcaneResistance();
    public float HolyResistance => GetHolyResistance();
    public float MentalResistance => GetMentalResistance();
    public float PhysicalResistance => GetPhysicalResistance();

    public void Init()
    {
        CreateAttributesDict();
        CreateDamageTypesDict();
    }

    private void CreateDamageTypesDict()
    {
        _additionalDamageTypesMap.Add(DamageType.Physical, _data.PhysicalDamage);
        _additionalDamageTypesMap.Add(DamageType.Fire, _data.FireDamage);
        _additionalDamageTypesMap.Add(DamageType.Frost, _data.FrostDamage);
        _additionalDamageTypesMap.Add(DamageType.Nature, _data.NatureDamage);
        _additionalDamageTypesMap.Add(DamageType.Shadow, _data.ShadowDamage);
        _additionalDamageTypesMap.Add(DamageType.Diabolic, _data.DiabolicDamage);
        _additionalDamageTypesMap.Add(DamageType.Blood, _data.BloodDamage);
        _additionalDamageTypesMap.Add(DamageType.Arcane, _data.ArcaneDamage);
        _additionalDamageTypesMap.Add(DamageType.Holy, _data.HolyDamage);
        _additionalDamageTypesMap.Add(DamageType.Mental, _data.MentalDamage);
    }

    private void CreateAttributesDict()
    {
        _attributesMap.Add(AttributeNames.Agility, _data.Agility);
        _attributesMap.Add(AttributeNames.Intelligence, _data.Intelligence);
        _attributesMap.Add(AttributeNames.Strength, _data.Strength);

        _attributesMap.Add(AttributeNames.AttackDamage, _data.AttackDamage);
        _attributesMap.Add(AttributeNames.AttackSpeed, _data.AttackSpeed);
        _attributesMap.Add(AttributeNames.EvasionChance, _data.EvasionChance);
        _attributesMap.Add(AttributeNames.MaxHealth, _data.MaxHealth);

        _attributesMap.Add(AttributeNames.MovementSpeed, _data.MovementSpeed);
        _attributesMap.Add(AttributeNames.JumpPower, Constants.BaseJumpPower);

        _attributesMap.Add(AttributeNames.FireResistance, _data.FireResistance);
        _attributesMap.Add(AttributeNames.FrostResistance, _data.FrostResistance);
        _attributesMap.Add(AttributeNames.NatureResistance, _data.NatureResistance);
        _attributesMap.Add(AttributeNames.ShadowResistance, _data.ShadowResistance);
        _attributesMap.Add(AttributeNames.DiabolicResistance, _data.DiabolicResistance);
        _attributesMap.Add(AttributeNames.BloodResistance, _data.BloodResistance);
        _attributesMap.Add(AttributeNames.ArcaneResistance, _data.ArcaneResistance);
        _attributesMap.Add(AttributeNames.HolyResistance, _data.HolyResistance);
        _attributesMap.Add(AttributeNames.MentalResistance, _data.MentalResistance);
        _attributesMap.Add(AttributeNames.PhysicalResistance, _data.PhysicalResistance);
    }

    private float GetPhysicalResistance()
    {
        return _attributesMap[AttributeNames.PhysicalResistance] + Constants.PhysicalResistancePerStrength * _attributesMap[AttributeNames.Strength];
    }

    private float GetMentalResistance()
    {
        return _attributesMap[AttributeNames.MentalResistance] + Constants.MagicResistancePerIntelligence * _attributesMap[AttributeNames.Intelligence];
    }

    private float GetHolyResistance()
    {
        return _attributesMap[AttributeNames.HolyResistance] + Constants.MagicResistancePerIntelligence * _attributesMap[AttributeNames.Intelligence];
    }

    private float GetArcaneResistance()
    {
        return _attributesMap[AttributeNames.ArcaneResistance] + Constants.MagicResistancePerIntelligence * _attributesMap[AttributeNames.Intelligence];
    }

    private float GetBloodResistance()
    {
        return _attributesMap[AttributeNames.BloodResistance] + Constants.MagicResistancePerIntelligence * _attributesMap[AttributeNames.Intelligence];
    }

    private float GetDiabolicResistance()
    {
        return _attributesMap[AttributeNames.DiabolicResistance] + Constants.MagicResistancePerIntelligence * _attributesMap[AttributeNames.Intelligence];
    }

    private float GetShadowResistance()
    {
        return _attributesMap[AttributeNames.ShadowResistance] + Constants.MagicResistancePerIntelligence * _attributesMap[AttributeNames.Intelligence];
    }

    private float GetFireResistance()
    {
        return _attributesMap[AttributeNames.FireResistance] + Constants.MagicResistancePerIntelligence * _attributesMap[AttributeNames.Intelligence];
    }

    private float GetFrostResistance()
    {
        return _attributesMap[AttributeNames.FrostResistance] + Constants.MagicResistancePerIntelligence * _attributesMap[AttributeNames.Intelligence];
    }

    private float GetNatureResistance()
    {
        return _attributesMap[AttributeNames.NatureResistance] + Constants.MagicResistancePerIntelligence * _attributesMap[AttributeNames.Intelligence];
    }

    private float GetAgillity()
    {
        return _attributesMap[AttributeNames.Agility];
    }

    private float GetAttackDamage()
    {
        return Constants.AttackDamagePerStrength * _attributesMap[AttributeNames.Strength] + _attributesMap[AttributeNames.AttackDamage];
    }

    private float GetAttackSpeed()
    {
        return Constants.AttackSpeedPerAgility * _attributesMap[AttributeNames.Agility] + _attributesMap[AttributeNames.AttackSpeed];
    }

    private float GetEvasionChance()
    {
        return Constants.EvasionChancePerAgility * _attributesMap[AttributeNames.Agility] + _attributesMap[AttributeNames.EvasionChance];
    }

    private float GetIntelligence()
    {
        return _attributesMap[AttributeNames.Intelligence];
    }

    private float GetMaxHealth()
    {
        return _attributesMap[AttributeNames.MaxHealth];
    }

    private float GetMovementSpeed()
    {
        return Mathf.Clamp(
            Constants.MovementSpeedPerAgility * _attributesMap[AttributeNames.Agility] + _attributesMap[AttributeNames.MovementSpeed], 
            Constants.MinMovementSpeed, 
            Constants.MaxMovementSpeed
            );
    }

    private float GetJumpPower()
    {
        return Mathf.Clamp(
            Constants.JumpPowerPerStrength * _attributesMap[AttributeNames.Strength] + _attributesMap[AttributeNames.JumpPower],
            Constants.MinJumpPower,
            Constants.MaxJumpPower
            );
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

    private IEnumerator IncreasingDamageTypeTemporarily(DamageType damageTypeName, float amount, float duration)
    {
        _additionalDamageTypesMap[damageTypeName] += amount;

        yield return new WaitForSeconds(duration);

        _additionalDamageTypesMap[damageTypeName] -= amount;
    }

    public void IncreaseDamageTypeTemporarily(DamageType damageTypeName, float amount, float duration)
    {
        StartCoroutine(IncreasingDamageTypeTemporarily(damageTypeName, amount, duration));
    }

    public void IncreaseDamageTypePermanently(DamageType damageTypeName, float amount)
    {
        _additionalDamageTypesMap[damageTypeName] += amount;
    }

    public float GetAttributeValue(AttributeNames attributeName)
    {
        return _attributesMap[attributeName];
    }
}
