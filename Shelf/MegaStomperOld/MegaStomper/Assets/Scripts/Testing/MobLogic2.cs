using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MobLogic2 : MonoBehaviour
{
    [Header("States")]
    State curState;
    enum State {Wander, Idle};
    
    public static MobLogic2 instance;

    //Timers
    [Header("Timers")]
    public float idleLength;
    private float idleCounter;
    public float wanderLength;
    private float waderCounter;

    //Bools
    [Header("Bools")]
    public bool shouldIdle;
    private bool idleTick,idleTrip;
    public bool shouldWander;
    private bool wanderTick,wanderTrip;


    //Wake
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if(shouldIdle) { idleTick = true;}
        if(shouldWander) {wanderTick = true;}
        idleCounter = idleLength;
        waderCounter = wanderLength;
    }

    void Update()
    {
        if(curState == State.Idle)
        {

        }
    }
}
