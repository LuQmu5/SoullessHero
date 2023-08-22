using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _patrolAreaCollider;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _movementSpeed = 2;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private float _damage = 2;

    private Animator _animator;
    private Rect _patrolArea;

    private Coroutine _patrolingCoroutine;
    private Coroutine _idlingCoroutine;
    private Coroutine _followingCoroutine;
    private Coroutine _attackingCoroutine;

    public bool IsPlayerInArea { get; private set; }
    public bool IsPlayerDetected { get; private set; }
    public bool IsPlayerInAttackRange { get; private set; }
    public bool IsIdling { get; private set; } = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        _patrolArea = new Rect(
            _patrolAreaCollider.bounds.min.x, 
            _patrolAreaCollider.bounds.min.y, 
            _patrolAreaCollider.size.x, 
            _patrolAreaCollider.size.y);

        _patrolAreaCollider.enabled = false;
    }

    private void Update()
    {
        IsPlayerInArea = CheckingPlayerInArea();
        IsPlayerDetected = TryDetectPlayer();
        IsPlayerInAttackRange = CheckingPlayerInAttackRange();
    }

    private bool CheckingPlayerInArea()
    {
        var player = FindObjectOfType<PlayerController>().transform; // костыль

        if (player.transform.position.x > _patrolArea.xMax)
            return false;

        if (player.transform.position.x < _patrolArea.xMin)
            return false;

        if (player.transform.position.y > _patrolArea.yMax)
            return false;

        if (player.transform.position.y < _patrolArea.yMin)
            return false;

        return true;
    }

    private bool TryDetectPlayer()
    {
        float boxAngle = 0;
        float areaReduceCoeff = 2;
        Vector2 boxSize = new Vector2(_patrolArea.width, _patrolArea.height);

        var hits = Physics2D.OverlapBoxAll(transform.position, boxSize / areaReduceCoeff, boxAngle);

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out PlayerController player))
            {
                return true;
            }
        }

        return false;
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
                    health.ApplyDamage(_damage);
                }
            }

            yield return new WaitForSeconds(animationTime / animationTimeReduce);
        }
    }

    private IEnumerator Following()
    {
        Vector3 normalRotation = Vector3.zero;
        Vector3 flippedRotation = new Vector3(0, 180, 0);
        var followTarget = FindObjectOfType<PlayerController>().transform; // костыль

        while (true)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                new Vector3(followTarget.position.x, transform.position.y),
                Time.deltaTime * _movementSpeed);

            transform.eulerAngles = followTarget.transform.position.x > transform.position.x ? normalRotation : flippedRotation;

            yield return null;
        }
    }

    private IEnumerator Patroling()
    {
        var destinationOffset = 0.1f;
        Vector3 normalRotation = Vector3.zero;
        Vector3 flippedRotation = new Vector3(0, 180, 0);

        while (true)
        {
            var destination = new Vector3(Random.Range(_patrolArea.xMin, _patrolArea.xMax), transform.position.y);
            transform.eulerAngles = destination.x > transform.position.x ? normalRotation : flippedRotation;

            while (Vector2.Distance(transform.position, destination) > destinationOffset)
            {
                transform.position = Vector2.MoveTowards(transform.position, destination, Time.deltaTime * _movementSpeed);

                yield return null;
            }
        }
    }

    private IEnumerator Idling()
    {
        float minWaitTime = 1;
        float maxWaitTime = 4;
        float waitTime = Random.Range(minWaitTime, maxWaitTime);
        IsIdling = true;

        yield return new WaitForSeconds(waitTime);

        IsIdling = false;
    }

    public void PlayAnimation(string name)
    {
        _animator.Play(name);
    }

    public void StartPatroling()
    {
        _patrolingCoroutine = StartCoroutine(Patroling());
    }

    public void StopPatroling()
    {
        StopCoroutine(_patrolingCoroutine);
    }

    public void StartFollowing()
    {
        _followingCoroutine = StartCoroutine(Following());
    }

    public void StopFollowing()
    {
        StopCoroutine(_followingCoroutine);
    }

    public void StartAttacking()
    {
        _attackingCoroutine = StartCoroutine(Attacking());
    }

    public void StopAttacking()
    {
        StopCoroutine(_attackingCoroutine);
    }

    public void StartIdling()
    {
        _idlingCoroutine = StartCoroutine(Idling());
    }

    public void StopIdling()
    {
        StopCoroutine(_idlingCoroutine);
    }
}
