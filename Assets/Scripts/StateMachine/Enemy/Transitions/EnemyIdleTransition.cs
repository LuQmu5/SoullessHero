public class EnemyIdleTransition : EnemyTransition
{
    private void Update()
    {
        if (EnemyController.IsIdling)
            NeedTransit = true;
    }
}
