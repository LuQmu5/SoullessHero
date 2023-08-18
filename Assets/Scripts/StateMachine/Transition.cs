using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private PlayerState _targetState;

    public PlayerState TargetState => _targetState;
    public bool NeedTransit { get; protected set; }

    protected virtual void OnEnable()
    {
        NeedTransit = false;
    }
}