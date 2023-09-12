using UnityEngine;

[CreateAssetMenu(fileName = "New Attributes Data", menuName = "Create New Attributes Data", order = 54)]
public class AttributesData : ScriptableObject
{
    [Header("Base Attributes")]
    [SerializeField] private float _agility;
    [SerializeField] private float _strength;
    [SerializeField] private float _intelligence;

    [Header("Combat Attributes")]
    [SerializeField] private float _attackDamage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _evasionChance;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _movementSpeed;

    [Header("Resistance Attributes")]
    [SerializeField] private float _fireResistance;
    [SerializeField] private float _frostResistance;
    [SerializeField] private float _natureResistance;
    [SerializeField] private float _shadowResistance;
    [SerializeField] private float _diabolicResistance;
    [SerializeField] private float _bloodResistance;
    [SerializeField] private float _arcaneResistance;
    [SerializeField] private float _holyResistance;
    [SerializeField] private float _mentalResistance;
    [SerializeField] private float _physicalResistance;

    public float Agility => _agility;
    public float Intelligence => _intelligence;
    public float Strength => _strength;

    public float AttackDamage => _attackDamage;
    public float AttackSpeed => _attackSpeed;
    public float EvasionChance => _evasionChance;
    public float MaxHealth => _maxHealth;
    public float MovementSpeed => _movementSpeed;

    public float FireResistance => _fireResistance;
    public float FrostResistance => _frostResistance;
    public float NatureResistance => _natureResistance;
    public float ShadowResistance => _shadowResistance;
    public float DiabolicResistance => _diabolicResistance;
    public float HolyResistance => _holyResistance;
    public float MentalResistance => _mentalResistance;
    public float PhysicalResistance => _physicalResistance;
    public float ArcaneResistance => _arcaneResistance;
    public float BloodResistance => _bloodResistance;
}