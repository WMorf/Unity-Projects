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
    public MobSense Sense;
    public GameObject EmotePoint;

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

    [Header("Search")]
    public bool needSearch;
    private float searchCounter;
    public GameObject searchTarget;

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
    private bool searchTick, searchTrip;
    private bool fleeTick, fleeTrip;
    private bool cowerTick, cowerTrip;
    private bool emoteTick, emoteTrip;




    //Enums
    enum State { Ready, Idle, Wander, Flee, Cower, Patrol, Shoot, Melee, Charge, Stun , Search, Hunt};
    enum Alert { Aware, Distracted, Oblivious}//affects the size and strength of their search radius
    State curState = State.Idle;
    State lastState;


    void Start()
    {
        ResetTimers();
        trashCounter = Info.trashFrequency;

        //Bools
        if (Info.shouldIdle) { idleTick = true; }
        if (Info.shouldWander) { wanderTick = true; }
        if (Info.shouldSearch) { searchTick = true; }
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
        searchCounter = Info.searchLength;
        emoteCounter = Info.timeBetweenEmotes;
        meleeCounter = Info.meleeTimeLength;
        idleCounter = Info.idleLength;
        fleeCounter = Info.fleeLength;
        panicCounter = Info.panicLength;

        //Trash Test
        //trashCounter = Info.trashFrequency;
    }

    public void ResetTrips()
    {
        idleTrip = false;
        wanderTrip = false;
        searchTrip = false;
        fleeTrip = false;
        cowerTrip = false;
        emoteTrip = false;
    }

    public void ShiftState()
    {
        ResetTimers();
        ResetTrips(); //reset tripwire so first time run will trigger again
        lastState = curState;
        curState = State.Ready; //sets current state to Ready, which acts as a decision tree

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

        switch(curState)
        {

            /*----------------------------------------------------------------------------*/
            case State.Ready:

                if (searchTick && needSearch && lastState != State.Search)
                {
                    curState= State.Search;
                }
                else //Idle and Wander (If nothing pressing, do these
                {
                    switch (lastState)
                    {
                        case State.Idle:

                            if (wanderTick)
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

                            if (idleTick)
                            {
                                curState = State.Idle;
                            }
                            else
                            {
                                curState = State.Wander;
                            }
                            break;
                        /*-----------------------*/
                        case State.Search:

                            if (idleTick)
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
                    ShiftState();
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
                    ShiftState();
                }

                break;

            /*----------------------------------------------------------------------------*/
            case State.Search:

                if(!searchTrip)
                {
                    if (Info.showDebug) { Debug.Log(Info.MyName + ": Where is it"); }

                    try //try and look for object
                    {
                        searchTarget = FindObjectOfType<Trash>().gameObject;
                        Motor.moveDirection = searchTarget.transform.position;
                    }
                    catch
                    {
                        ShiftState();
                    }
                    searchTrip = true;
                }

                if (searchCounter > 0f)
                {
                    searchCounter -= Time.deltaTime;
                    Motor.Move();
                }
                else
                {
                    ShiftState();
                }

                break;

        }

    }

}
