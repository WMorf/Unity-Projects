using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class convoyMotor : MonoBehaviour
{

    // components
    public Rigidbody rb;
    public Animator anim;


    public float speed;
    public Vector3 movementDirection;

    //controls direction
    public int moveSwitch;

    //Movement change
    public float moveCount, movethreshold;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveCount += Time.deltaTime;
        if (moveCount > movethreshold) 
        {
            ChangeDirection();
        }

        transform.position += movementDirection * speed * Time.deltaTime; 
    }

    public void ChangeDirection()
    {

        moveCount = 0;
        moveSwitch = Random.Range(0, 8);

        if (moveSwitch > 5 ) 
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
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
}
