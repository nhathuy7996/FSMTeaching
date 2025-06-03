using UnityEngine;
public class IdleState : IState
{
    public void OnEnter()
    {
        Debug.Log("Entering Idle State");
    }

    public void OnUpdate()
    {
        // Logic for idle state, e.g., waiting for input or conditions to change
        Debug.Log("Idle State Update");
    }

    public void OnExit()
    {
        Debug.Log("Exiting Idle State");
    }
}