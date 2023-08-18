using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : State
{
    protected EnemyController EnemyController { get; private set; }

    private void Awake()
    {
        EnemyController = GetComponent<EnemyController>();
    }

    public override void Enter()
    {
        base.Enter();

        EnemyController.PlayAnimation(AnimationName.ToString());
    }
}
