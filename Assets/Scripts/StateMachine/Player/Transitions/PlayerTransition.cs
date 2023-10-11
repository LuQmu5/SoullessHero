public class PlayerTransition : Transition
{
    protected PlayerController Controller { get; private set; }

    private void Awake()
    {
        Controller = GetComponent<PlayerController>();
    }
}
