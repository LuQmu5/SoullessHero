public class PlayerFallTransition : PlayerTransition
{
    private const float MinVelocityYToTransit = -0.01f;

    private void Update()
    {
        if (Controller.Velocity.y < MinVelocityYToTransit && Controller.IsAttacking == false)
        {
            NeedTransit = true;
        }
    }
}