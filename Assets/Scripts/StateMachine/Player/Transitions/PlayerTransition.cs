using System.Collections;
using System.Collections.Generic;

public class PlayerTransition : Transition
{
    protected PlayerController PlayerController { get; private set; }

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }
}
