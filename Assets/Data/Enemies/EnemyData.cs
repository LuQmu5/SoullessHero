using UnityEngine;

[CreateAssetMenu(menuName = "Create New Enemy Data", fileName = "New Enemy Data", order = 54)]
public class EnemyData : ScriptableObject
{
    [SerializeField] private float _maxHealth;

    public float MaxHealth => _maxHealth;
}