public class EnemyPatrolTransition : EnemyTransition
{
    private void Update()
    {
        if (EnemyController.IsPlayerInArea == false && EnemyController.IsIdling == false)
            NeedTransit = true;
    }
}
