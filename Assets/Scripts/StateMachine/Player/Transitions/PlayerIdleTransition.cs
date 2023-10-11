public class PlayerIdleTransition : PlayerTransition
{
    private const float MinVectorLengthToTransit = 0.1f;

    private void Update()
    {
        if (Controller.Velocity.sqrMagnitude < MinVectorLengthToTransit && Controller.IsAttacking == false && Controller.IsCasting == false)
        {
            NeedTransit = true;
        }
    }
}
