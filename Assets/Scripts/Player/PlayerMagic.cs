using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMagic : MonoBehaviour
{
    private int _currentSoulShardsCount = 3;
    private int _maxSoulShardsCount = 3;
    private int _secondsToRestoreSoulShard = 3;
    private Coroutine _soulShardRestoringCoroutine;
    private MagicSpell _currentActiveSpell;
    private float _timer;

    public int MaxSoulShardsCount => _maxSoulShardsCount;
    public int CurrentSoulShardsCount => _currentSoulShardsCount;
    public int SecondsToRestoreSoulShard => _secondsToRestoreSoulShard;

    public event UnityAction<int> CurrentSoulShardsCountChanged;

    private void Start()
    {
        CurrentSoulShardsCountChanged?.Invoke(_currentSoulShardsCount);
    }

    public bool TryCastSpell()
    {
        /*
        if (_currentActiveSpell == null)
            return false;

        if (_currentSoulShardsCount < _currentActiveSpell.Level)
            return false;


        _currentActiveSpell.Use();

        _currentSoulShardsCount -= _currentActiveSpell.Level;
        */

        _currentSoulShardsCount -= 1; // for tests
        CurrentSoulShardsCountChanged?.Invoke(_currentSoulShardsCount);

        return true;
    }
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            TryCastSpell();
        }

        if (_currentSoulShardsCount < _maxSoulShardsCount)
        {
            _timer += Time.deltaTime;

            if (_timer >= _secondsToRestoreSoulShard)
            {
                _timer = 0;
                _currentSoulShardsCount++;
                print(_currentSoulShardsCount);
            }
        }
    }
}
