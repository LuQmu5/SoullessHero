public class PlayerFallTransition : PlayerTransition
{
    private void Update()
    {
        if (PlayerController.Velocity.y < -0.01f && PlayerController.IsAttacking == false)
        {
            NeedTransit = true;
        }
    }
}