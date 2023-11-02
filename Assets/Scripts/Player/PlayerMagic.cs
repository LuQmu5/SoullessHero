﻿using System;
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
    public int SecondsToRestoreSoulShard => _secondsToRestoreSoulShard;
    public bool IsCasting { get; private set; } = false;

    public event UnityAction<int> CurrentSoulShardsCountChanged;

    public void Init(CharacterAnimator animator, AttributesManager attributesManager, Transform spellPoint)
    {
        _maxSoulShardsCount = Constants.MaxSoulShardsCount;
        _currentSoulShardsCount = Constants.StartSoulShardsCount;

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

    private void OnSpellChoosen(SpellData data)
    {
        _currentActiveSpell = data.MagicSpell;
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
        var spell = Instantiate(_currentActiveSpell, _spellPoint.position, Quaternion.identity); // залазем в дату из книги заклинаний, а там хранится префаб
        spell.Use(_attributesManager);

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
