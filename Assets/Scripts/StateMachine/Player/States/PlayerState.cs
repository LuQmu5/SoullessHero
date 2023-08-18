using UnityEngine;

public class PlayerState : State
{
    [SerializeField] private AnimationNames _animationName;

    protected string AnimationNameExtension =  "";
    protected PlayerController PlayerController { get; private set; }

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }

    public override void Enter()
    {
        base.Enter();

        PlayerController.PlayAnimation(_animationName.ToString() + AnimationNameExtension);
    }
}
