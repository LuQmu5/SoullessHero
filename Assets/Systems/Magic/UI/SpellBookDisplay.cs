using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpellBookDisplay : MonoBehaviour
{
    [SerializeField] private GameObject _wrapper;
    [SerializeField] private SpellBook _spellBook; 
    [SerializeField] private SpellDisplay _spellDisplayPrefab;
    [SerializeField] private GridLayoutGroup _spellContainer;

    [Header("Badges")]
    [SerializeField] private SpellsBadgeButton[] _spellsBadgeButtons;

    private const int SpellsCountOnOneFrame = 6;

    private void OnEnable()
    {
        PlayerInput.OpenSpellBookKeyPressed += OnOpenSpellBookKeyPressed;
        SpellsBadgeButton.BadgeClicked += OnBadgeClicked;
        SpellDisplay.SpellChoosen += OnSpellChoosen;
    }

    private void OnDisable()
    {
        PlayerInput.OpenSpellBookKeyPressed -= OnOpenSpellBookKeyPressed;
        SpellsBadgeButton.BadgeClicked -= OnBadgeClicked;
        SpellDisplay.SpellChoosen -= OnSpellChoosen;
    }

    private void OnSpellChoosen(SpellData data)
    {
        _wrapper.SetActive(false);
        PauseManager.Unpause();
    }

    private void OnOpenSpellBookKeyPressed()
    {
        _wrapper.SetActive(!_wrapper.activeSelf);

        if (_wrapper.activeSelf)
        {
            Draw();
            PauseManager.Pause();
        }
        else
        {
            PauseManager.Unpause();
        }
    }

    private void Draw()
    {
        int extraBadge = _spellBook.SpellsData.Count % SpellsCountOnOneFrame == 0 ? 0 : 1;
        int activatedSpellsBadgesCount = _spellBook.SpellsData.Count / SpellsCountOnOneFrame + extraBadge;

        for (int i = 0; i < activatedSpellsBadgesCount; i++)
        {
            _spellsBadgeButtons[i].Init(i);
            _spellsBadgeButtons[i].gameObject.SetActive(true);
        }

        OnBadgeClicked(0);
    }

    private void OnBadgeClicked(int buttonIndex)
    {
        foreach (var spell in _spellContainer.transform.GetComponentsInChildren<SpellDisplay>())
            Destroy(spell.gameObject);

        for (int i = buttonIndex * SpellsCountOnOneFrame; i < SpellsCountOnOneFrame * (buttonIndex + 1); i++)
        {
            if (i == _spellBook.SpellsData.Count)
                break;

            var spell = Instantiate(_spellDisplayPrefab, _spellContainer.transform);
            spell.Init(_spellBook.SpellsData[i]);
        }
    }
}
