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
    private Vector3 homePoint;
    private bool holdPlace;

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
