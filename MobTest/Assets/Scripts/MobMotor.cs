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

    [Header("Movement")]
    private Vector3 moveDirection;
    private Vector3 wanderDirection;
    public Vector3 homePoint;
    private bool holdPlace;

    void Start()
    {
        moveDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
    }

    public void Move()
    {
        Info.curSpeed = Info.moveSpeed;
        Info.anim.SetBool("isMoving", true);
        Info.theRB.velocity = moveDirection * Info.curSpeed;
        moveDirection.Normalize();
    }

    void Update()
    {

        Move();
    }
}
