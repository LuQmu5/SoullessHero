using UnityEngine;

[CreateAssetMenu(fileName = "Spell Data", menuName = "Create Spell Data", order = 54)]
public class SpellData : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _title;
    [SerializeField] private string _description;
    [SerializeField] private int _level;

    public Sprite Icon => _icon;
    public string Title => _title;
    public string Description => _description;
    public int Level => _level;
}
