using System.Collections.Generic;
using UnityEngine;

public abstract class MagicSpell : MonoBehaviour
{
    [SerializeField] private SpellData _data;

    public SpellData Data => _data;

    public abstract void Use(AttributesManager playerAttributes);
}
