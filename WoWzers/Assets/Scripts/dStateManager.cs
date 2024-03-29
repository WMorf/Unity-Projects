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

    void Start()
    {
        state_Idle = new dState_Idle(); state_Idle.mobInfo = mobInfo; state_Idle.rb = mobInfo.rb;
        state_Wander = new dState_Wander(); state_Wander.mobInfo = mobInfo; state_Wander.rb = mobInfo.rb;
        if (mobInfo.debug) { Debug.Log(gameObject.name + " : I am Awake!"); }
        currentState = state_Idle;
        ChangeState(state_Wander);
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
