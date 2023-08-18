using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;
    
    [Header("Stats")]
    public int health = 15;
    public float moveSpeed;
    private Vector2 facing = Vector2.zero;
    private Vector3 bodyPoint, backPoint;
    private float flipCount;
    public float flipMax =.25f;

    [Header("Idles")]
    public int idleMax;
    public bool shouldIdlePick;
    public float startIdle;


    [Header("Chase Player")]
    public bool shouldChase;
    public bool shouldfollowProphet;
    private bool followProphet;
    public float rangeToChasePlayer;
    private Vector3 moveDirection;

    [Header("Runaway")]
    public bool shouldRunaAway;
    public float runAwayRange;

    [Header("Wander")]
    public bool shouldWander;
    private bool wanderTick = false;
    public float wanderLength, pauseLength;
    private float wanderCounter, pauseCounter, panicCounter;
    private Vector3 wanderDirection;
    
    [Header("Patrolling")]
    public bool shouldPatrol;
    public Transform[] patrolPoints;
    private int currentPatrolPoints;

    [Header("Gibbing")]
    public GameObject[] deathSplatters;
    public GameObject hitEffect;
    public bool blockWhenIdle;
    private bool willBlock;

    [Header("Shooting")]
    public bool shouldShoot;
    public GameObject bullet;
    public Transform firePoint;
    public float fireRate;
    private float fireCounter;
    public float shotRange;

    [Header("Drops")]
    public bool shouldDropItems;
    public GameObject[] itemsToDrop;
    public float itemDropPercent;

    [Header("Tools")]
    public Rigidbody2D theRB;
    public Animator anim;
    public SpriteRenderer theBody;

    private float scaleY,scaleX;

    [Header("Detection")]
    public bool seekTarget = true;
    public int Team;
    public List<GameObject>[] target;
    public string bot1 = "Player";
    public string bot2 = "Mob2";
        
    private void Awake()
    {
        instance = this;
    }




    // Start is called before the first frame update
    void Start()
    {
        if(shouldWander)
        {
            pauseCounter = Random.Range(pauseLength * .75f, pauseLength * 1.25f);
        }

        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
        flipCount = flipMax;
        backPoint = transform.position;
        anim.SetFloat("Idle",startIdle);
    }

    // Update is called once per frame
    // Need to halt movement on cower. Wrap panic state around all movement.
    void Update()
    {
        bodyPoint.x = transform.position.x;

        if(flipCount > 0 )
        {
            flipCount -= Time.deltaTime;

            if(flipCount <= 0)
            {
                flipCount = .5f;
                backPoint = bodyPoint;
            }
        }
           
        //Move n Shoot
        if(theBody.isVisible /*&& target.gameObject.activeInHierarchy*/)
        {
            moveDirection = Vector3.zero;

            //Chase
            if(Vector3.Distance(transform.position, /*target[0].*/transform.position) < rangeToChasePlayer && shouldChase)
            {
                moveDirection = /*target[0].*/transform.position - transform.position;
            }else
            {
                //Follow Prophet
                /*if(shouldfollowProphet)
                {
                    if(Vector3.Distance(transform.position, Prophet.instance.transform.position) < rangeToChasePlayer)
                    {
                        moveDirection = Prophet.instance.transform.position - transform.position;
                        //followProphet = true;

                    }else
                    {
                        followProphet = false;
                    }
                }*/
                        
                //Wander
                if(shouldWander && theBody.isVisible)
                {
                    if(wanderCounter > 0)
                    {
                        wanderCounter -= Time.deltaTime;

                        //move the enemy
                        moveDirection = wanderDirection;

                        if(wanderCounter <= 0)
                        {
                            pauseCounter = Random.Range(pauseLength * .75f, pauseLength * 1.25f);
                        
                        if(shouldIdlePick)
                            {
                                IdlePick();
                            }
                        }
                    }

                    if(pauseCounter > 0 )
                    {
                        pauseCounter -= Time.deltaTime;

                        if(pauseCounter <= 0)
                        {
                            wanderCounter = Random.Range(wanderLength * .75f, wanderLength * 1.25f);

                            wanderDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);

                            if(shouldIdlePick)
                            {
                                IdlePick();
                            }
                        }
                    }
                }
                if(shouldPatrol)
                {
                    moveDirection = patrolPoints[currentPatrolPoints].position - transform.position;

                    if(Vector3.Distance(transform.position, patrolPoints[currentPatrolPoints].position) < .2f)
                    {
                        currentPatrolPoints++;
                        if(currentPatrolPoints >= patrolPoints.Length)
                        {
                            currentPatrolPoints = 0;
                        }
                    
                    }
                }
            }

            //RunAway
            if(shouldRunaAway && Vector3.Distance(transform.position, /*target.*/transform.position)  < runAwayRange)
            {
                anim.SetBool("Panic",true);
                moveDirection = transform.position - /*target.*/transform.position;
                wanderDirection = moveDirection;

                /*Scrap
                if(moveDirection.x <= transform.position.x)
                {
                    anim.SetInteger("Right",1);
                    anim.SetInteger("Left",0);
                }else if(moveDirection.x >= transform.position.x)
                {
                    anim.SetInteger("Right",0);
                    anim.SetInteger("Left",1);
                }*/
            }


            //Smoothing
            moveDirection.Normalize();
            
            //GFX Flip
            if(bodyPoint.x < backPoint.x)
            {
                transform.localScale = new Vector2(scaleX, transform.localScale.y);
                
            }else if(bodyPoint.x > backPoint.x)
            {
                 transform.localScale = new Vector2(-scaleX, transform.localScale.y);
                 //Instantiate(hitEffect, transform.position, transform.rotation);
            }

            //Movement
            theRB.velocity = moveDirection * moveSpeed;

            //Shoot
            if(shouldShoot && Vector3.Distance(transform.position, /*target.*/transform.position) < shotRange)
            {
                fireCounter -= Time.deltaTime;

                if(fireCounter <= 0)
                {
                    anim.SetTrigger("shoot");
                    fireCounter = fireRate;
                    Instantiate (bullet, firePoint.transform.position, firePoint.transform.rotation);
                    AudioManager.instance.PlaySFX(17);
                }
            }


        //Halt
        }else
        {
            theRB.velocity = Vector2.zero;
            seekTarget = true;
            //anim.SetBool("Panic",false);
        }
        //Moving Animation
        if(moveDirection != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
            if(blockWhenIdle)
            {
                willBlock = false;
            }
        }else
        {
            anim.SetBool("isMoving", false);
            anim.SetBool("Panic", false);
            if(blockWhenIdle)
            {
                willBlock = true;
            }
            if(shouldWander)
            {
                shouldWander = false;
                wanderTick = true;
            }
        }

        if(wanderTick)
        {
            panicCounter -= Time.deltaTime;
            
            if(panicCounter <= 0)
            {
                shouldWander = true;
                wanderTick = false;
            }
        }
    }

    //Seek out Target
    /*public void OnTriggerEnter2D(Collider2D other) 
    {
        if(seekTarget)
        {
            //for loop repeats for everything that collides with trigger area
            for(int i = 0; i < others.Length; i++)
            {
 
                if(others[i].gameObject.tag == bot1)
                {
                    if(other.gameObject.tag == bot1)
                    {
                        target = other.gameObject;
                        seekTarget = false;
                        print(target.gameObject);
                    }
                }
                else if(others[i].gameObject.tag == bot2)
                {
                    target = other.gameObject;
                    seekTarget = false;
                    print(instance.gameObject + "I see " + target.gameObject);
                }
            }
        }
    }*/
    
    //Forget Target
    private void OnTriggerExit2D(Collider2D other) 
    {
        
    }

    public void IdlePick()
    {
        anim.SetInteger( "Idle", Random.Range(1, idleMax ));
    }

    public void damageEnemy(int damage)
    {
        if(!willBlock)
        {
            health -= damage;

            Instantiate(hitEffect, transform.position, transform.rotation);
            AudioManager.instance.PlaySFX(2);
        }

        if(health <= 0)
        {
            Destroy(gameObject);
            AudioManager.instance.PlaySFX(1);

            int selectedSplatter = Random.Range(0, deathSplatters.Length);
            int rotation = Random.Range(0, 4);

            Instantiate(deathSplatters[selectedSplatter], transform.position, Quaternion.Euler(0f,0f, rotation *90f));

            if(shouldDropItems)
            {
                float dropRoll = Random.Range(0f, 100f);

                if(dropRoll < itemDropPercent)
                {
                    int randomItem = Random.Range(0, itemsToDrop.Length);

                    Instantiate(itemsToDrop[randomItem], transform.position, transform.rotation);
                }
            }
        }
    }

}
