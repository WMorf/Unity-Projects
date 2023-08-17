using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Rigidbody2D myRigidBody2d;

    int numberOfTimes = 5;
    string nameOfTheKey = "Enter";
    float speedOfBreaking = 6.94f;


    void Start()
    {
        //PrintingToOurConsole();
    }

    void Update()
    {
        MovingOurCube();
        OutOfBoundsPrinter();
    }

    public string PrintingFromOutside(int value)
    {
        //Debug.Log("Hello frm the other side");
        string printingSomething = "The value we were sent is " + value;
        return printingSomething;

    }

    private void OutOfBoundsPrinter()
    {
        if (transform.position.x > 9.2)
        {
            Debug.LogWarning("Our Cube is out of bounds to the Right side!");
        }

        if (transform.position.x < -9.2)
        {
            Debug.LogWarning("Our Cube is out of bounds to the Left side!");
        }

        if (transform.position.y > 5.2)
        {
            Debug.LogWarning("Our Cube is out of bounds to the Top side!");
        }

        if (transform.position.y < -4.2)
        {
            Debug.LogWarning("Our Cube is out of bounds to the Bottom side!");
        }
    }

    private void MovingOurCube()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            myRigidBody2d.velocity = new Vector2(0f, 10f);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            myRigidBody2d.velocity = new Vector2(0f, -10f);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            myRigidBody2d.velocity = new Vector2(-10f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            myRigidBody2d.velocity = new Vector2(10f, 0f);
        }
    }

    private void PrintingToOurConsole()
    {
        Debug.Log("Hello everyone I'm printing from Debug");

        Debug.Log("Press the up arrow to jump");
        Debug.Log("Press the right arrow" + numberOfTimes + " to move!");

        Debug.LogWarning("Press " + nameOfTheKey + " to do nothing");
        Debug.LogError("If you smash the keyboard at a speed of " + speedOfBreaking + " KPH, nothing happens, you just cry");
    }
}
