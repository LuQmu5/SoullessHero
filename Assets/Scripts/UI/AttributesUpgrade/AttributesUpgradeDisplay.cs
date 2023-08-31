using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributesUpgradeDisplay : MonoBehaviour
{
    [SerializeField] private Text _attributePointsCountText;

    private void OnEnable()
    {
        _attributePointsCountText.text = "Attribute Points: " + PlayerConsumables.AttributePoints;
    }
}
