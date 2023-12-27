using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cState_Idle : MonoBehaviour, Istate
{
    public cMobInfo mobInfo;
    public float threshold;

    public void Enter()
    {
        mobInfo.anim.SetBool("Moving", false);
        mobInfo.manager.timer = 0;
        mobInfo.manager.threshold = threshold;
    }

    public void Update()
    {
        
    }

    public void Exit()
    {

    }
}