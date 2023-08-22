﻿public class EnemyPatrolTransition : EnemyTransition
{
    private void Update()
    {
        if ((EnemyController.IsPlayerInArea == false || FindObjectOfType<PlayerController>().gameObject.activeSelf == false) 
            && EnemyController.IsIdling == false)
        {
            NeedTransit = true;
        }
    }
}
