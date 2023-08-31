using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeUpgrade : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Text _text;
    [SerializeField] private AttributeNames _attributeName;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void Start()
    {
        _text.text = $"{_attributeName} [{PlayerAttributes.Instance.GetAttributeValue(_attributeName)}]";
    }

    private void OnButtonClicked()
    {
        PlayerAttributes.Instance.IncreaseAttributePermanently(_attributeName, 1);
        _text.text = $"{_attributeName} [{PlayerAttributes.Instance.GetAttributeValue(_attributeName)}]";
    }
}
