using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMagic : MonoBehaviour
{
    private int _currentSoulShardsCount = 10;
    private int _maxSoulShardsCount = 10;
    private int _secondsToRestoreSoulShard = 3;
    private Coroutine _soulShardRestoringCoroutine;

    private MagicSpell _currentActiveSpell;
    private CharacterAnimator _animator;

    public int MaxSoulShardsCount => _maxSoulShardsCount;
    public int SecondsToRestoreSoulShard => _secondsToRestoreSoulShard;
    public bool IsCasting { get; private set; }

    public event UnityAction<int> CurrentSoulShardsCountChanged;

    public void Init(CharacterAnimator animator)
    {
        _animator = animator;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            TryCastSpell();
        }
    }

    public void TryCastSpell()
    {
        /*
        if (_currentActiveSpell == null)
            return;

        if (_currentSoulShardsCount < _currentActiveSpell.Level)
            return;


        _currentActiveSpell.Use();

        _currentSoulShardsCount -= _currentActiveSpell.Level;
        */

        _currentSoulShardsCount -= 2; // for tests


        CurrentSoulShardsCountChanged?.Invoke(_currentSoulShardsCount);

        if (_soulShardRestoringCoroutine != null)
            StopCoroutine(_soulShardRestoringCoroutine);

        _soulShardRestoringCoroutine = StartCoroutine(SoulShardRestoring());
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
}
