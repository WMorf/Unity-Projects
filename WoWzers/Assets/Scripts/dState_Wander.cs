using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dState_Wander : dState
{
    [Header("RunTime")]
    public float speed;
    public Vector3 newDirection;
    public float wanderDistance;

    public dState_Wander(Rigidbody rb, dMobInfo mobInfo) : base(rb, mobInfo) { }

    public override void Enter()
    {
        message = "I am Wandering";
        rb = mobInfo.rb;
        //mobInfo.anim.SetBool("Moving", true);
        speed = mobInfo.speed;
        wanderDistance = mobInfo.manager.stateCheck.wanderDistance;
        ChangeDirection();
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
        active = false;
    }

    public void ChangeDirection()
    {
        float travelDistance = Random.Range(wanderDistance, -wanderDistance);

        float randomX = Random.Range(travelDistance, -travelDistance);
        float randomZ = Random.Range(travelDistance, -travelDistance);

        Vector3 targetPosition = new Vector3(randomX,0,randomZ);

        newDirection = (targetPosition).normalized * speed;
    }
    

}
