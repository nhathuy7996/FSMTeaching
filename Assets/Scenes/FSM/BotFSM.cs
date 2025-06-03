using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BotFSM : MonoBehaviour
{
    StateMachine stateMachine;
    void Start()
    {
        this.stateMachine = new StateMachine();
        this.stateMachine.ChangeState(new IdleState());
    }

    // Update is called once per frame
    void Update()
    {
        this.stateMachine.Update();
    }
}
