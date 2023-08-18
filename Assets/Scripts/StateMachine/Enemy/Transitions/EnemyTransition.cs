using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTransition : Transition
{
    protected EnemyController EnemyController { get; private set; }

    private void Awake()
    {
        EnemyController = GetComponent<EnemyController>();
    }
}
