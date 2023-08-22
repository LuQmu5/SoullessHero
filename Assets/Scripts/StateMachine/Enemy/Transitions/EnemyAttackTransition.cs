public class EnemyAttackTransition : EnemyTransition
{
    private void Update()
    {
        if (EnemyController.IsPlayerInAttackRange)
            NeedTransit = true;
    }
}
