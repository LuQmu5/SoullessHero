public class PlayerIdleTransition : PlayerTransition
{
    private const float MinVectorLengthToTransit = 0.1f;

    private void Update()
    {
        if (PlayerController.Velocity.sqrMagnitude < MinVectorLengthToTransit && PlayerController.IsAttacking == false)
        {
            NeedTransit = true;
        }
    }
}
