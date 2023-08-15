using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public static event UnityAction<Vector2> MoveKeyPressing;
    public static event UnityAction JumpKeyPressed;

    private void Update()
    {
        CheckMoveKeysPressing();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpKeyPressed?.Invoke();
        }
    }

    private static void CheckMoveKeysPressing()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveKeyPressing?.Invoke(Vector2.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveKeyPressing?.Invoke(Vector2.right);
        }
        else
        {
            MoveKeyPressing?.Invoke(Vector2.zero);
        }
    }
}
