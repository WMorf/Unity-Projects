using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dStateManager : MonoBehaviour
{
    [Header("States")]
    public dState currentState;
    public dState state_Idle;
    public dState state_Wander;
    public dState state_Panic;
    public dState state_Recover;

    [Header("Scripts")]
    public dMobInfo mobInfo;
    public dStateCheck stateCheck;

    //[Header("Objects")]
    //public GameObject target;

    private void Awake()
    {
        state_Idle = new dState_Idle(mobInfo.rb, mobInfo);
        state_Wander = new dState_Wander(mobInfo.rb, mobInfo);
        state_Panic = new dState_Panic(mobInfo.rb, mobInfo);
        state_Recover = new dState_Recover(mobInfo.rb, mobInfo);
        if (mobInfo.debug) { Debug.Log(mobInfo.mobName + " : I am Awake!"); }
    }

    void Start()
    {
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
        stateCheck.currentState = newState;
        stateCheck.stateMessage = currentState.Info();
        if (mobInfo.debug) { Debug.Log(currentState.Info()); }
    }
}
