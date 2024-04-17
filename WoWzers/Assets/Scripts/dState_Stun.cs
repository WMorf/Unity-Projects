using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dState_Stun : dState
{
    public dState_Stun(Rigidbody rb, dMobInfo mobInfo) : base(rb, mobInfo) { }

    public override void Enter()
    {
        message = "I am Stunned";
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
