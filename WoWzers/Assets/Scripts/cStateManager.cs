using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cStateManager : MonoBehaviour
{
    private Istate currentState;
    public cMobInfo mobInfo;
    public Istate state_Idle;
    public Istate state_Wander;
    public Istate state_Nest;
    public Istate state_Die;
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
        state_Nest = GetComponent<cState_Nest>();
        state_Die = GetComponent<cState_Die>();
        currentState = state_Idle;
    }

    void Update()
    {
        currentState.Update();
        CheckState();
        if (mobInfo.shouldNest) { CheckNest(); }
        if (mobInfo.lifeTime >= mobInfo.maxLifeTime) { ChangeState(state_Die); }
    }

    private void CheckNest()
    {
        if (mobInfo.rewardScore < mobInfo.nestScore) { ChangeState(state_Nest); }
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

            case cState_Nest:
                stateMessage = "I am Nesting";
                if (debug) { Debug.Log(stateMessage); }
                timer += Time.deltaTime;
                if (timer >= threshold && mobInfo.shouldNest)
                {
                    GameObject newNest = Instantiate(mobInfo.nest, transform.position, transform.rotation);
                    newNest.GetComponent<bSpawner>().spawnColor = mobInfo.render.color;
                    mobInfo.shouldNest = false;
                    ChangeState(state_Idle);
                }
                break;

            case cState_Die:
                stateMessage = "I am Dead";
                if (debug) { Debug.Log(stateMessage); }
                timer += Time.deltaTime;
                if (timer >= threshold)
                {
                    Destroy(gameObject);
                }
                break;

            default:
                stateMessage = "I am Error";
                if (debug) { Debug.Log(stateMessage); }
                break;
        }
    }
}
