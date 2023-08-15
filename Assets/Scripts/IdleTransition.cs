using UnityEngine;

public class IdleTransition : Transition
{
    private void Update()
    {
        if (GetComponent<Rigidbody2D>().velocity.sqrMagnitude < 0.1f)
        {
            NeedTransit = true;
        }
    }
}
