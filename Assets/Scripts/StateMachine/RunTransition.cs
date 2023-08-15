using UnityEngine;

public class RunTransition : Transition
{
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
            NeedTransit = true;
    }
}