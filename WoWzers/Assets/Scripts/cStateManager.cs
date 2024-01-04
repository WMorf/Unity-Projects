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
    public string stateMessage = "I am Error";

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

    public void Start()
    {
        state_Idle = GetComponent<cState_Idle>();
        state_Wander = GetComponent<cState_Wander>();
        state_Nest = GetComponent<cState_Nest>();
        state_Die = GetComponent<cState_Die>();
        currentState = state_Idle;
        if(debug) { Debug.Log("I am Awake!"); }
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
        if (mobInfo.rewardScore > mobInfo.nestScore) { ChangeState(state_Nest); }
    }

    public void CheckState()
    {
        switch (currentState)
        {
            case cState_Idle:
                stateMessage = currentState.Info();
                if (debug) { Debug.Log(stateMessage); }
                timer += Time.deltaTime;
                if(timer >= threshold)
                {
                    ChangeState( state_Wander );
                }
                break;

            case cState_Wander:
                stateMessage = currentState.Info();
                if (debug) { Debug.Log(stateMessage); }
                timer += Time.deltaTime;
                if (timer >= threshold)
                {
                    ChangeState(state_Idle);
                }
                break;

            case cState_Nest:
                stateMessage = currentState.Info();
                if (debug) { Debug.Log(stateMessage); }
                timer += Time.deltaTime;
                mobInfo.shouldNest = false;
                if (timer >= threshold)
                {
                    ChangeState(state_Idle);
                    GameObject newNest = Instantiate(mobInfo.nest, transform.position, transform.rotation);
                    newNest.GetComponent<cSpawner>().spawnColor = mobInfo.render.color;
                }
                break;

            case cState_Die:
                stateMessage = currentState.Info();
                if (debug) { Debug.Log(stateMessage); }
                timer += Time.deltaTime;
                if (timer >= threshold)
                {
                    try { mobInfo.nest.GetComponent<cSpawner>().popCurrent--; } catch { };
                    Destroy(gameObject);
                }
                break;

            default:
                stateMessage = currentState.Info();
                if (debug) { Debug.Log(stateMessage); }
                break;
        }
    }
}
