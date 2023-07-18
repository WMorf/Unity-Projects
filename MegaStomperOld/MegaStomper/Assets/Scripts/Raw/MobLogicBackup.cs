using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MobLogicBackup : MonoBehaviour
{
    public static MobLogicBackup instance;

    [Header("Info")]
    public bool showDebug;
    public string namePlate;
    public List<string> nameDatabase = new List<string>();
    public int serialID;
    

    [Header("Stats")]
    public float moveSpeed;
    private float curSpeed;
    public int atkSkill;
    private int atkValue;
    public int endurance;
    private int curEndurance;

    [Header("Relations")]
    public List<GameObject> friendsList;
    public int maxFriends;
    public string foe;
    public string friend;
    //private bool sameName;

    [Header("Threat and Morale")]
    public int moraleBase;
    private int curMorale;
    public int threatMin, threatMax;
    private int curThreat;


    [Header("Movement")]
    private Vector3 moveDirection;
    private Vector3 shiftDirection;
    private Vector3 chargeDirection;
    private Vector3 wanderDirection;
    private Vector3 homePoint;

    [Header("Bools")]
    public bool shouldIdle;
    public bool shouldCharge;
    public bool shouldWander;
    public bool shouldShoot;
    public bool shouldMelee;
    public bool shouldGib;
    public bool shouldDropItems;
    public bool shouldEmote;

/*-------------------------STATES--------------------------*/

    [Header("Ready")]
    public GameObject mfToKill;
    private float mfRange;
    public float rangeToChase;
    private bool hasTarget;
    private bool isGuarding;
    private float pauseCollider =.3f;

    [Header("Idle")]
    public float idleLength;
    private float idleCounter;
    //public bool blockWhenIdle;
    //private bool willBlock;

    [Header("Wander")]
    public float wanderLength;
    private float wanderCounter;
    private bool wanderTick;

    [Header("Shoot")]
    public GameObject bullet;
    public Transform firePoint;

    [Header("Melee")]
    public float meleeTimeLength;
    private float meleeCounter;
    public int attacksPerShift;
    public int woundThreshold;
    private bool meleeBump;

    [Header("Shift")]
    public float shiftTimeLength;
    private float shiftCounter;
    private bool shiftTick = false;

    [Header("Charge")]
    public float timeBetweenCharging;
    private float chargeTime;
    private bool isCharging;
    
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

    //Enums
    enum State {Ready, Idle, Wander, Patrol, Shoot, Melee, Shift, Charge};
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

        //Timers
        wanderCounter = wanderLength;
        emoteCounter = timeBetweenEmotes;
        shiftCounter = shiftTimeLength;
        curSpeed = moveSpeed;
        meleeCounter = meleeTimeLength;
        idleCounter = idleLength;
            
        //Time between emote icons and logs apearing
        if (shouldEmote) { emoteTick = true; }

        //Starting appearance of mob
        curSpriteCount = 0;

        //Relationships
        //sameName = false;

        //Starting position
        homePoint = transform.position;
        meleeBump = false;
            
    }

