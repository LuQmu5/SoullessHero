using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBook : MonoBehaviour
{
    [SerializeField] private List<SpellData> _spellsData = new List<SpellData>();

    public List<SpellData> SpellsData => _spellsData;
}
