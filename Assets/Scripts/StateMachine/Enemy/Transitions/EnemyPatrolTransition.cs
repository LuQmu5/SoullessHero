public class EnemyPatrolTransition : EnemyTransition
{
    private void Update()
    {
        if (EnemyController.IsPlayerInArea == false || EnemyController.IsPlayerAlive == false)
            NeedTransit = true;
    }
}
