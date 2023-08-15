using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }

    public float MovementSpeed { get; private set; } = 5;
    public float JumpPower { get; private set; } = 5;

    private void Awake()
    {
        Instance = this;
    }
}