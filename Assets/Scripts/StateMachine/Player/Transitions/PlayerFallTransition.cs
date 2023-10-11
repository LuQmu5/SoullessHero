public class PlayerFallTransition : PlayerTransition
{
    private const float MinVelocityYToTransit = -0.01f;

    private void Update()
    {
        if (PlayerController.Velocity.y < MinVelocityYToTransit && PlayerController.IsAttacking == false)
        {
            NeedTransit = true;
        }
    }
}