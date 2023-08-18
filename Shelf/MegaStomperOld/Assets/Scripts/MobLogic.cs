using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MobLogic : MonoBehaviour
{
    public static MobLogic instance;

    [Header("Info")]
    public bool showDebug;
    public bool showEmoteDebug;
    public string namePlate;
    public List<string> nameDatabase = new List<string>();
    public int serialID;
    

    [Header("Stats")]
    public float moveSpeed;
    private float curSpeed;
    public int endurance;
    private int curEndurance;
    private bool isPanicking;
    private bool isCowering;

    [Header("Relations")]
    public List<GameObject> friendsList;
    public int maxFriends;
    public string foe;
    public string friend;
    //private bool sameName;

    [Header("Threat and Morale")]
    public float moraleBase;
    private float curMorale;
    public float threatBase;
    private float curThreat;
    private float targetThreat;

    [Header("Movement")]
    private Vector3 moveDirection;
    private Vector3 wanderDirection;
    private Vector3 homePoint;
    private bool holdPlace;

    [Header("Tools")]
    public Rigidbody theRB;
    public Animator anim;
    public SpriteRenderer theBody;
    public Transform emotePoint;
    public GameObject beacon;

    [Header("Emotes")]
    public GameObject[] emotions;
    public float timeBetweenEmotes;
    private float emoteCounter;
    private bool emoteTick;


    [Header("Bools")]
    public bool shouldIdle;
    public bool shouldCharge;
    public bool shouldWander;
    public bool shouldShoot;
    public bool shouldFlee;
    public bool shouldCower;
    public bool shouldMelee;
    public bool shouldGib;
    public bool shouldDropItems;
    public bool shouldEmote;
    public bool shouldPanic;

    //Ticks and Trips
    private bool idleTick, idleTrip;
    private bool wanderTick, wanderTrip;
    private bool fleeTick, fleeTrip;
    private bool cowerTick, cowerTrip;

/*-------------------------STATES--------------------------*/

    [Header("Ready")]
    public GameObject mobTarget;
    private GameObject sightTarget;
    private float targetRange;
    public float rangeToChase;
    private bool hasTarget;

    [Header("Idle")]
    public float idleLength;
    private float idleCounter;

    [Header("Wander")]
    public float wanderLength;
    private float wanderCounter;

    [Header("Flee")]
    public int rangeToFlee;
    public float fleeLength;
    private bool fleeChange;
    private float fleeCounter;
    public float panicLength;
    private float panicCounter;
    public float cowerLength;
    private float cowerCounter;

    [Header("Shoot")]
    public GameObject bullet;
    public Transform firePoint;

    [Header("Melee")]
    public float meleeTimeLength;
    private float meleeCounter;

    [Header("Charge")]
    public float chargeLength;
    private float chargeCounter;
    
    [Header("Stun")]
    public float stunLength;
    private float stunCounter;
    
    [Header("Gibbing")]
    public bool shouldLeaveCorpse;
    public GameObject hitEffect;
    public GameObject[] splatters;

    [Header("Drops")]
    public GameObject[] itemsToDrop;
    public float itemDropPercent;

    [Header("Sprites")]
    public Sprite[] bodies;
    public int curSpriteCount;
    private Sprite curSprite;

    //Enums
    enum State {Ready, Idle, Wander, Flee, Cower, Patrol, Shoot, Melee, Charge, Stun};
    enum Bump {Friend, Foe, Building}
    State curState = State.Idle;
    State lastState;

    //Wake
    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        //Initialize ID
        Identify();

        curSpeed = moveSpeed;

        //Timers
        wanderLength = Random.Range( wanderLength * .75f, wanderLength * 1.25f);
        meleeTimeLength = Random.Range( meleeTimeLength * .75f, meleeTimeLength * 1.25f);
        idleLength = Random.Range( idleLength * .75f, idleLength * 1.25f);
        fleeLength = Random.Range( fleeLength * .75f, fleeLength * 1.25f);
        panicLength = Random.Range( panicLength * .75f, panicLength * 1.25f);

        wanderCounter = wanderLength;
        emoteCounter = timeBetweenEmotes;
        meleeCounter = meleeTimeLength;
        idleCounter = idleLength;
        fleeCounter = fleeLength;
        panicCounter = panicLength;
        

        //Stats
        curMorale = Random.Range(moraleBase * .10f, moraleBase * 2.0f);
        holdPlace = false;

        //Bools
        if(shouldWander) { wanderTick = true; }
        if(shouldIdle) { idleTick = true; }
        if(shouldFlee) { fleeTick = true; }
        if(shouldCower) { cowerTick = true; }
        if (shouldEmote) { emoteTick = true; }

        //Starting appearance of mob
        curSpriteCount = 0;

        //Relationships
        //sameName = false;

        //Starting position
        homePoint = this.transform.position;
            
    }

