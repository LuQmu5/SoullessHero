using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetSystem : MonoBehaviour
{
    private SpriteRenderer _targetMark;
    private float _minDetectRange = 10;
    private List<EnemyController> _closestEnemies;
    private EnemyController _currentTarget;
    private int _currentEnemyIndex = 0;
    private Vector3 _tarketMarkOffset;

    public EnemyController ClosestEnemy => _currentTarget;

    public void Init(SpriteRenderer targetMark, float minDetectRange)
    {
        _targetMark = targetMark;
        _minDetectRange = minDetectRange;
        _closestEnemies = new List<EnemyController>();

        var detectArea = gameObject.AddComponent<BoxCollider2D>();
        detectArea.isTrigger = true;
        detectArea.size = new Vector2(_minDetectRange, _minDetectRange);

        _tarketMarkOffset = new Vector3(0, 1.2f);
    }

    private void OnEnable()
    {
        EnemyController.Died += OnEnemyDied;
        PlayerInput.SwitchTargetKeyPressed += OnSwitchTargetKeyPressed;
    }

    private void OnDisable()
    {
        EnemyController.Died -= OnEnemyDied;
        PlayerInput.SwitchTargetKeyPressed -= OnSwitchTargetKeyPressed;
    }

    private void Update()
    {
        if (_currentTarget != null)
            _targetMark.transform.position = _currentTarget.transform.position + _tarketMarkOffset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyController enemy))
        {
            if (_closestEnemies.Contains(enemy) == false)
            {
                _closestEnemies.Add(enemy);
                TrySwitchOnNextEnemy();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyController enemy))
        {
            if (_closestEnemies.Contains(enemy))
            {
                _closestEnemies.Remove(enemy);
                TrySwitchOnNextEnemy();
            }
        }
    }

    private void OnEnemyDied(EnemyController enemy)
    {
        if (_closestEnemies.Contains(enemy))
        {
            _closestEnemies.Remove(enemy);
        }

        if (_currentTarget == enemy)
        {
            TrySwitchOnNextEnemy();
        }
    }

    private void TrySwitchOnNextEnemy()
    {
        if (_closestEnemies.Count == 0)
        {
            _targetMark.gameObject.SetActive(false);
            return;
        }

        if (_currentEnemyIndex >= _closestEnemies.Count)
            _currentEnemyIndex = 0;

        _currentTarget = _closestEnemies[_currentEnemyIndex];
        _targetMark.gameObject.SetActive(true);
    }

    private void OnSwitchTargetKeyPressed()
    {
        _currentEnemyIndex++;

        TrySwitchOnNextEnemy();
    }
}