using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulShardsDisplay : MonoBehaviour
{
    [SerializeField] private PlayerMagic _playerMagic;

    private List<Image> _images = new List<Image>();
    private Coroutine _coroutine;

    private void Awake()
    {
        foreach (var child in transform.GetComponentsInChildren<Image>())
        {
            _images.Add(child);
        }
    }

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
        for (int i = _images.Count - 1; i >= amount; i--)
        {
            _images[i].color = _images[i].color.SetAlpha(0);
        }

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Restoring(amount));
    }

    private IEnumerator Restoring(int amount)
    {
        while (amount != _playerMagic.MaxSoulShardsCount)
        {
            float alpha = 0;

            while (alpha < 1)
            {
                _images[amount].color = _images[amount].color.SetAlpha(alpha);
                alpha += Time.deltaTime / _playerMagic.SecondsToRestoreSoulShard;

                yield return null;
            }

            amount++;
        }

        _coroutine = null;
    }
}