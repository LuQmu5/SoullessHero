public class EnemyFollowTransition : EnemyTransition
{
    private void Update()
    {
        if (EnemyController.PlayerInArea && EnemyController.IsPlayerDetected)
        {
            NeedTransit = true;
        }
    }
}