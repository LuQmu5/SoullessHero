public class PlayerIdleTransition : PlayerTransition
{
    private void Update()
    {
        float minVectorLengthToTransit = 0.1f;

        if (PlayerController.Velocity.sqrMagnitude < minVectorLengthToTransit && PlayerController.IsAttacking == false)
        {
            NeedTransit = true;
        }
    }
}
