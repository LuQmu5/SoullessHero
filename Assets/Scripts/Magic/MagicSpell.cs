using UnityEngine;

public abstract class MagicSpell : MonoBehaviour
{
    public int Level { get; private set; }

    public abstract void Use();
}
