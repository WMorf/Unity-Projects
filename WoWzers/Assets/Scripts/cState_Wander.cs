using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cState_Wander : MonoBehaviour, Istate
{
    [Header("Components")]
    public cMobInfo mobInfo;
    public float threshold;
    public string message = "I am Wandering";
    private Rigidbody2D rb;

    [Header("RunTime")]
    private float speed;
    private Vector2 newDirection;

    public bool variedTime;
    public float variation;

    public bool active;

    public string Info()
    {
        return message;
    }

    public void Enter()
    {
        active = true; 
        rb = mobInfo.rb;
        mobInfo.anim.SetBool("Moving", true);
        mobInfo.manager.timer = 0;
        if (!variedTime) { mobInfo.manager.threshold = threshold; }
        else { mobInfo.manager.threshold = threshold += Random.Range(-variation, variation); }

        speed = mobInfo.speed;
        newDirection = Random.insideUnitCircle;
    }

    public void Update()
    {
        if (active)
        {
            try { rb.velocity = newDirection * speed; } catch { }
        }
    }

    public void Exit()
    {
        try { rb.velocity = Vector2.zero; } catch { }
        active = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Mob")
        {
            newDirection = Random.insideUnitCircle;
        }
    }
}
