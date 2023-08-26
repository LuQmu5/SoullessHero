using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _health = 10;

    public void ApplyDamage(float amount, Transform attackerTransform)
    {
        _health -= amount;

        StartCoroutine(Animating(attackerTransform.right));

        if (_health <= 0)
            gameObject.SetActive(false);
    }

    private IEnumerator Animating(Vector2 pushDirection)
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<Rigidbody2D>().AddForce((pushDirection + Vector2.up) * 5, ForceMode2D.Impulse);
        float delay = 0.2f;

        yield return new WaitForSeconds(delay);

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
