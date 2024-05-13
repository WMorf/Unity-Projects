using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class dState_Panic : dState
{
    [Header("RunTime")]
    public float speed;
    public Vector3 newDirection;
    public Vector3 target;

    public dState_Panic(Rigidbody rb, dMobInfo mobInfo) : base(rb, mobInfo) { }

    public override void Enter()
    {
        message = "I am Panicking!";
        rb = mobInfo.rb;
        //mobInfo.anim.SetBool("Moving", true);
        speed = mobInfo.speed;
        newDirection = (rb.position - target).normalized;
        mobInfo.anim.SetBool("Moving", true);
        active = true;
    }

    public override void Update()
    {
        if (active)
        {
            try { rb.velocity = newDirection * speed; } catch { }
        }
    }

    public override void Exit()
    {
        try { rb.velocity = Vector3.zero; } catch { }
        mobInfo.anim.SetBool("Moving",false);
        active = false;
    }


}