using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimation(string name)
    {
        _animator.Play(name);
    }

    public void StopPlayback()
    {
        _animator.StopPlayback();
    }
}