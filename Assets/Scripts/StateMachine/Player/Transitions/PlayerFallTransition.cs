public class PlayerFallTransition : PlayerTransition
{
    private void Update()
    {
        float minVelocityYToTransit = -0.01f;

        if (PlayerController.Velocity.y < minVelocityYToTransit && PlayerController.IsAttacking == false)
        {
            NeedTransit = true;
        }
    }
}