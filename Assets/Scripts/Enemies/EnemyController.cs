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

    private Animator _animator;
    private Rect _patrolArea;

    private Coroutine _patrolingCoroutine;
    private Coroutine _followingCoroutine;

    public bool PlayerInArea { get; private set; }
    public bool IsPlayerDetected { get; private set; }

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

    private void Start()
    {
        StartCoroutine(RayCasting());  
    }

    private void Update()
    {
        PlayerInArea = CheckingPlayerInArea();
        IsPlayerDetected = TryDetectPlayer();
    }

    private bool CheckingPlayerInArea()
    {
        var player = FindObjectOfType<PlayerController>().transform;

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

    private IEnumerator RayCasting()
    {
        while (true)
        {
            var hit = Physics2D.Raycast(_attackPoint.position, transform.right, _attackRange);
            Debug.DrawRay(_attackPoint.position, transform.right * _attackRange, Color.red);

            if (hit.collider != null && hit.collider.TryGetComponent(out PlayerController player))
            {
                print("attack");
            }

            yield return null;
        }
    }

    private IEnumerator Following()
    {
        Vector3 normalRotation = Vector3.zero;
        Vector3 flippedRotation = new Vector3(0, 180, 0);
        var followTarget = FindObjectOfType<PlayerController>().transform;

        while (true)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                followTarget.position,
                Time.deltaTime * _movementSpeed);

            transform.eulerAngles = followTarget.transform.position.x > transform.position.x ? normalRotation : flippedRotation;

            yield return null;
        }
    }

    private IEnumerator Patroling()
    {
        var destinationOffset = 0.1f;
        var minWaitTime = 2f;
        var maxWaitTime = 4f;
        Vector3 normalRotation = Vector3.zero;
        Vector3 flippedRotation = new Vector3(0, 180, 0);

        while (true)
        {
            var destination = new Vector3(Random.Range(_patrolArea.xMin, _patrolArea.xMax), transform.position.y);

            transform.eulerAngles = destination.x > transform.position.x? normalRotation : flippedRotation;
            _animator.Play(AnimationNames.Run.ToString());

            while (Vector2.Distance(transform.position, destination) > destinationOffset)
            {
                transform.position = Vector2.MoveTowards(transform.position, destination, Time.deltaTime * _movementSpeed);

                yield return null;
            }

            _animator.Play(AnimationNames.Idle.ToString());

            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        }
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
        _followingCoroutine = StartCoroutine(Patroling());
    }

    public void StopFollowing()
    {
        StopCoroutine(_followingCoroutine);
    }
}
