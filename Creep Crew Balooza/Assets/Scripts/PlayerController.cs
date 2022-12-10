using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;
    
    public float moveSpeed;
    private Vector2 moveInput;

    public Rigidbody2D theRB;

    public Transform gunArm;

    private Camera theCam;
    public Camera zoomCam;

    public Animator anim;
    public GameObject bulletToFire;
    public GameObject missleToFIre;
    public GameObject shotPoint;

    public Transform firePoint;

    public float timeBetweenShots,timeBetweenMissles;
    private float shotCounter,missleCounter;
    private bool readyToLaunch;
    public GameObject missleAlert;

    public float spread;

    public SpriteRenderer bodySR;
    public LayerMask whoTarget;

    private float activeMoveSpeed;
    public float dashSpeed = 8f, dashLength = .5f, dashCooldown = 1f, dashInvincibillity = .4f;
    private Vector3 mouseClick;

    [HideInInspector]
    public float dashCounter;
    private float dashCoolCounter;

    public GameObject shell;

    public bool canMove = true;

    private void Awake() 
    {
        instance = this;
    }

    void Start()
    {
            theCam = Camera.main;
            readyToLaunch = false;
            activeMoveSpeed = moveSpeed;

    }

    void Update()
    {
        //Movement
        if(canMove && !LevelManager.instance.isPaused)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
            moveInput.Normalize();

            anim.SetFloat("Horizontal", moveInput.x);
            anim.SetFloat("Vertical", moveInput.y);
        }

        missleCounter -= Time.deltaTime;

        if(missleCounter >= timeBetweenMissles)
        {
            if(!readyToLaunch)
            Instantiate(missleAlert, transform.position, transform.rotation);
            readyToLaunch = true;
        }



        if(canMove && !LevelManager.instance.isPaused)
        {
            theRB.velocity = moveInput * activeMoveSpeed;

            //Facing
            Vector3 mousePos = Input.mousePosition;
            Vector3 screenPoint = theCam.WorldToScreenPoint(transform.localPosition);
            Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
            float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            gunArm.rotation = Quaternion.Euler(0, 0, angle);
            

            //gunarm flip
            /*if(mousePos.x < screenPoint.x)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                gunArm.localScale = new Vector3(-1f, -1f, 1f);
            }   else
            {
                transform.localScale = Vector3.one;
                gunArm.localScale = Vector3.one;
            }*/

            //Shooting
            if(Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1"))
            {

                Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
                AudioManager.instance.PlaySFX(12);
                Instantiate(shell, gunArm.position, gunArm.rotation);
                shotCounter = timeBetweenShots;
                
            }

            if(Input.GetMouseButton(0) || Input.GetButton("Fire1"))
            {
                shotCounter -= Time.deltaTime;

                if(shotCounter <= 0)
                {
                    Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
                    AudioManager.instance.PlaySFX(12);
                    Instantiate(shell, gunArm.position, gunArm.rotation);

                    shotCounter = timeBetweenShots;
                }
            }

            if(Input.GetMouseButton(1) || Input.GetButton("Fire2"))
            {
                missleCounter -= Time.deltaTime;

                if(missleCounter <= 0)
                {
                    Instantiate(missleToFIre, firePoint.position, firePoint.rotation);
                    AudioManager.instance.PlaySFX(12);
                    missleCounter = timeBetweenMissles;
                    readyToLaunch = false;
                    mouseClick = Input.mousePosition;
                    //Instantiate(shotPoint, );
                }
            }

            if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
            {
                if(dashCoolCounter <=0 && dashCounter <= 0)
                {
                    activeMoveSpeed = dashSpeed;
                    dashCounter = dashLength;

                    anim.SetTrigger("dash");
                    AudioManager.instance.PlaySFX(8);

                    HealthManager.instance.MakeInvincible(dashInvincibillity);
                }else
                {
                    AudioManager.instance.PlaySFX(4);
                }
            }

            if(Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }

            if(Input.GetKeyDown(KeyCode.Z))
            {
                zoomCam.orthographicSize --;
                if(zoomCam.orthographicSize < 1)
                {
                    zoomCam.orthographicSize = 1;
                }
            }

            if(Input.GetKeyDown(KeyCode.X))
            {
                zoomCam.orthographicSize ++;
                if(zoomCam.orthographicSize > 10)
                {
                    zoomCam.orthographicSize = 10;
                }

            }

            if(dashCounter > 0)
            {
                dashCounter -= Time.deltaTime;
                if(dashCounter <= 0)
                {
                    activeMoveSpeed = moveSpeed;
                    dashCoolCounter = dashCooldown;
                }
            }

            if(dashCoolCounter > 0)
            {
                dashCoolCounter -= Time.deltaTime;
            }

            //Animations

            if(moveInput != Vector2.zero)
            {
                anim.SetBool("isMoving", true);
            }else
            {
                anim.SetBool("isMoving", false);
            }

            //transform.position += new Vector3(moveInput.x * Time.deltaTime * moveSpeed, moveInput.y * Time.deltaTime * moveSpeed, 0f);

        }else
        {
            theRB.velocity = Vector2.zero;
            anim.SetBool("isMoving", false);
        }

    }
}

