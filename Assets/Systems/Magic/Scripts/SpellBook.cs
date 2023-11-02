using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBook : MonoBehaviour
{
    private List<MagicSpell> _spells = new List<MagicSpell>();

    public List<MagicSpell> Spells => _spells;

    private void Awake()
    {
        foreach (var child in transform.GetComponentsInChildren<MagicSpell>(true))
        {
            Spells.Add(child);
        }
    }
}
