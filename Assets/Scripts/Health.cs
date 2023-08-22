using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _health = 10;

    public void ApplyDamage(float amount)
    {
        _health -= amount;

        StartCoroutine(Animating());

        if (_health <= 0)
            gameObject.SetActive(false);
    }

    private IEnumerator Animating()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        float delay = 0.1f;

        yield return new WaitForSeconds(delay);

        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
