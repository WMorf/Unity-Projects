using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dState_Wander : dState
{

    [Header("RunTime")]
    public float speed;
    public Vector3 newDirection;

    public override void Enter()
    {
        message = "I am Wandering";
        rb = mobInfo.rb;
        //mobInfo.anim.SetBool("Moving", true);
        speed = mobInfo.speed;
        newDirection = Random.insideUnitCircle;
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
        try { rb.velocity = Vector2.zero; } catch { }
        active = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Mob")
        {
            newDirection = Random.insideUnitCircle;
        }
    }
}
