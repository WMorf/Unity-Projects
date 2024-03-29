using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dState_Idle : dState
{
    public dState_Idle(Rigidbody rb, dMobInfo mobInfo) : base(rb, mobInfo) { }

    public override void Enter()
    {
        message = "I am Idle";
        rb = mobInfo.rb;
        //mobInfo.anim.SetBool("Moving", false);
        active = true;
    }

    public override void Update() 
    {
        if (active)
        {

        }
    }

    public override void Exit()
    {
        active = false;
    }
}
