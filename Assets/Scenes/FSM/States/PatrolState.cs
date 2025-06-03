using UnityEngine;
public class PatrolState : IState
{ 
    BotFSM botFMS;
    Vector3 targetPosition;

    StateMachine stateMachine;
    public PatrolState(BotFSM botFMS, StateMachine stateMachine = null)
    {
        this.botFMS = botFMS;
        this.stateMachine = stateMachine;
        Debug.Log("Patrol State Initialized");
    }

    public void OnEnter()
    {
      this.targetPosition = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
    }

    public void OnUpdate()
    {

        if(this.botFMS.AtkTarget != null && this.botFMS.AtkTarget.activeSelf)
        {
            // If an attack target is detected, switch to chase state
            this.stateMachine?.ChangeState(new ChaseState(this.botFMS, this.stateMachine));
            return;
        }


        if (targetPosition == Vector3.zero || Vector3.Distance(this.botFMS.transform.position, targetPosition) < 0.5f)
        {
            this.targetPosition = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
        }
        this.botFMS.transform.position = Vector3.MoveTowards(
            this.botFMS.transform.position,
            targetPosition,
            Time.deltaTime * 2.0f
        );

        
    }

    public void OnExit()
    {
        Debug.Log("Exiting Patrol State");
    }
}