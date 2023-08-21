public class EnemyPatrolTransition : EnemyTransition
{
    private void Update()
    {
        if (EnemyController.PlayerInArea == false || FindObjectOfType<PlayerController>().gameObject.activeSelf == false)
        {
            NeedTransit = true;
        }
    }
}
