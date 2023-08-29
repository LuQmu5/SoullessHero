using UnityEngine;

[CreateAssetMenu(menuName = "Create New Enemy Data", fileName = "New Enemy Data", order = 54)]
public class EnemyData : ScriptableObject
{
    [SerializeField] private float _attackDamage;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _movementSpeed;

    public float AttackDamage => _attackDamage;
    public float AttackRange => _attackRange;
    public float AttackSpeed => _attackSpeed;
    public float MaxHealth => _maxHealth;
    public float MovementSpeed => _movementSpeed;
}