using System.Collections.Generic;
using UnityEngine;

public abstract class MagicSpell : MonoBehaviour
{
    [SerializeField] private MagicSpellData _data;

    public MagicSpellData Data => _data;

    public abstract void Use();
}


public class MagicSpellBuff : MagicSpell
{
    [SerializeField] private Dictionary<AttributeNames, int> _attributesBuffMap;

    public override void Use()
    {
        
    }
}

public class MagicSpellData : ScriptableObject
{
    [SerializeField] private int _level;

    public int Level => _level; 
}