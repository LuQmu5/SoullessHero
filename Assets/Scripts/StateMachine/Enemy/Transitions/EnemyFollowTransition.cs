public class EnemyFollowTransition : EnemyTransition
{
    private void Update()
    {
        if (EnemyController.IsPlayerInArea && EnemyController.IsPlayerDetected && EnemyController.IsPlayerInAttackRange == false)
            NeedTransit = true;
    }
}