/*--------------------------------------------------------*/
/*----------------------Functions-------------------------*/

    public void Identify()
    {
        int randName = Random.Range(1, nameDatabase.Count);
        namePlate = nameDatabase[randName];
        serialID = Random.Range(100, 999);

        if(showDebug) 
        {   
            Debug.Log(string.Format("My name is {0}, my Serial # is {1} and I am at {2}", namePlate, serialID, transform.position));
        }

    }

    public void Emote(int emotion)
    {   
        if(shouldEmote && emoteTick)
        {
            Instantiate(emotions[emotion], emotePoint.transform.position, emotePoint.transform.rotation);
            shouldEmote = false;
        }else{ if(showDebug) { Debug.Log(string.Format("{0} Quiet", namePlate)); } }
    }


    public void Move()
    {
        if(!holdPlace)
        {
            if(isPanicking)
            {
                curSpeed = Random.Range(moveSpeed * 1.1f, moveSpeed * 1.3f);
            }else
            {
                curSpeed = moveSpeed;
            }
            anim.SetBool("isMoving", true);
            theRB.velocity = moveDirection * curSpeed;
            moveDirection.Normalize();
        }
    }

/*----------------------------------------------------------------------------*/

    void FixedUpdate()
    {
        //if(showDebug) { Debug.Log(string.Format("{0}{1}",namePlate, curState)); }

/*--------------------------------------------------------*/
/*-----------------Switches and Logic---------------------*/
        switch(curState)
        {


    /*----------------------------------------------------------------------------*/
            case State.Ready:

                {
                    /*------IDLE-------*/
                    if(lastState == State.Idle)
                    {
                        if(idleCounter <= 0)
                        {
                            lastState = State.Wander;
                            idleCounter = idleLength;
                        }else
                        {
                            curState = State.Idle;
                        }
                    }
                    /*-------WANDER------*/
                    if(lastState == State.Wander)
                    {
                        if(wanderCounter <= 0)
                        {
                            lastState = State.Ready;
                            wanderCounter = wanderLength;
                            wanderTrip = false;
                        }else
                        {
                            curState = State.Wander;
                        }
                    }
                    /*------FLEE-------*/
                    if(lastState == State.Flee)
                    {
                        if(fleeTrip)
                        {
                            fleeCounter -= Time.deltaTime;

                            if(fleeCounter <= 0f)
                            {
                                fleeChange = false;
                                fleeTrip = false;
                            }
                        }
                        if(hasTarget && Vector3.Distance(this.transform.position, mobTarget.transform.position) > rangeToFlee)
                        {
                            panicCounter -= Time.deltaTime;

                            if(panicCounter <= 0f && isPanicking|| !shouldPanic)
                            {
                                anim.SetBool("isMoving", false);
                                anim.SetBool("isFleeing", false);
                                fleeTrip = false;
                                panicCounter = panicLength;
                                cowerCounter = cowerLength;
                                curState = State.Cower;
                            }

                        }else
                        {
                            curState = State.Flee;
                        }
                    }
                    /*-------COWER------*/
                    if(lastState == State.Cower)
                    {
                        if(cowerCounter <= 0f)
                        {
                            isCowering = false;
                            anim.SetBool("isCowering", false);
                            isPanicking = false;
                            holdPlace = false;
                            cowerCounter = cowerLength;
                            curState = State.Idle;
                        }else
                        {
                            curState = State.Cower;
                            holdPlace = false;
                        }

                        if(hasTarget &&Vector3.Distance(this.transform.position, mobTarget.transform.position) < rangeToFlee)
                        {
                            if(curMorale < 2f && hasTarget) {curState = State.Flee;}
                            if(curMorale < 1f && hasTarget) {isPanicking = true;}
                        }

                    }
                    /*-------------*/
                    if(lastState == State.Charge)
                    {
                        if(hasTarget && Vector3.Distance(this.transform.position, mobTarget.transform.position) > rangeToChase)
                        {
                            curState = State.Idle;
                        }else
                        {
                            curState = State.Charge;
                        }
                    }

                    /*-------------*/
                    if(lastState == State.Melee)
                    {
                        
                    }

                }

            /*---------------Morale-------------------*/
            if(curMorale < 2f && hasTarget)
            {
                if(fleeTick)
                {
                    if(Vector3.Distance(this.transform.position, mobTarget.transform.position) < rangeToFlee)
                    {
                        curState = State.Flee;
                    }
                    
                    /*if(curMorale < 1f && hasTarget)
                    {
                        isPanicking = true;
                    }*/
                }
            }else if(curMorale > 2f && hasTarget)
            {
                if(shouldCharge && Vector3.Distance(this.transform.position, mobTarget.transform.position) < rangeToChase)
                {
                    curState = State.Charge;
                }

            }

            if(isCowering)
            {
                holdPlace = true;
            }

            lastState = curState;

            if(curState == State.Ready)
            {
                curState = State.Idle;
            }

        break;
    /*--------------------------------------------------------*/
            case State.Idle:
            
                if(idleTick)
                {
                    anim.SetBool("isMoving", false);
                    if(showEmoteDebug) { Debug.Log("I am bored"); }
                    
                    idleCounter -= Time.deltaTime;

                    lastState = curState;
                    curState = State.Ready;


                }
                break;
    /*----------------------------------------------------------------------------*/
            case State.Wander:
                
                if(wanderTick)
                {

                    if(showEmoteDebug) { Debug.Log("I'm the kind of sprite, who likes to roam around"); }

                    if(!wanderTrip)
                    {
                        moveDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
                        wanderTrip = true;
                    }

                    wanderCounter -= Time.deltaTime;
                    
                    Move();

                    lastState = curState;
                    curState = State.Ready;
                }

                break;
    /*----------------------------------------------------------------------------*/
            case State.Flee:
                
                if(fleeTick)
                {
                    if(!fleeTrip)
                    {
                        fleeCounter -= Time.deltaTime;
                        anim.SetBool("isFleeing", true);
                        moveDirection = this.transform.position - mobTarget.transform.position;
                        if(fleeCounter <= 0f)
                        {
                            fleeCounter = fleeLength;
                            fleeTrip = true;
                        }
                    }

                    if(fleeTrip)
                    {
                        if(!fleeChange)
                        {
                            moveDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
                            fleeChange = true;
                        }
                    }

                    Move();
                }

                lastState = curState;
                curState = State.Ready;

                break;
    /*----------------------------------------------------------------------------*/
            case State.Cower:

                if(cowerTick)
                {
                    holdPlace = true;
                    isCowering = true;
                    anim.SetBool("isCowering", true);
                    cowerCounter -= Time.deltaTime;
                }

                lastState = curState;
                curState = State.Ready;

                break;
    /*----------------------------------------------------------------------------*/
            case State.Stun:
    /*----------------------------------------------------------------------------*/
            case State.Patrol:
                if(showEmoteDebug) { Debug.Log("Hut, hut, hut, hut, hut, hut, hut"); }
                break;
    /*----------------------------------------------------------------------------*/
            case State.Shoot:
                if(showEmoteDebug) { Debug.Log("Pew Pew"); }
                break;
    /*----------------------------------------------------------------------------*/
            case State.Melee:

                if(shouldMelee)
                {
                    lastState = curState;
                }
                break;
    /*----------------------------------------------------------------------------*/
            case State.Charge:

                if(shouldCharge)
                {
                    if(hasTarget)
                    {
                        moveDirection = mobTarget.transform.position;
                        Move();
                    }

                    lastState = curState;
                    curState = State.Ready;
                }
            
            break;

/*----------------------------------------------------------------------------*/
/*--------------------------------Timers--------------------------------------*/
        }

        //Emote
        if(emoteCounter >= 0)
        emoteCounter -= Time.deltaTime;
        
        if(emoteCounter <= 0)
        {
            shouldEmote = true;
            emoteCounter = timeBetweenEmotes;
        }

    }


