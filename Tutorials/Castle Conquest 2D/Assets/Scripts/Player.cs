using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 15f;
    [SerializeField] float climbingSpeed = 8f;
    [SerializeField] float attackRadius = 2f;
    [SerializeField] Vector2 hitKick = new Vector2 (50f, 50f); //Knockback
    [SerializeField] Transform hurtBox; //Point to generate damage gizmo
    [SerializeField] AudioClip jumpingSFX, attackingSFX, gettingHitSFX, walkingSFX;

    Rigidbody2D myRigidbody2D;
    Animator myAnimator;
    BoxCollider2D myBoxCollider2D;
    PolygonCollider2D myPlayersFeet;
    AudioSource myAudioSource;

    float startingGravityScale;
    bool isHurting = false;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();
        myPlayersFeet = GetComponent<PolygonCollider2D>();
        myAudioSource = GetComponent<AudioSource>();

        startingGravityScale = myRigidbody2D.gravityScale;

        myAnimator.SetTrigger("Appearing");
    }


    void Update()
    {
        if (!isHurting)
        {
            Run();
            Jump();
            Climb();
            Attack();

            if(myBoxCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy")))
            {
                PlayerHit();
            }

            ExitLevel();
        }
    }

    private void ExitLevel()
    {
       if(!myBoxCollider2D.IsTouchingLayers(LayerMask.GetMask("Interact")))
        {
            return;
        }

       if(CrossPlatformInputManager.GetButtonDown("Vertical"))
        {
            myAnimator.SetTrigger("Dissapearing");
        }

    }

    public void LoadNextLevel()
    {
        FindObjectOfType<ExitDoor>().StartLoadingNextLevel();
        TurnOffRenderer();
    }

    public void TurnOffRenderer()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    private void Attack()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            myAnimator.SetTrigger("Attacking");
            myAudioSource.PlayOneShot(attackingSFX);

            Collider2D[] enemiesToHit = Physics2D.OverlapCircleAll(hurtBox.position, attackRadius, LayerMask.GetMask("Enemy"));

            foreach(Collider2D enemy in enemiesToHit)
            {
                //print("Hit-" + enemy);
                Enemy enemyScript = enemy.GetComponent<Enemy>();
                enemyScript.Dying();
            }
        }
    }

    public void PlayerHit()
    {
        myRigidbody2D.velocity = hitKick * new Vector2(-transform.lossyScale.x, 1f);

        myAnimator.SetTrigger("Hitting");
        myAudioSource.PlayOneShot(gettingHitSFX);
        isHurting = true;

        FindAnyObjectByType<GameSession>().ProccessPlayerDeath();

        StartCoroutine(StopHurting());
    }

    IEnumerator StopHurting()
    {
        yield return new WaitForSeconds(2f);

        isHurting = false;
    }

    private void Climb()
    {
        if(myBoxCollider2D.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
            Vector2 climbingVelocity = new Vector2(myRigidbody2D.velocity.x, controlThrow * climbingSpeed);

            myRigidbody2D.velocity = climbingVelocity;

            myAnimator.SetBool("Climbing", true);

            myRigidbody2D.gravityScale = 0f;
        }
        else
        {
            myAnimator.SetBool("Climbing", false);

            myRigidbody2D.gravityScale = startingGravityScale;
        }
    }

    private void Jump()
    {

        if (!myPlayersFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        bool isJumping = CrossPlatformInputManager.GetButtonDown("Jump");

        if (isJumping)
        {
            Vector2 jumpVelocity = new Vector2(myRigidbody2D.velocity.x, jumpSpeed);
            myRigidbody2D.velocity = jumpVelocity;

            myAudioSource.PlayOneShot(jumpingSFX);
        }
    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        //print(controlThrow);

        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidbody2D.velocity.y);
        myRigidbody2D.velocity = playerVelocity;
        //print(playerVelocity);


        FlipSprite();//Only used when running hence placement
        ChangingToRunningState();
    }

    void StepsSFX()
    {
        bool playerMovingHorizontially = Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;

        if(playerMovingHorizontially)
        {
            if (myBoxCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                myAudioSource.PlayOneShot(walkingSFX);
            }
        }
        else
        {
            myAudioSource.Stop();
        }
    }

    private void ChangingToRunningState()
    {
        bool runningHorizontaly = Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", runningHorizontaly);
    }

    //Rotates the sprite based on it's scale
    private void FlipSprite()
    {
        bool runningHorizontaly = Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;

        if(runningHorizontaly)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody2D.velocity.x),1f);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(hurtBox.position, attackRadius);
    }


}
