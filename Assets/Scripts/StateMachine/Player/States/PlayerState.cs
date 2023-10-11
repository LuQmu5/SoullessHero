using UnityEngine;

public class PlayerState : State
{
    [SerializeField] private AnimationNames _animationName;

    protected string AnimationNameExtension =  "";
    protected PlayerController Controller { get; private set; }

    private void Awake()
    {
        Controller = GetComponent<PlayerController>();
    }

    public override void Enter()
    {
        base.Enter();

        Controller.PlayAnimation(_animationName.ToString() + AnimationNameExtension);
    }
}
