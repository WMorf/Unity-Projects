using System;
using UnityEngine;

public class ShipControllerTest : MonoBehaviour
{

    public Rigidbody2D rb;
    public SpriteRenderer thrustBar;
    public ShipSystems shipSystem;
    public bool playerControl, dummyDrive, thrustTrue;

    public float speedThrust, speedSpin, speedMax;

    public GameObject projectile;
    public Transform firePoint;


    void Start()
    {

    }
    void Update()
    {
        if (playerControl)
        {
            CheckKey();
            //Debug.Log("hit");
        }
        if (dummyDrive)
        {
            Thrust(1f);
            thrustBar.color = Color.red;
        }
        if (shipSystem.thrusterForward = null)
        {
            thrustBar.color = Color.grey;
        }
        if (thrustTrue)
        {
            Thrust(1f);
        }
        if (rb.linearVelocity.magnitude > speedMax)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * speedMax;
        }
    }

    void FixedUpdate()
    {

    }

    void CheckKey()
    {
        //Thrust

        if (Input.GetKeyDown(KeyCode.W)) 
        {
            thrustTrue = true;
            thrustBar.color = Color.red;
            Debug.Log("hit");
        }

        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    thrustTrue = true;
        //    //Thrust(1f);
        //    thrustBar.color = Color.red;
        //}
        if (Input.GetKeyUp(KeyCode.W))
        {
            thrustTrue = false;
            //Thrust(0f);
            thrustBar.color = Color.grey;
        }

        //Rotate
        if (shipSystem.thrusterLeft != null)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Rotate(1f);
            }
        }

        if (shipSystem.thrusterRight != null)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                Rotate(-1f);
            }
        }


        //Fire
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }

    }

    private void Fire()
    {
        Instantiate(projectile, firePoint.transform);
    }


    //Needs a pass, primitive and clunky
    void Thrust(float i)
    {
        //rb.AddForce(transform.up * speedThrust * i, ForceMode2D.Force);
        if (shipSystem.thrusterForward = null)
        {
            Debug.Log("Thruster Damaged or Missing");
        }
        else
        {
            rb.AddForce(transform.up * speedThrust * i, ForceMode2D.Force);
        }
    }

    void Rotate(float i)
    {
        rb.AddTorque(speedSpin * i);
    }

    
}
