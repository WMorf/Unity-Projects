using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dStateCheck : MonoBehaviour
{
    public dMobInfo mobInfo;
    public dStateManager manager;
    public dState currentState;

    [Header("Logic")]
    public float timer, threshold;
    public float idleTime, wanderTime;
    public string stateMessage;
    public bool variedTime;
    public float variation;


    void Awake()
    {
        manager = mobInfo.manager;
        currentState = manager.currentState;
        if (variedTime)
        {
            idleTime = Random.Range(idleTime + -variation, idleTime + variation);
            wanderTime = Random.Range(wanderTime + -variation, wanderTime + variation);
        }
    }

    void Update()
    {
        switch (currentState)
        {
            /*-------------------------------------------------------*/
            case dState_Idle:
                timer += Time.deltaTime;
                if (timer >= threshold)
                {
                    timer = 0;
                    threshold = wanderTime;
                    manager.ChangeState(manager.state_Wander);
                }
                break;

            /*-------------------------------------------------------*/
            case dState_Wander:
                timer += Time.deltaTime;
                if (timer >= threshold)
                {
                    timer = 0;
                    threshold = idleTime;
                    manager.ChangeState(manager.state_Idle);
                }
                break;

            /*-------------------------------------------------------*/
        }
    }
}
