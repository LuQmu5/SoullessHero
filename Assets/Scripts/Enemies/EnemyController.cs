using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private BoxCollider2D _attachedAreaCollider;
    [SerializeField] private Transform _attackPoint;

    [SerializeField] private EnemyDetectionSystem _detectionSystem;
    [SerializeField] private EnemyMovementSystem _movementSystem;
    [SerializeField] private EnemyCobatSystem _combatSystem;

    [SerializeField] private float _movementSpeed = 2;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private float _damage = 2;

    private Animator _animator;
    private Rect _attachedArea;

    public bool IsPlayerInArea => _detectionSystem.IsPlayerInArea;
    public bool IsPlayerDetected => _detectionSystem.IsPlayerDetected;
    public bool IsPlayerInAttackRange { get; private set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        GenerateAttachedArea();

        _detectionSystem.Init(_attachedArea, _player);
        _movementSystem.Init(_attachedArea, _movementSpeed, _player);
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
        _animator.Play(name);
    }
}

public class EnemyCobatSystem : MonoBehaviour
{
    private bool CheckingPlayerInAttackRange()
    {
        var hit = Physics2D.Raycast(_attackPoint.position, transform.right, _attackRange);
        Debug.DrawRay(_attackPoint.position, transform.right * _attackRange, Color.red);

        return (hit.collider != null && hit.collider.TryGetComponent(out PlayerController player));
    }

    private IEnumerator Attacking()
    {
        float delay = 0.1f;

        yield return new WaitForSeconds(delay);

        float animationTime = _animator.GetCurrentAnimatorStateInfo(0).length;
        float animationTimeReduce = 2;

        while (true)
        {
            yield return new WaitForSeconds(animationTime / animationTimeReduce);

            var hits = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange);

            foreach (var hit in hits)
            {
                if (hit.TryGetComponent(out Health health) && hit.TryGetComponent(out EnemyController enemy) == false)
                {
                    health.ApplyDamage(_damage, transform);
                }
            }

            yield return new WaitForSeconds(animationTime / animationTimeReduce);
        }
    }
}
