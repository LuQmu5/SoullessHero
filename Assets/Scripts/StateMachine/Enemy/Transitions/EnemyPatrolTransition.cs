public class EnemyPatrolTransition : EnemyTransition
{
    protected override void OnEnable()
    {
        base.OnEnable();

        // EnemyController.PlayerLost += OnPlayerLost;
    }

    private void OnDisable()
    {
        // EnemyController.PlayerLost -= OnPlayerLost;
    }

    private void OnPlayerLost()
    {
        NeedTransit = true;
    }
}