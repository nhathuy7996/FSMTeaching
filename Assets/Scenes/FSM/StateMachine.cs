using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    IState currentState;

    public void ChangeState(IState nextState)
    {
        if (this.currentState != null)
        {
            this.currentState.OnExit();
        }

        currentState = nextState;
        currentState?.OnEnter();
    }
    
    public void Update()
    {
        currentState?.OnUpdate();
    }
}
