using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private PlayerState _startState;

    private PlayerState _currentState;

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

    private void ChangeState(PlayerState nextState)
    {
        _currentState.Exit();
        _currentState = nextState;
        _currentState.Enter();
    }
}
