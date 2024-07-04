using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class convoyMotor : MonoBehaviour
{

    // components
    public Rigidbody rb;
    public Animator anim;
    public SpriteRenderer frontRender,midRender,backRender;
    public ParticleSystem particleA,particleB;




    public Sprite[] crowdOptions;
    public GameObject emotePoint;
    public GameObject[] emotes;

    public float speed;
    public Vector3 movementDirection;

    //controls direction
    public int moveSwitch;

    //Movement change
    public float moveCount, movethreshold;



    

    // Start is called before the first frame update
    void Start()
    {
        frontRender.sprite = crowdOptions[Random.Range(0,crowdOptions.Length)];
        midRender.sprite = crowdOptions[Random.Range(0, crowdOptions.Length)];
        backRender.sprite = crowdOptions[Random.Range(0, crowdOptions.Length)];

        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        moveCount += Time.deltaTime;
        if (moveCount > movethreshold) 
        {
            ChangeDirection();
        }

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            frontRender.sprite = crowdOptions[Random.Range(0, crowdOptions.Length)];
            midRender.sprite = crowdOptions[Random.Range(0, crowdOptions.Length)];
            backRender.sprite = crowdOptions[Random.Range(0, crowdOptions.Length)];
        }


        transform.position += movementDirection * speed * Time.deltaTime; 
    }

    public void Emote(int emote)
    {
        switch (emote)
        {
            case 1:
                Instantiate(emotes[1], emotePoint.transform);
                break; 
            
            case 2:

                break;

            default: 
                
                break;
        }
    }

    public void ChangeDirection()
    {

        moveCount = 0;
        moveSwitch = Random.Range(0, 5);

        if (moveSwitch < 5 ) 
        {
            particleA.Play();
            particleB.Play();
            anim.SetBool("isMoving", true);
        }
        else
        {
            particleA.Stop();
            particleB.Stop();
            anim.SetBool("isMoving", false);
        }

        switch (moveSwitch)
        {
            case 1:

                movementDirection = new Vector3(0, 0, 1);
;
                break;

            case 2:

                movementDirection = new Vector3(0, 0, -1);

                break;

            case 3:

                movementDirection = new Vector3(1, 0, 0);

                break;

            case 4:

                movementDirection = new Vector3(-1, 0, 0);

                break;

            default:

                movementDirection = new Vector3(0, 0, 0);
                print(moveSwitch);

                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Crowd")
        {
            movementDirection = new Vector3(0, 0, 0);
            anim.SetBool("isMoving", false);
            Emote(1);
            particleA.Stop();
            particleB.Stop();
            moveCount = 0;
        }
        else
        {
            ChangeDirection();
        }
            
    }
}
