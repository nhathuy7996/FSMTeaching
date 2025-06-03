using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    IState currentState;
    Dictionary<IState, List<Transition>> transitions = new Dictionary<IState, List<Transition>>();

    public void AddTransition(IState fromState, Transition transition)
    {
        if (!transitions.ContainsKey(fromState))
        {
            transitions[fromState] = new List<Transition>();
        }
        transitions[fromState].Add(transition);
    }

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
        if(currentState != null && transitions.ContainsKey(currentState))
        {
           
             foreach (var transition in this.transitions[currentState])
            {
                if (transition.Condition())
                {
                    ChangeState(transition.TargetState);
                    return; // Exit after changing state
                }
            }
        }
       

        currentState?.OnUpdate();
    }
}
