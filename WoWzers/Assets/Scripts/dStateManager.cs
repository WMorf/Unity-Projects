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

    [Header("Objects")]
    public GameObject target;

    [Header("Logic")]
    public float timer, threshold;
    public float idleTime, wanderTime;
    public string stateMessage;
    public bool variedTime;
    public float variation;

    void Start()
    {
        state_Idle = new dState_Idle();
        state_Wander = new dState_Wander();
        currentState = state_Idle;
        if (mobInfo.debug) { Debug.Log("I am Awake!"); }
    }

    void Update()
    {
        
    }

    public void ChangeState(dState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter();
    }
}
