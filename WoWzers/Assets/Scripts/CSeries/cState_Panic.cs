using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cState_Panic : MonoBehaviour, Istate
{
    [Header("Components")]
    public cMobInfo mobInfo;
    public float threshold;
    public string message = "I am Panic!";
    private Rigidbody2D rb;

    [Header("RunTime")]
    private float speed;
    private Vector2 newDirection;

    public GameObject target;

    public bool variedTime;
    public float variation;

    public float panicTimer;
    public float panicThreshold;

    public bool active;

    public string Info()
    {
        return message;
    }

    public void Enter()
    {
        active = true;
        rb = mobInfo.rb;
        target = mobInfo.manager.target;
        mobInfo.anim.SetBool("Moving", true);
        mobInfo.manager.timer = 0;
        if (!variedTime) { mobInfo.manager.threshold = threshold; }
        else { mobInfo.manager.threshold = threshold += Random.Range(-variation, variation); }

        speed = mobInfo.speed * 1.1f;
        newDirection = transform.position - target.transform.position;
    }

    public void Update()
    {
        if (active)
        {
            if(panicTimer >= panicThreshold)
            {
                //newDirection = transform.position - target.transform.position;
                //newDirection = Random.insideUnitCircle;
                panicTimer = 0f;
                //try
                //{
                //    if (target = null) // Pulls mob out of Panic State
                //    {
                //        mobInfo.manager.timer = threshold;
                //    }
                //}
                //catch
                //{

                //}
            }
            else
            {
                panicTimer += Time.deltaTime;
            }
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
