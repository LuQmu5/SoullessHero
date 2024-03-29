using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AttributesManager))]
[RequireComponent(typeof(CharacterAnimator))]
[RequireComponent(typeof(EnemyCombatSystem))]
[RequireComponent(typeof(EnemyDetectionSystem))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(EnemyMovementSystem))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private BoxCollider2D _attachedAreaCollider;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange;
    [SerializeField] private DamageType _damageType;
    [SerializeField] private bool _isFlying;

    private AttributesManager _attributesManager;
    private CharacterAnimator _animator;
    private EnemyCombatSystem _combatSystem;
    private EnemyDetectionSystem _detectionSystem;
    private Health _health;
    private EnemyMovementSystem _movementSystem;
    private Rect _attachedArea;

    public PlayerController Player => _player;
    public bool IsPlayerInArea => _detectionSystem.IsPlayerInArea;
    public bool IsPlayerDetected => _detectionSystem.IsPlayerDetected;
    public bool IsPlayerInAttackRange => _combatSystem.IsPlayerInAttackRange;
    public bool IsPlayerAlive => _player.gameObject.activeSelf;

    public static event UnityAction<EnemyController> Died;

    private void Awake()
    {
        _attributesManager = GetComponent<AttributesManager>();
        _animator = GetComponent<CharacterAnimator>();
        _combatSystem = GetComponent<EnemyCombatSystem>();
        _detectionSystem = GetComponent<EnemyDetectionSystem>();
        _health = GetComponent<Health>();
        _movementSystem = GetComponent<EnemyMovementSystem>();

        GenerateAttachedArea();

        _attributesManager.Init();
        _combatSystem.Init(_animator, _attackPoint, _attackRange, _attributesManager.AttackDamage, _damageType, _attributesManager);
        _detectionSystem.Init(_attachedArea, _player);
        _health.Init(_attributesManager);
        _movementSystem.Init(_attachedArea, _attributesManager.MovementSpeed, _player, _isFlying);
    }

    private void OnEnable()
    {
        _health.Over += OnHealthOver;
    }

    private void OnDisable()
    {
        _health.Over -= OnHealthOver;
    }

    private void OnHealthOver()
    {
        Died?.Invoke(this);
    }

    private void GenerateAttachedArea()
    {
        _attachedArea = new Rect(
            _attachedAreaCollider.bounds.min.x,
            _attachedAreaCollider.bounds.min.y,
            _attachedAreaCollider.size.x,
            _attachedAreaCollider.size.y);

        Destroy(_attachedAreaCollider);
    }

    public void PlayAnimation(string name)
    {
        _animator.PlayAnimation(name);
    }

    public void SwitchFollowingState(bool state)
    {
        _movementSystem.SwitchFollowingState(state);
    }

    public void SwitchPatrolingState(bool state)
    {
        _movementSystem.SwitchPatrolingState(state);
    }
}
