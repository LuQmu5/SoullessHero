using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _patrolAreaCollider;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _attackRange = 0.5f;

    private Animator _animator;
    private Rect _patrolArea;
    private Coroutine _patrolingCoroutine;

    public event UnityAction PlayerDetected;

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
        StartCoroutine(Detecting());
        //StartCoroutine(RayCasting());
        StartCoroutine(Patroling());
        StartCoroutine(CheckingPlayerInArea());
    }

    private IEnumerator CheckingPlayerInArea()
    {
        var player = FindObjectOfType<PlayerController>().transform;

        while (true)
        {
            if (player.transform.position.x > _patrolArea.xMax || 
                player.transform.position.x < _patrolArea.xMin ||
                player.transform.position.y > _patrolArea.yMax ||
                player.transform.position.y < _patrolArea.yMin)
            {
                print("out of area");
            }

            yield return null;
        }
    }

    private IEnumerator Detecting()
    {
        float boxAngle = 0;
        float areaReduceCoeff = 2;
        Vector2 boxSize = new Vector2(_patrolArea.width, _patrolArea.height);

        while (true)
        {
            var hits = Physics2D.OverlapBoxAll(transform.position, boxSize / areaReduceCoeff, boxAngle);

            foreach (var hit in hits)
            {
                if (hit.TryGetComponent(out PlayerController player))
                {
                    print("Detected!");
                    break;
                }
            }

            yield return null;
        }
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
                transform.position = Vector2.MoveTowards(transform.position, destination, Time.deltaTime * _speed);

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
}
