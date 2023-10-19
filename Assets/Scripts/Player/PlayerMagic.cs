using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMagic : MonoBehaviour
{
    [SerializeField] private MagicSpell _currentActiveSpell;

    private int _currentSoulShardsCount = 10;
    private int _maxSoulShardsCount = 10;
    private int _secondsToRestoreSoulShard = 3;
    private Coroutine _soulShardRestoringCoroutine;
    private CharacterAnimator _animator;
    private AttributesManager _attributesManager;

    public int MaxSoulShardsCount => _maxSoulShardsCount;
    public int SecondsToRestoreSoulShard => _secondsToRestoreSoulShard;
    public bool IsCasting { get; private set; } = false;

    public event UnityAction<int> CurrentSoulShardsCountChanged;

    public void Init(CharacterAnimator animator, AttributesManager attributesManager)
    {
        _animator = animator;
        _attributesManager = attributesManager;
    }

    public void TryCastSpell()
    {
        if (_currentActiveSpell == null)
            return;

        if (_currentSoulShardsCount < _currentActiveSpell.Data.Level)
            return;

        StartCoroutine(Casting());
    }
    
    private IEnumerator SoulShardRestoring()
    {
        while (_currentSoulShardsCount < _maxSoulShardsCount)
        {
            yield return new WaitForSeconds(_secondsToRestoreSoulShard);

            _currentSoulShardsCount++;
        }

        _soulShardRestoringCoroutine = null;
    }

    private IEnumerator Casting()
    {
        IsCasting = true;

        yield return new WaitForEndOfFrame();

        float animationTime = _animator.GetCurrentAnimationLength();

        yield return new WaitForSeconds(animationTime);

        _currentSoulShardsCount -= _currentActiveSpell.Data.Level;
        var spell = Instantiate(_currentActiveSpell);
        spell.Use(_attributesManager);

        CurrentSoulShardsCountChanged?.Invoke(_currentSoulShardsCount);

        if (_soulShardRestoringCoroutine != null)
            StopCoroutine(_soulShardRestoringCoroutine);

        _soulShardRestoringCoroutine = StartCoroutine(SoulShardRestoring());

        IsCasting = false;
    }
}
