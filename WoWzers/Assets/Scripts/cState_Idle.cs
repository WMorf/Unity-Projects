using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

    public bool active;

    public string Info()
    {
        return message;
    }

    public void Enter()
    {
        active = true;
        rb = mobInfo.rb;
        mobInfo.anim.SetBool("Moving", false);
        mobInfo.manager.timer = 0;
        if (!variedTime){ mobInfo.manager.threshold = threshold;}
        else { mobInfo.manager.threshold = threshold += Random.Range(-variation, variation); }
    }

    public void Update()
    {
        if (active)
        {
            //try { rb.velocity = Vector2.zero; } catch { };
        }
    }

    public void Exit()
    {
        active = false;
    }
}