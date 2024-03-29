using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dState_Idle : dState
{
    public override void Enter()
    {
        if (mobInfo.debug) { Debug.Log(mobInfo.gameObject.name + " : I am Idle"); }
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
