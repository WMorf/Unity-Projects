using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cStateManager : MonoBehaviour
{
    private Istate currentState;
    public cMobInfo mobInfo;
    public Istate state_Idle;
    public Istate state_Wander;
    public string stateMessage;

    public bool debug;
    public float timer, threshold;

    public void ChangeState(Istate newState)
    {
        if(currentState != null) 
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter();
    }

    void Start()
    {
        state_Idle = GetComponent<cState_Idle>();
        state_Wander = GetComponent<cState_Wander>();
        currentState = state_Idle;
    }

    void Update()
    {
        currentState.Update();
        CheckState();
    }

    public void CheckState()
    {
        switch (currentState)
        {
            case cState_Idle:
                stateMessage = "I am Idle";
                if (debug) { Debug.Log(stateMessage); }
                timer += Time.deltaTime;
                if(timer >= threshold)
                {
                    ChangeState( state_Wander );
                }
                break;

            case cState_Wander:
                stateMessage = "I am Wandering";
                if (debug) { Debug.Log(stateMessage); }
                timer += Time.deltaTime;
                if (timer >= threshold)
                {
                    ChangeState(state_Idle);
                }
                break;

            default:
                stateMessage = "I am Error";
                if (debug) { Debug.Log(stateMessage); }
                break;
        }
    }
}
