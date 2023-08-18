using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _patrolAreaCollider;

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
    }

    public void PlayAnimation(string name)
    {
        _animator.Play(name);
    }
}
