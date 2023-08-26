using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private BoxCollider2D _attachedAreaCollider;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private EnemyDetectionSystem _detectionSystem;
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

        _attachedArea = new Rect(
            _attachedAreaCollider.bounds.min.x, 
            _attachedAreaCollider.bounds.min.y, 
            _attachedAreaCollider.size.x, 
            _attachedAreaCollider.size.y);

        Destroy(_attachedAreaCollider);

        _detectionSystem.Init(_attachedArea, _player);
    }

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

    public void PlayAnimation(string name)
    {
        _animator.Play(name);
    }
}

public class EnemyMovementSystem : MonoBehaviour
{
    private Rect _attachedArea;
    private float _movementSpeed = 2;
    private PlayerController _player;

    public void Init(Rect attachedArea, float movementSpeed, PlayerController player)
    {
        _attachedArea = attachedArea;
        _movementSpeed = movementSpeed;
        _player = player;
    }

    private IEnumerator Patroling()
    {
        var destinationOffset = 0.1f;
        Vector3 normalRotation = Vector3.zero;
        Vector3 flippedRotation = new Vector3(0, 180, 0);

        while (true)
        {
            var destination = new Vector3(Random.Range(_attachedArea.xMin, _attachedArea.xMax), transform.position.y);
            transform.eulerAngles = destination.x > transform.position.x ? normalRotation : flippedRotation;

            while (Vector2.Distance(transform.position, destination) > destinationOffset)
            {
                transform.position = Vector2.MoveTowards(transform.position, destination, Time.deltaTime * _movementSpeed);

                yield return null;
            }
        }
    }

    private IEnumerator Following()
    {
        Vector3 normalRotation = Vector3.zero;
        Vector3 flippedRotation = new Vector3(0, 180, 0);

        while (true)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                new Vector3(_player.transform.position.x, transform.position.y),
                Time.deltaTime * _movementSpeed);

            transform.eulerAngles = _player.transform.position.x > transform.position.x ? normalRotation : flippedRotation;

            yield return null;
        }
    }
}

public class EnemyCobatSystem : MonoBehaviour
{

}
