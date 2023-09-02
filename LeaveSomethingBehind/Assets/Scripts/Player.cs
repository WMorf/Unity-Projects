using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float runSpeed = 1f;
    public float jumpSpeed = 1f;

    [Header("Objects")]
    public GameObject tossBall;

    [Header("Components")]
    Rigidbody2D myRigidbody2D;
    float startingGravity;
    Animator myAnimator;
    BoxCollider2D myBoxCollider2D;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();
        startingGravity = myRigidbody2D.gravityScale;
    }

    void Update()
    {
        Run();
        //Jump();
        Toss();
    }

    private void Toss()
    {
        if(Input.GetKeyDown(KeyCode.Q)) 
        {
            GameObject activeBall = Instantiate<GameObject>(tossBall, transform.position, Quaternion.identity);
        }
    }

    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal");

        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidbody2D.velocity.y);
        myRigidbody2D.velocity = playerVelocity;
    }

    
}
