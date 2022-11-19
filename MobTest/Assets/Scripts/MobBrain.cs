using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class MobBrain : MonoBehaviour
{
    public static MobBrain instance;

    [Header("Mob Body")]
    public MobBrain Brain;
    public MobInfo Info;
    public MobMotor Motor;

    /*-------------------------STATES--------------------------*/

    [Header("Ready")]
    public GameObject mobTarget;
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

    //Ticks and Trips
    private bool idleTick, idleTrip;
    private bool wanderTick, wanderTrip;
    private bool fleeTick, fleeTrip;
    private bool cowerTick, cowerTrip;

    //Enums
    enum State { Ready, Idle, Wander, Flee, Cower, Patrol, Shoot, Melee, Charge, Stun };
    enum Bump { Friend, Foe, Building }
    State curState = State.Idle;
    State lastState;


    void Start()
    {


    }

    void Update()
    {

    }

}
