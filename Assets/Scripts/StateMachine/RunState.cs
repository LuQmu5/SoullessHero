using UnityEngine;

public class RunState : State
{
    public override void Enter()
    {
        base.Enter();

        Debug.Log("Run");
    }

    public override void Exit()
    {
        base.Exit();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = Vector2.right * horizontalInput;
    }
}