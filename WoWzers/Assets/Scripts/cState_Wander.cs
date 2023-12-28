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

    public bool variedTime;
    public float variation;

    public void Start()
    {
        rb = mobInfo.rb;
    }

    public void Enter()
    {
        mobInfo.anim.SetBool("Moving", true);
        mobInfo.manager.timer = 0;
        if (!variedTime) { mobInfo.manager.threshold = threshold; }
        else { mobInfo.manager.threshold = threshold += Random.Range(-variation, variation); }

        speed = mobInfo.speed;
        newDirection = Random.insideUnitCircle;
    }

    public void Update()
    {
        rb.velocity = newDirection * speed;
    }

    public void Exit()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            newDirection = Random.insideUnitCircle;
        }
    }
}
