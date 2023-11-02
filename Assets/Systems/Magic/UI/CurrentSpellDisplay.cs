using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentSpellDisplay : MonoBehaviour
{
    [SerializeField] private PlayerMagic _playerMagic;

    [Header("UI")]
    [SerializeField] private Image _icon;
    [SerializeField] private Color _normalColor = Color.white;
    [SerializeField] private Color _notEnoughShardsColor;

    private int _spellLevel;

    private void OnEnable()
    {
        SpellDisplay.SpellChoosen += OnSpellChoosen;
        _playerMagic.CurrentSoulShardsCountChanged += OnCurrentSoulShardsCountChanged;
    }

    private void OnDisable()
    {
        SpellDisplay.SpellChoosen -= OnSpellChoosen;
        _playerMagic.CurrentSoulShardsCountChanged -= OnCurrentSoulShardsCountChanged;
    }

    private void OnCurrentSoulShardsCountChanged(int amount)
    {
        TryChangeIconColor(amount);
    }

    private void TryChangeIconColor(int amount)
    {
        if (amount < _spellLevel)
            _icon.color = _notEnoughShardsColor;
        else
            _icon.color = _normalColor;
    }

    private void OnSpellChoosen(MagicSpell magicSpell)
    {
        _icon.sprite = magicSpell.Data.Icon;
        _spellLevel = magicSpell.Data.Level;

        TryChangeIconColor(_playerMagic.CurrentSoulShardCount);
    }
}
