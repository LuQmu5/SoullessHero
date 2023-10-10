using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulShardsDisplay : MonoBehaviour
{
    [SerializeField] private List<Image> _images = new List<Image>();
    [SerializeField] private PlayerMagic _playerMagic;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _playerMagic.CurrentSoulShardsCountChanged += OnCurrentSoulShardsCountChanged;
    }

    private void OnDisable()
    {
        _playerMagic.CurrentSoulShardsCountChanged -= OnCurrentSoulShardsCountChanged;
    }

    private void OnCurrentSoulShardsCountChanged(int amount)
    {
        for (int i = _images.Count - 1; i >= _playerMagic.CurrentSoulShardsCount; i--)
        {
            _images[i].color = new Color(1, 1, 1, 0);
        }

        if (_coroutine == null)
            _coroutine = StartCoroutine(Restoring());
    }

    private IEnumerator Restoring()
    {
        while (_playerMagic.CurrentSoulShardsCount < _playerMagic.MaxSoulShardsCount)
        {
            float alpha = 0;

            while (alpha < 1 && _playerMagic.CurrentSoulShardsCount != _playerMagic.MaxSoulShardsCount)
            {
                _images[_playerMagic.CurrentSoulShardsCount].color = new Color(1, 1, 1, alpha);
                alpha += Time.deltaTime / _playerMagic.SecondsToRestoreSoulShard;

                yield return null;
            }
        }

        _coroutine = null;
    }
}