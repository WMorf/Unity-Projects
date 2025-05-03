using System;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public ShipSystems shipSystem;
    public bool playerControl;

    public float speedThrust, speedSpin;

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
        }
    }

    void FixedUpdate()
    {

    }

    void CheckKey()
    {
        //Thrust
        if (shipSystem.thrusterForward != null)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Thrust(1f);
                spriteRenderer.color = Color.red;
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                Thrust(0f);
                spriteRenderer.color = Color.grey;
            }


            if (Input.GetKeyDown(KeyCode.S))
            {
                Thrust(-1f);
                spriteRenderer.color = Color.red;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                Thrust(0f);
                spriteRenderer.color = Color.grey;
            }
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
        rb.AddForce(transform.up * speedThrust * i, ForceMode2D.Force);
    }

    void Rotate(float i)
    {
        rb.AddTorque(speedSpin * i);
    }
}
