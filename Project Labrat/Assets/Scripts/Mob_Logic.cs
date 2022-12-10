using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Logic : MonoBehaviour
{
    public static MobLogic instance;

    [Header("Info")]
    public bool showDebug;

    [Header("Tools")]
    public Rigidbody theRB;
    public Animator anim;
    public SpriteRenderer theBody;

    [Header("Stats")]
    public float moveSpeed;
    private float curSpeed;

    [Header("Movement")]
    private Vector3 moveDirection;
    private Vector3 wanderDirection;
    private Vector3 homePoint;
    private bool holdPlace;

    [Header("Bools")]
    public bool shouldIdle;
    public bool shouldWander;
    //public bool shouldFlee;

    //Ticks and Trips
    private bool idleTick, idleTrip;
    private bool wanderTick, wanderTrip;
    //private bool fleeTick, fleeTrip;

    /*--------------------------------------------------------*/
    /*----------------------Functions-------------------------*/

    public void Move()
    {
        if(!holdPlace)
        {
            curSpeed = moveSpeed;
            anim.SetBool("isMoving", true);
            theRB.velocity = moveDirection * curSpeed;
            moveDirection.Normalize();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    /*----------------------------------------------------------------------------*/

    void FixedUpdate()
    {
        
    }
}