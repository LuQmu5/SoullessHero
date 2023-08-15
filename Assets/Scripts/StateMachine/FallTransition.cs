public class FallTransition : Transition
{
    private void Update()
    {
        if (PlayerController.Velocity.y < -0.1f)
        {
            NeedTransit = true;
        }
    }
}