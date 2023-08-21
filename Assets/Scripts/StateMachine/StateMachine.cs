using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    private State _currentState;

    private void Start()
    {
        _currentState = _startState;
        _currentState.Enter();
    }

    private void Update()
    {
        var nextState = _currentState.TryGetNextState();

        if (nextState != null)
            ChangeState(nextState);
    }

    private void ChangeState(State nextState)
    {
        _currentState.Exit();
        _currentState = nextState;
        _currentState.Enter();
    }
}
