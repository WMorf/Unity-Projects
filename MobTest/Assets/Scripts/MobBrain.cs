using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;


public class MobBrain : MonoBehaviour
{
    public static MobBrain instance;

    [Header("Mob Body")]
    public MobBrain Brain;
    public MobInfo Info;
    public MobMotor Motor;

    /*-------------------------STATES--------------------------*/

    [Header("Ready")]
    //public GameObject mobTarget;
    private GameObject sightTarget;
    private float targetRange;
    private bool hasTarget;

    [Header("Idle")]
    private float idleCounter;

    [Header("Wander")]
    private float wanderCounter;

    [Header("Flee")]
    private bool fleeChange;
    private float fleeCounter;
    private float panicCounter;
    private float cowerCounter;

    [Header("Melee")]
    private float meleeCounter;

    [Header("Charge")]
    private float chargeCounter;

    [Header("Stun")]
    private float stunCounter;

    [Header("Emote")]
    private float emoteCounter;

    //Trash Test
    private int trashLimit, trashAmount;
    private float trashCounter;
    private bool trashTick;

    //Ticks and Trips
    private bool idleTick, idleTrip;
    private bool wanderTick, wanderTrip;
    private bool fleeTick, fleeTrip;
    private bool cowerTick, cowerTrip;
    private bool emoteTick, emoteTrip;

    


    //Enums
    enum State { Ready, Idle, Wander, Flee, Cower, Patrol, Shoot, Melee, Charge, Stun };
    enum Alert { Aware, Distracted, Oblivious}//affects the size and strength of their search radius
    //enum Bump { Friend, Foe, Building }
    State curState = State.Idle;
    State lastState;


    void Start()
    {
        ResetTimers();

        //Bools
        if (Info.shouldWander) { wanderTick = true; }
        if (Info.shouldIdle) { idleTick = true; }
        if (Info.shouldFlee) { fleeTick = true; }
        if (Info.shouldCower) { cowerTick = true; }
        if (Info.shouldEmote) { emoteTick = true; }

        //Trash Test
        if (Info.shouldTrash) { trashTick = true; }

        //Starting position
        Motor.homePoint = this.transform.position;
    }

    public void ResetTimers()
    {
        wanderCounter = Info.wanderLength;
        emoteCounter = Info.timeBetweenEmotes;
        meleeCounter = Info.meleeTimeLength;
        idleCounter = Info.idleLength;
        fleeCounter = Info.fleeLength;
        panicCounter = Info.panicLength;

        //Trash Test
        trashCounter = Info.trashFrequency;
    }

    public void ResetTrips()
    {

    }

    void FixedUpdate()
    {
        //Trash Test
        if(trashTick && trashCounter > 0f)
        {
            trashCounter -= Time.deltaTime;
        }

        //Trash Test
        if (trashTick && trashCounter < 0f)
        {
            if (Info.showDebug) { Debug.Log(Info.MyName + ": Trash it!"); }
            Instantiate(Info.trashBit, Info.EmotePoint.transform.position, Info.EmotePoint.transform.rotation);
            trashCounter = Info.trashFrequency;
            trashAmount++;
        }


        /*--------------------------------------------------------*/
        /*-----------------Switches and Logic---------------------*/

        switch (curState)
        {

            /*----------------------------------------------------------------------------*/
            case State.Ready:

                switch(lastState)
                {
                    case State.Idle:

                        if (idleTick)
                        {
                            curState = State.Wander;
                        }
                        else
                        {
                            curState = State.Idle;
                        }

                        break;
                    /*-----------------------*/
                    case State.Wander:

                        if(idleTick)
                        {
                            curState = State.Idle;
                        }
                        else
                        {
                            curState = State.Wander;
                        }
                        break;
                    /*-----------------------*/
                }

                break;

    /*----------------------------------------------------------------------------*/
            case State.Idle:

                //first time tripwire
                if(!idleTrip)
                {
                    if (Info.showDebug) { Debug.Log(Info.MyName + ": I am bored"); }
                    idleTrip = true;
                }

                //While counter above zero. Mob will remain in this state and do various tasks
                if(idleCounter > 0f)
                {
                    idleCounter -= Time.deltaTime;
                    //Info.anim.SetBool("isMoving", false);
                }
                else 
                {
                    idleCounter = Info.idleLength; //reset counter to established length from attached MobInfo obj.
                    lastState = curState;
                    curState = State.Ready; //sets current state to Ready, which acts as a decision tree
                    idleTrip = false; //reset tripwire so first time run will trigger again
                }


                break;

            /*----------------------------------------------------------------------------*/
            case State.Wander:

                if(!wanderTrip)
                {
                    if (Info.showDebug) { Debug.Log(Info.MyName + ": I'm wandering around"); }
                    Motor.moveDirection = new Vector3(UnityEngine.Random.Range(-1f, 1f), 0f, UnityEngine.Random.Range(-1f, 1f));
                    wanderTrip = true;
                }

                if (wanderCounter > 0f)
                {
                    wanderCounter -= Time.deltaTime;
                    //Info.anim.SetBool("isMoving", true);
                    Motor.Move();
                }
                else
                {
                    wanderCounter = Info.idleLength;
                    lastState = curState;
                    curState = State.Ready;
                    wanderTrip = false;
                }
                break;

        }

    }

}
