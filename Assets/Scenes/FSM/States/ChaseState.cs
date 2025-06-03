using Unity.VisualScripting;
using UnityEngine;

public class ChaseState : IState
{
    private BotFSM botFSM;
    StateMachine stateMachine;
 

    public ChaseState(BotFSM botFSM, StateMachine stateMachine = null)
    {
        this.stateMachine = stateMachine;
        this.botFSM = botFSM;
    }
    

    public void OnEnter()
    {
        Debug.Log("Entering Chase State");
    }

    public void OnUpdate()
    {
        
        // if (this.botFSM?.AtkTarget != null && !this.botFSM.AtkTarget.activeSelf)
        // {
        //     // If no attack target is detected, switch to patrol state
        //     this.stateMachine?.ChangeState(new IdleState());
        //     return;
        // }
          this.botFSM.transform.position = Vector3.MoveTowards(
            this.botFSM.transform.position,
            this.botFSM.AtkTarget.transform.position,
            Time.deltaTime * 2.0f
        );
    }

    public void OnExit()
    {
        Debug.Log("Exiting Chase State");
    }
}