using UnityEngine;

public class EnemyIdleTransition : EnemyTransition
{
    private float _minWaitTime = 1;
    private float _maxWaitTIme = 4;
    private float _waitTime;

    protected override void OnEnable()
    {
        base.OnEnable();

        _waitTime = Random.Range(_minWaitTime, _maxWaitTIme);
    }

    private void Update()
    {
        _waitTime -= Time.deltaTime;

        if (_waitTime <= 0)
        {
            NeedTransit = true;
        }
    }
}
