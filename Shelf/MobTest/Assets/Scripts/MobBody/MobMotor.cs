using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMotor : MonoBehaviour
{
    public static MobMotor instance;

    [Header("Mob Body")]
    public MobBrain Brain;
    public MobInfo Info;
    public MobMotor Motor;
    public MobSense Sense;
    public GameObject EmotePoint;

    [Header("Movement")]
    public Vector3 moveDirection;
    private Vector3 wanderDirection;
    public Vector3 homePoint;
    private bool holdPlace;

    void Start()
    {
        
    }

    public void Move()
    {
        Info.curSpeed = Info.moveSpeed;
        //Info.anim.SetBool("isMoving", true);
        Info.theRB.velocity = moveDirection * Info.curSpeed;
        moveDirection.Normalize();
    }

    void Update()
    {

    }
}
