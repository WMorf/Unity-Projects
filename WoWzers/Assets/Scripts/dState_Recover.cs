using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class dState_Recover : dState
{
    public dState_Recover(Rigidbody rb, dMobInfo mobInfo) : base(rb, mobInfo) { }

    public override void Enter()
    {
        message = "I am Recovering";
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
