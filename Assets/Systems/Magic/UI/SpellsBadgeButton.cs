using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(Button))]
public class SpellsBadgeButton : MonoBehaviour
{
    private int _index;
    private Button _button;

    public static event UnityAction<int> BadgeClicked;

    public void Init(int index)
    {
        _index = index;
    }

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        BadgeClicked?.Invoke(_index);
    }
}
