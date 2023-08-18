public class PlayerState : State
{
    protected PlayerController PlayerController { get; private set; }

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        print("q");
    }

    public override void Enter()
    {
        base.Enter();

        PlayerController.PlayAnimation(AnimationName.ToString());
    }
}
