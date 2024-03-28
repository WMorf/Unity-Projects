using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dState_Wander : dState
{
    [Header("Components")]
    private Rigidbody rb;

    [Header("Scripts")]
    public dMobInfo mobInfo;

    [Header("RunTime")]
    private float speed;
    private Vector3 newDirection;

    public override void Enter()
    {
        message = "I am Wandering";
        rb = mobInfo.rb;
        mobInfo.anim.SetBool("Moving", true);
        speed = mobInfo.speed;
        newDirection = Random.insideUnitCircle;
    }

    public override void Update()
    {
            try { rb.velocity = newDirection * speed; } catch { }
    }

    public override void Exit()
    {
        try { rb.velocity = Vector2.zero; } catch { }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Mob")
        {
            newDirection = Random.insideUnitCircle;
        }
    }
}
