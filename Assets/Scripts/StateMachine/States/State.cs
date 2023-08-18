using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    [SerializeField] private Transition[] _transitions;
    [SerializeField] private AnimationNames _animationName;

    protected PlayerController PlayerController { get; private set; }

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        print("qq");
    }

    public virtual void Enter()
    {
        enabled = true;

        foreach (var transition in _transitions)
            transition.enabled = true;

        PlayerController.PlayAnimation(_animationName.ToString());
    }

    public virtual void Exit()
    {
        foreach (var transition in _transitions)
            transition.enabled = false;

        enabled = false;
    }

    public State TryGetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }

        return null;
    }
}
