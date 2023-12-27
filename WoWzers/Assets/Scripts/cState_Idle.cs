using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cState_Idle : MonoBehaviour, Istate
{
    [Header("Components")]
    public cMobInfo mobInfo;
    public float threshold;
    private Rigidbody2D rb;

    public void Start()
    {
        rb = mobInfo.rb;
    }

    public void Enter()
    {
        mobInfo.anim.SetBool("Moving", false);
        mobInfo.manager.timer = 0;
        mobInfo.manager.threshold = threshold;

    }

    public void Update()
    {
        try { rb.velocity = Vector2.zero; } catch { };
    }

    public void Exit()
    {

    }
}