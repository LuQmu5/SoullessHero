using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Button Skill Data", fileName = "New Button Skill Data", order = 54)]
public class ButtonSkillData : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _header;
    [SerializeField] private string _description;
    [SerializeField] private int _maxLevel = 4;

    public Sprite Icon => _icon;
    public string Header => _header;
    public string Description => _description;
    public int MaxLevel => _maxLevel;
}
