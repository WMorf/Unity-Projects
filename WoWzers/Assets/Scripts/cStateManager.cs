using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cStateManager : MonoBehaviour
{
    private Istate currentState;
    public cState_Idle state_Idle;
    //public cState_Wander state_Wander;

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
        currentState = state_Idle;
    }

    void Update()
    {
        currentState.Update();
    }
}
