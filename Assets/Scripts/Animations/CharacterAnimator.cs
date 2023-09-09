using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    private Animator _animator;
    private const string AttackSpeed = nameof(AttackSpeed);

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimation(string name)
    {
        _animator.Play(name);
    }

    public float GetCurrentAnimationLength()
    {
        return _animator.GetCurrentAnimatorStateInfo(0).length;
    }

    public void SetAttackSpeed(float value)
    {
        _animator.SetFloat(AttackSpeed, value);
    }
}