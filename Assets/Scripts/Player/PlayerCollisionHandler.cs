using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionHandler : MonoBehaviour
{
    public event UnityAction CollisionedWithGround;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Constants.GroundLayer)
            CollisionedWithGround?.Invoke();
    }
}
