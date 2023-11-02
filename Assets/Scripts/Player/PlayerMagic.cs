using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMagic : MonoBehaviour
{
    private MagicSpell _currentActiveSpell;
    private int _currentSoulShardsCount;
    private int _maxSoulShardsCount;
    private int _secondsToRestoreSoulShard = 3;
    private Coroutine _soulShardRestoringCoroutine;
    private CharacterAnimator _animator;
    private AttributesManager _attributesManager;
    private Transform _spellPoint;

    public int MaxSoulShardsCount => _maxSoulShardsCount;
    public int CurrentSoulShardCount => _currentSoulShardsCount;
    public int SecondsToRestoreSoulShard => _secondsToRestoreSoulShard;
    public bool IsCasting { get; private set; } = false;

    public event UnityAction<int> CurrentSoulShardsCountChanged;

    public void Init(CharacterAnimator animator, AttributesManager attributesManager, Transform spellPoint)
    {
        _maxSoulShardsCount = Constants.StartSoulShardsCount;
        _currentSoulShardsCount = _maxSoulShardsCount;
        CurrentSoulShardsCountChanged?.Invoke(_currentSoulShardsCount);

        _animator = animator;
        _attributesManager = attributesManager;
        _spellPoint = spellPoint;
    }

    private void OnEnable()
    {
        SpellDisplay.SpellChoosen += OnSpellChoosen;
    }

    private void OnDisable()
    {
        SpellDisplay.SpellChoosen -= OnSpellChoosen;
    }

    private void OnSpellChoosen(MagicSpell magicSpell)
    {
        _currentActiveSpell = magicSpell;
    }
    
    private IEnumerator SoulShardRestoring()
    {
        while (_currentSoulShardsCount < _maxSoulShardsCount)
        {
            yield return new WaitForSeconds(_secondsToRestoreSoulShard);

            _currentSoulShardsCount++;
            CurrentSoulShardsCountChanged?.Invoke(_currentSoulShardsCount);
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
        _currentActiveSpell.gameObject.SetActive(true);
        _currentActiveSpell.Use(_attributesManager);

        CurrentSoulShardsCountChanged?.Invoke(_currentSoulShardsCount);

        if (_soulShardRestoringCoroutine != null)
            StopCoroutine(_soulShardRestoringCoroutine);

        _soulShardRestoringCoroutine = StartCoroutine(SoulShardRestoring());

        IsCasting = false;
    }

    public void TryCastSpell()
    {
        if (_currentActiveSpell == null)
            return;

        if (_currentSoulShardsCount < _currentActiveSpell.Data.Level)
            return;

        StartCoroutine(Casting());
    }
}
