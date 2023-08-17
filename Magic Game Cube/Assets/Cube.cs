using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    //int numberOfTimes = 5;
    //string nameOfTheKey = "Enter";
    //float speedOfBreaking = 6.94f;


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hello everyone I'm printing from Debug");

        //Debug.Log("Press the up arrow to jump");
        //Debug.Log("Press the right arrow" + numberOfTimes + " to move!");

        //Debug.LogWarning("Press " + nameOfTheKey + " to do nothing");
        //Debug.LogError("If you smash the keyboard at a speed of " + speedOfBreaking + " KPH, nothing happens, you just cry");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            print("Up Arrow key was pressed");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            print("Down Arrow key was pressed");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            print("Left Arrow key was pressed");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            print("Right Arrow key was pressed");
        }
    }
}