/*-----------------------------Collisions-------------------------------------*/

    private void OnCollisionEnter(Collision other)
    {
        if(showDebug) { Debug.Log(string.Format("Collide" )); }

        //Friendly
        if(other.gameObject.tag == friend)
        {
            moveDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        }

        //Enemy
        if(other.gameObject.tag == foe)
        {
            mobTarget = other.gameObject;

            if(showEmoteDebug) { Debug.Log(string.Format("Kill that SOB {0}", mobTarget)); }
        }

        //Bump
        if(other.gameObject.tag == "Building")
        {
                moveDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        }
        
    }
    
    private void OnCollisionStay(Collision other) 
    {
        if(other.gameObject.tag == "Building")
            {
                moveDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
            }

        //Friendly
        if(other.gameObject.tag == friend)
        {
            moveDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        }
                
    }

    private void OnTriggerEnter(Collider other) 
    {

        if(other.gameObject.tag == foe && !hasTarget)
        {
            mobTarget = other.gameObject;
            hasTarget = true;

            if(showEmoteDebug) { Debug.Log(string.Format("Kill that SOB {0}", mobTarget)); }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == foe && hasTarget)
        {
            mobTarget = null;
            hasTarget = false;

            if(showEmoteDebug) { Debug.Log(string.Format("Lost that {0}", mobTarget)); }
        }
    }
/*----------------------------------------------------------------------------*/
/*--------------------------Sprites and GFX-----------------------------------*/

        //curSprite = bodies[curSpriteCount];
        //theBody.sprite = curSprite;
}


    /* CODE SNIPPETS

    if(showDebug) { Debug.Log(string.Format("")); }

    //Combat
    /*Initial atk or volley 
    compare ATk roll to target. Holding value of atk for a second i case of multiple attackers
    (possible opponent counter down the line to change animations)
    timer between attacks in SHift state
    Charge towards mftoKills
    revert back to melee state*/
