using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _patrolAreaCollider;
    [SerializeField] private float _speed = 2;

    private Animator _animator;
    private Rect _patrolArea;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        _patrolArea = new Rect(
            transform.position.x - _patrolAreaCollider.size.x / 2,
            transform.position.y - _patrolAreaCollider.size.y / 2,
            _patrolAreaCollider.size.x,
            _patrolAreaCollider.size.y
            );

        _patrolAreaCollider.enabled = false;
    }

    private void Start()
    {
        StartCoroutine(Patroling());
    }

    public void PlayAnimation(string name)
    {
        _animator.Play(name);
    }

    private IEnumerator Patroling()
    {
        var destinationOffset = 0.1f;
        var minWaitTime = 2f;
        var maxWaitTime = 4f;

        while (true)
        {
            var destination = new Vector3(Random.Range(_patrolArea.xMin, _patrolArea.xMax), transform.position.y);

            if (destination.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

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
}
