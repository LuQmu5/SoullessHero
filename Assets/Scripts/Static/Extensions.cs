using UnityEngine;

public static class Extensions
{
    public static Color SetAlpha(this Color color, float newAlpha)
    {
        if (newAlpha < 0 || newAlpha > 1)
            throw new System.ArgumentOutOfRangeException("alpha can only be in range from 0 to 1");

        return new Color(color.a, color.g, color.b, newAlpha);
    }
}