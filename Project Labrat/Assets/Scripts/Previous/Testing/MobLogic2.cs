using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MobLogic2 : MonoBehaviour
{
    /*[Header("States")]
    private State curState;
    private State lastState;
    enum State {Wander, Idle, Stun};*/
    
    public static MobLogic2 instance;

    [Header("Stats")]
    public float moveSpeed;

    //Right,Left,Back
    private float[] bumpers = new float[]{0f,90f,-90f,180f};
    private int bumpDir;

    public Animator brain;

    private Vector3 movePos;
    private float timeCount;
    private float timeStamp;
    //Time Mob has been active. Can be used to check for thresholds
    //instead of having a unique counter for each bool gate. 
    //Just a desired maxTime var and a timeStamp var(timeCount >= timeStamp + maxTime)

    //Timers
    [Header("Timers")]
    public float idleLength;
    //private float idleCounter;
    public float wanderLength;
    //private float waderCounter;
    public float bumpLength;

    //Bools
    //Posibly move some bools to the animator i.e. SHouldIdle,Should Wander...
    [Header("Bools")]
    public bool shouldIdle;
    private bool /*idleTick,*/idleTrip;
    public bool shouldWander;
    private bool /*wanderTick,*/wanderTrip;
    private bool bump, bumpTrip;


    //Wake
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //if(shouldIdle) { idleTick = true;}
        //if(shouldWander) {wanderTick = true;}
        //idleCounter = idleLength;
        //waderCounter = wanderLength;
        movePos = transform.forward * Time.deltaTime * moveSpeed;
    }

    void Move()
    {

        transform.position += movePos;
    }

    void FixedUpdate()
    {
        if(brain.GetBool("Idle") == true)
        {
            if(!idleTrip)
            {
                idleTrip = true;
            
                brain.SetFloat("Counter", idleLength);
            }

            brain.SetFloat("Counter", brain.GetFloat("Counter") - Time.deltaTime);

            if(brain.GetFloat("Counter") <= 0f)
            {
                idleTrip = false;
            }
        }

        if(brain.GetBool("Wander") == true)
        {
                Move();
        }

        //Recenter to node state, keep from being too clogged

        //Pulse navigation state to orient itself and check for threats

        //Stun State

        //Resets
        movePos = transform.forward * Time.deltaTime * moveSpeed;

        //Timers
        timeCount = timeCount + Time.deltaTime;
        
        if(bump)
        {
            if(!bumpTrip)
            {   
                bumpDir = Random.Range(1,3);
                transform.position -= transform.forward * .10f;
                Vector3 newRotation = new Vector3(0, bumpers[bumpDir], 0);
                transform.Rotate(newRotation);
                timeStamp = timeCount;
                bumpTrip = true;
            }

            if(timeCount >= timeStamp + bumpLength)
            {
                bump = false;
                bumpTrip = false;
            }
        }
    }

    //Posibly reset each state when certain quick exits happen such as Wander to Stun

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Building")
        {
            if(!bump)
            {
                bump = true;
            }
        }
    }

    private void OnCollisionStay(Collision other) 
    {
        if(other.gameObject.tag == "Building")
        {
            if(!bump)
            {
                bump = true;
            }
        }
    }
    //Create movement cue for complex movements such as backing around obstacles and unique
    //patterns.
}
