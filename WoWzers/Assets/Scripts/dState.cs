using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class dState
{
    // Base State each State will inherit

    //[Header("")]
    //[Tooltip("")]

    [Header("Components")]
    public Rigidbody rb;

    [Header("Scripts")]
    public dMobInfo mobInfo;

    public string message = "I am Error";
    public bool active;

    public string Info()
    {
        return message;
    }
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
}
