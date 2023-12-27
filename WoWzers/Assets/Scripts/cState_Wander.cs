using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cState_Wander : MonoBehaviour, Istate
{
    [Header("Components")]
    public cMobInfo mobInfo;
    public float threshold;
    private Rigidbody2D rb;

    [Header("RunTime")]
    private float speed;
    private Vector2 newDirection;



    public void Enter()
    {
        mobInfo.anim.SetBool("Moving", true);
        mobInfo.manager.timer = 0;
        mobInfo.manager.threshold = threshold;
        speed = mobInfo.speed;
        rb = mobInfo.rb;
        newDirection = Random.insideUnitCircle;
    }

    public void Update()
    {
        rb.velocity = newDirection * speed;
    }

    public void Exit()
    {

    }
}
