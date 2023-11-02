using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using UnityEngine.Events;

public class SpellDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Image _icon;
    [SerializeField] private Text _title;
    [SerializeField] private Image _descriptionWrapper;
    [SerializeField] private Text _description;

    private MagicSpell _magicSpell;

    public static event UnityAction<MagicSpell> SpellChoosen;

    public void Init(MagicSpell magicSpell)
    {
        _magicSpell = magicSpell;

        _icon.sprite = _magicSpell.Data.Icon;
        _title.text = _magicSpell.Data.Title;
        _description.text = _magicSpell.Data.Description;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _descriptionWrapper.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _descriptionWrapper.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SpellChoosen?.Invoke(_magicSpell);
    }
}
