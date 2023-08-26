using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : State
{
    [SerializeField] private AnimationNames _animationName;

    protected EnemyController EnemyController { get; private set; }

    private void Awake()
    {
        EnemyController = GetComponent<EnemyController>();
    }

    public override void Enter()
    {
        base.Enter();

        EnemyController.PlayAnimation(_animationName.ToString());
    }
}
