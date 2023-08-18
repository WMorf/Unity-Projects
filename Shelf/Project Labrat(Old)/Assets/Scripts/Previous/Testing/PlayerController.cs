using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public CharacterController characterController;
    public float speed = 5f;

    //Gravity
    private float gravity = 10f;
    private float verticalSpeed = 0f;

    //Camera
    public Transform cameraHolder;
    public float mouseSensitivity = 2f;
    public float upLimit = -50;
    public float downLimit = 50;

    //Missles
    public float timeBetweenMissles;
    private float missleCounter;
    private bool readyToLaunch;
    public Transform firePoint;
    public GameObject missleAlert;
    public GameObject missleToFIre;

    private void Awake()
    {
        instance = this;
    }
            
    /*void Start()
    {
        
    }*/

    void Update()
    {
        Move();
        Rotate();

        //Missle Code
        missleCounter -= Time.deltaTime;

        if(missleCounter >= timeBetweenMissles)
        {
            if(!readyToLaunch)
            Instantiate(missleAlert, transform.position, transform.rotation);
            readyToLaunch = true;
        }

        if(Input.GetMouseButtonDown(1) || Input.GetButton("Fire2"))
        {
            missleCounter -= Time.deltaTime;

            if(missleCounter <= 0)
            {
                Instantiate(missleToFIre, firePoint.position, firePoint.rotation);
                missleCounter = timeBetweenMissles;
                readyToLaunch = false;
            }
        }

        if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0,.5f,0);
        }

        if(Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0,-.5f,0);
        }

    }

    private void Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        if(characterController.isGrounded)
        {
            verticalSpeed = 0;
        }else 
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }

        Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);
        Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove;
        characterController.Move(speed * Time.deltaTime * move + gravityMove * Time.deltaTime);
    }
    
    public void Rotate()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");
        
        transform.Rotate(0, horizontalRotation * mouseSensitivity, 0);
        cameraHolder.Rotate(-verticalRotation*mouseSensitivity,0,0);

        Vector3 currentRotation = cameraHolder.localEulerAngles;
        
        if (currentRotation.x > 180)
        {
            currentRotation.x -= 360;
        }

        currentRotation.x = Mathf.Clamp(currentRotation.x, upLimit, downLimit);
        cameraHolder.localRotation = Quaternion.Euler(currentRotation);
    } 

}

//Tutorial https://itnext.io/how-to-write-a-simple-3d-character-controller-in-unity-1a07b954a4ca
