using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cState_Idle : MonoBehaviour, Istate
{
    [Header("Components")]
    public cMobInfo mobInfo;
    public float threshold;
    public string message = "I am Idle";
    private Rigidbody2D rb;

    public bool variedTime;
    public float variation;

    public string Info()
    {
        return message;
    }

    public void Enter()
    {
        rb = mobInfo.rb;
        mobInfo.anim.SetBool("Moving", false);
        mobInfo.manager.timer = 0;
        if (!variedTime){ mobInfo.manager.threshold = threshold;}
        else { mobInfo.manager.threshold = threshold += Random.Range(-variation, variation); }
    }

    public void Update()
    {
        try { rb.velocity = Vector2.zero; } catch { };
    }

    public void Exit()
    {

    }
}