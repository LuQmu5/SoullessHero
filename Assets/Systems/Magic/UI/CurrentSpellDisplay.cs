using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentSpellDisplay : MonoBehaviour
{
    [SerializeField] private Image _icon;

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
        _icon.sprite = data.Icon;
    }
}
