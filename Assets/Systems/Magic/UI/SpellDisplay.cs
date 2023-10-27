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

    private SpellData _data;

    public static event UnityAction<MagicSpell> SpellChoosen;

    public void Init(SpellData data)
    {
        _data = data;

        _icon.sprite = data.Icon;
        _title.text = data.Title;
        _description.text = data.Description;
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
        SpellChoosen?.Invoke(_data.MagicSpell);
    }
}