/*--------------------------------------------------------*/
/*----------------------Functions-------------------------*/

    public void Identify()
    {
        int randName = Random.Range(1, nameDatabase.Count);
        serialID = Random.Range(100, 999);
        
        if(namePlate == null)
        {
            namePlate = nameDatabase[randName];
        }

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

    public void FriendBump(GameObject other)
    {
        if(showDebug) { Debug.Log("Excuse Me"); }
        
        Emote(1);

        //Scan for duplicates in friend list. Needs rework
        /*for(int i = 0; i < friendsList.Count; i++)
        {

            sameName = false;

            if(friendsList[i] == other.gameObject)
            {
                sameName = true;
            }else
            {
            }
            
        }*/
    }

    public void Move()
    {
        //anim.SetBool("IsMoving", true);
        theRB.velocity = moveDirection * curSpeed;
        moveDirection.Normalize();
    }

/*----------------------------------------------------------------------------*/
/*-----------------------------Collisions-------------------------------------*/

    private void OnCollisionEnter(Collision other)
    {
        if(pauseCollider <= 0f)
        {
            pauseCollider = .3f;

            if(showDebug) { Debug.Log(string.Format("Collide" )); }

            //Friendly
            if(other.gameObject.tag == friend)
            {
                //FriendBump(other.gameObject);
            }

            //Enemy
            if(other.gameObject.tag == foe)
            {

                if(!hasTarget && shouldMelee)
                {
                    meleeBump = true;
                    hasTarget =true;
                    mfToKill = other.gameObject;
                    //curState = State.Melee;

                    if(showDebug) { Debug.Log(string.Format("Kill that SOB {0}", mfToKill)); }
                }

                if(other.gameObject == mfToKill && hasTarget)
                {
                    isCharging = false;
                    //curState = State.Melee;
                }
            }

            //Bump
            if(other.gameObject.tag == "Building")
            {
                if(!isCharging)
                {
                    lastState = curState;
                    //if(showDebug) { Debug.Log("Ooof"); }
                    Emote(2);
                    //wanderCounter = wanderCounter + 1f;
                    moveDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
                }
            }
        }
    }
    
    private void OnCollisionStay(Collision other) 
    {
        if(other.gameObject.tag == "Building")
            {
                if(!isCharging)
                {
                    //wanderCounter = wanderCounter + 1f;
                    moveDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
                }
                
            }
    }

/*--------------------------------------------------------*/

    void FixedUpdate()
    {
        //if(showDebug) { Debug.Log(string.Format("{0}{1}",namePlate, curState)); }

/*--------------------------------------------------------*/
/*-----------------Switches and Logic---------------------*/
        switch(curState)
        {


/*----------------------------------------------------------------------------*/
            case State.Ready:

//new plan. Feed every state through Ready.Collider might be causing to many switch calls. Discovered after multiple 
//emotes spawned while bumping into wall


            if(meleeBump && shouldMelee)
            {
                meleeBump = false;
                curState = State.Melee;
            }else
                {
                    if(lastState == State.Idle)
                    {
                        if(idleCounter <= 0)
                        {
                            curState = State.Wander;
                            idleCounter = Random.Range(idleLength * .75f, idleLength * 1.25f);
                        }else
                        {
                            curState = State.Idle;
                        }
                    }

                    if(lastState == State.Wander)
                    {
                        if(wanderCounter <= 0)
                        {
                            curState = State.Idle;
                            wanderCounter = Random.Range(wanderLength * .75f, wanderLength * 1.25f);
                            wanderTick = false;
                        }else
                        {
                            curState = State.Wander;
                        }
                    }

                    if(lastState == State.Melee)
                    {
                        if(meleeCounter <= 0)
                        {
                            meleeCounter = meleeTimeLength;
                            shouldMelee = true;
                            meleeBump = false;
                            curState = State.Shift;
                        }else
                        {
                            curState = State.Melee;
                        }
                    }

                    if(lastState == State.Shift)
                    {

                        if(shiftCounter <= 0)
                        {
                            shiftTick = false;
                            curSpeed = moveSpeed;
                            shiftCounter = shiftTimeLength;
                            shouldCharge = true;
                        }else
                        {
                            curState = State.Shift;
                        }

                        if(shouldCharge)
                        {
                            if(hasTarget)
                            {
                                mfRange = Vector3.Distance(instance.transform.position, mfToKill.transform.position);

                                if(mfRange > rangeToChase)
                                {
                                    if(showDebug) { Debug.Log(string.Format("Lost em {0}", mfRange)); }
                                    hasTarget = false;

                                    curState = State.Idle;
                                    //Set to ready and if lacking mfToKill switch to Idle. Ready will be the powerhous of decision making.
                                }

                                if(mfRange < rangeToChase)
                                {
                                    curState = State.Charge;
                                }
                            }
                        }

                    if(lastState ==  State.Charge)
                    {
                        curState = State.Charge;
                    }
                }
            }

            lastState = curState;

            if(curState == State.Ready)
            {
                curState = State.Idle;
            }

            break;
/*--------------------------------------------------------*/
            case State.Idle:
            
                if(shouldIdle)
                {
                    anim.SetBool("IsMoving", false);
                    if(showDebug) { Debug.Log("I am bored"); }
                    
                    idleCounter -= Time.deltaTime;

                    lastState = curState;
                    curState = State.Ready;
                }
                break;
    /*----------------------------------------------------------------------------*/
            case State.Wander:
                
                if(shouldWander)
                {
                    anim.SetBool("IsMoving", true);

                    if(showDebug) { Debug.Log("I'm the kind of sprite, who likes to roam around"); }

                    if(!wanderTick)
                    {
                        moveDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
                        wanderTick = true;
                    }

                    wanderCounter -= Time.deltaTime;
                    
                    Move();

                    curState = State.Ready;
                }
                break;
    /*----------------------------------------------------------------------------*/
            case State.Patrol:
                if(showDebug) { Debug.Log("Hut, hut, hut, hut, hut, hut, hut"); }
                break;
    /*----------------------------------------------------------------------------*/
            case State.Shoot:
                if(showDebug) { Debug.Log("Pew Pew"); }
                break;
    /*----------------------------------------------------------------------------*/
            case State.Melee:

                if(shouldMelee)
                {
                    shouldEmote = true;
                    Emote(3);
                    if(showDebug) { Debug.Log("Prepare to die!"); }

                    atkValue = Random.Range(1, 20) + atkSkill;
                    if(showDebug) { Debug.Log(string.Format("{0}'s attack roll was {1}", namePlate, atkValue)); }

                    meleeCounter = meleeCounter - Time.deltaTime;
                    shouldMelee = false;

                }else
                {
                    curState = State.Shift;
                }

                break;

    /*----------------------------------------------------------------------------*/
            case State.Shift:

                if(!shiftTick)
                {
                    shiftTick = true;
                    shiftDirection = transform.position - mfToKill.transform.position;
                    moveDirection = shiftDirection;
                    curSpeed = curSpeed * .75f;
                }

                Move();

                shiftCounter = shiftCounter - Time.deltaTime;

                lastState = curState;
                curState = State.Ready;

            break;

    /*----------------------------------------------------------------------------*/
    //Bugged, launches off map
    
            case State.Charge:

            if(shouldCharge)
            {

                if(mfRange < rangeToChase)
                {

                    if(!isCharging)
                    {


                        //Direction manipulation
                        isCharging = true;
                        homePoint = transform.position;
                        chargeDirection = new Vector3(mfToKill.transform.position.x, 0f, mfToKill.transform.position.z);
                        moveDirection = chargeDirection;
                            
                        //Debug
                        if(showDebug)
                        {
                            Instantiate(beacon, mfToKill.transform.position, mfToKill.transform.rotation);
                            Debug.Log(string.Format("CHAAAARGE!"));
                            Debug.Log(string.Format("They are at {0}", chargeDirection));
                        }
                        
                    }

                    if(isCharging)
                    {
                        //chargeDirection = mfToKill.transform.position;
                        //moveDirection = chargeDirection;
                        Move();
                        chargeTime = chargeTime + Time.deltaTime;
                    }

                    //Debug t stop void running
                    if(chargeTime >= 10f)
                    {
                        curState = State.Idle;
                        hasTarget = false;
                        transform.position = homePoint;
                        if(showDebug) { Debug.Log(string.Format("Let the man in Black go, Gunslinger")); }
                        chargeTime = 0f;
                        isCharging = false;
                    }

                }else
                {
                    isCharging = false;
                    curState = State.Ready;
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

        //Collider
        pauseCollider = pauseCollider - Time.deltaTime;
        
        
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

}