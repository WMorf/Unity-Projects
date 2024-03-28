using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dState_Idle : dState
{
    [Header("Components")]
    private Rigidbody rb;

    [Header("Scripts")]
    public dMobInfo mobInfo;

    public override void Enter()
    {
        message = "I am Idle";
        rb = mobInfo.rb;
        mobInfo.anim.SetBool("Moving", false);
    }

    public override void Update() 
    {

    }

    public override void Exit()
    {

    }
}
