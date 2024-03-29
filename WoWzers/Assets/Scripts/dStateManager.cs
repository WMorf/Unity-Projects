using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dStateManager : MonoBehaviour
{
    [Header("States")]
    public dState currentState;
    public dState state_Idle;
    public dState state_Wander;

    [Header("Scripts")]
    public dMobInfo mobInfo;
    public dStateCheck stateCheck;

    //[Header("Objects")]
    //public GameObject target;

    private void Awake()
    {
        state_Idle = new dState_Idle(mobInfo.rb, mobInfo);
        state_Wander = new dState_Wander(mobInfo.rb, mobInfo);
        if (mobInfo.debug) { Debug.Log(gameObject.name + " : I am Awake!"); }
    }

    void Start()
    {
        currentState = state_Idle; //Placeholder, state_Spawn eventually
        ChangeState(state_Idle);
    }

    void Update()
    {
        currentState.Update();
    }

    public void ChangeState(dState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter();
        stateCheck.stateMessage = currentState.Info();
        if (mobInfo.debug) { Debug.Log(currentState.Info()); }
    }
}
