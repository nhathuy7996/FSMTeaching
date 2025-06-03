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

        var patrolState = new PatrolState(this, this.stateMachine);
        var chaseState = new ChaseState(this, this.stateMachine);

        this.stateMachine.AddTransition(
            patrolState,
            new Transition(IsAtkTargetActive, chaseState)
        );

        this.stateMachine.ChangeState(patrolState);
    }

    bool IsAtkTargetActive()
    {
        return atkTarget != null && atkTarget.activeSelf;
    }

    // Update is called once per frame
    void Update()
    {
        this.stateMachine.Update();
    }
}
