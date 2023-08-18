using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }

    public float MovementSpeed { get; private set; } = 5;
    public float JumpPower { get; private set; } = 5;
    public float DashPower { get; private set; } = 25;
    public float DashCooldown { get; private set; } = 1;
    public float Damage{ get; private set; } = 2;

    private void Awake()
    {
        Instance = this;
    }
}