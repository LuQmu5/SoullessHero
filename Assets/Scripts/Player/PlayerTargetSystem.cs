using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetSystem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _targetMark;
    [SerializeField] private float _minDetectRange = 10;

    private List<EnemyController> _closestEnemies;
    private EnemyController _currentTarget;
    private int _currentEnemyIndex = 0;

    public void Awake()
    {
        _closestEnemies = new List<EnemyController>();

        var detectArea = gameObject.AddComponent<BoxCollider2D>();
        detectArea.isTrigger = true;
        detectArea.size = new Vector2(_minDetectRange, _minDetectRange);
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
            _targetMark.transform.position = _currentTarget.transform.position + new Vector3(0, 2);
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