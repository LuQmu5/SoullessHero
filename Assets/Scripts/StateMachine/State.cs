﻿using UnityEngine;

public class State : MonoBehaviour
{
    [SerializeField] private PlayerTransition[] _transitions;

    public virtual void Enter()
    {
        enabled = true;

        foreach (var transition in _transitions)
            transition.enabled = true;
    }

    public virtual void Exit()
    {
        foreach (var transition in _transitions)
            transition.enabled = false;

        enabled = false;
    }

    public PlayerState TryGetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }

        return null;
    }
}
