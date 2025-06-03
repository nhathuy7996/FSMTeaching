using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BotFSM : MonoBehaviour
{
    StateMachine stateMachine;
    [SerializeField] GameObject atkTarget;
    public GameObject AtkTarget => atkTarget;
    void Start()
    {
        this.stateMachine = new StateMachine();
        this.stateMachine.ChangeState(new PatrolState(this, this.stateMachine));
    }

    // Update is called once per frame
    void Update()
    {
        this.stateMachine.Update();
    }
}
