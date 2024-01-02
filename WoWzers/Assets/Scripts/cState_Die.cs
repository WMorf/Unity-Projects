using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cState_Die : MonoBehaviour, Istate
{
    [Header("Components")]
    public cMobInfo mobInfo;
    public float threshold;
    public string message = "I am Dead";

    public bool variedTime;
    public float variation;


    public string Info()
    {
        return message;
    }

    public void Enter()
    {
        mobInfo.anim.SetBool("Moving", false);
        mobInfo.manager.timer = 0;
        if (!variedTime) { mobInfo.manager.threshold = threshold; }
        else { mobInfo.manager.threshold = threshold += Random.Range(-variation, variation); }
    }

    public void Update()
    {

    }

    public void Exit()
    {
        
    }
}
