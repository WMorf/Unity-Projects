using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3D : MonoBehaviour
{
    [Header("Movement")]
    public float runSpeed = 1f;
    public float jumpSpeed = 1f;
    //private float lastThrow;

    [Header("Objects")]
    public GameObject rubberBall;
    public GameObject metalBall;
    public GameObject currentBall;
    public GameObject firePoint;

    [Header("FX")]
    public GameObject sparks;

    [Header("Components")]
    Rigidbody myRigidbody;
    //float startingGravity;
    Animator myAnimator;
    BoxCollider myBoxCollider;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
        myBoxCollider = GetComponent<BoxCollider>();
        //startingGravity = myRigidbody.;


    }

    void Update()
    {
        Run();
        //Jump();

        if (Input.GetKeyDown(KeyCode.D))
        {
            //transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    transform.rotation = Quaternion.Euler(0, -180, 0);
        //}

        BallType();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Toss();
        }
    }

    private void BallType()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentBall = rubberBall;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentBall = metalBall;
        }
    }

    private void Toss()
    {
        if(currentBall.gameObject != null) 
        {
            GameObject activeBall = Instantiate<GameObject>(currentBall, firePoint.transform.position, Quaternion.identity);

            if (transform.localScale.x > 0)
            {
                activeBall.GetComponent<Rigidbody>().AddForce(transform.right * 1000f);
            }
            else
            {
                activeBall.GetComponent<Rigidbody>().AddForce(-transform.right * 1000f);
            }
        }
        else
        {
            Instantiate<GameObject>(sparks, firePoint.transform.position, Quaternion.identity);
        }

    }


    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal");

        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;


    }

}
