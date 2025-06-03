using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    enum BotState
    {
        Idle = 0,
        Patrol = 1,
        Chase = 2,
        Atk = 3
    }

    [SerializeField]
    BotState currentState = BotState.Idle;

    Vector3 targetPosition;

    [SerializeField] GameObject atkTarget;

    void Update()
    {
        this.OnStateDectect();

        switch (currentState)
        {
            case BotState.Idle:
                OnIdle();
                break;
            case BotState.Patrol:
                OnPatrol();
                break;
            case BotState.Chase:
                OnChase();
                break;
        }
    }

    void OnStateDectect() {
        if(atkTarget == null)
        {
            currentState = BotState.Idle;
        }
        else if (atkTarget.activeSelf && Vector3.Distance(this.transform.position, atkTarget.transform.position) > 1.0f)
        {
            currentState = BotState.Chase;
        }
        else if(atkTarget != null && !atkTarget.activeSelf)
        {
            currentState = BotState.Patrol;
        }
    }

    void OnIdle()
    {
        Debug.Log("Bot is idle.");
    }

    void OnPatrol()
    {
        Debug.Log("Bot is patrolling.");
        if (targetPosition == Vector3.zero || Vector3.Distance(this.transform.position, targetPosition) < 0.5f)
        {
            targetPosition = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
        }
        this.transform.position = Vector3.MoveTowards(
            this.transform.position,
            targetPosition,
            Time.deltaTime * 2.0f
        );
    }

    void OnChase()
    {
         
         this.transform.position = Vector3.MoveTowards(
            this.transform.position,
            atkTarget.transform.position,
            Time.deltaTime * 2.0f
        );
    }

}
