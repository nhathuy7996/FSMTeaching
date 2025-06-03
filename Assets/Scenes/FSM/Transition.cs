using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition
{
    public Func<bool> Condition;
    public IState TargetState;

    public Transition(Func<bool> condition, IState targetState)
    {
        Condition = condition ?? throw new ArgumentNullException(nameof(condition), "Condition cannot be null");
        TargetState = targetState ?? throw new ArgumentNullException(nameof(targetState), "Target state cannot be null");
    }

}
