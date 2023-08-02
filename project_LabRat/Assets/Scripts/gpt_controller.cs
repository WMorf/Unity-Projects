using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gpt_controller : MonoBehaviour
{
    public float speed = 5f; // Movement speed of the character
    public CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private bool facingRight = true;
    public GameObject body;

    //Jump
    public float jumpForce = 5f; // Force applied when jumping
    public float gravity = 9.81f; // Gravity value

    void Start()
    {
        
    }

    void Update()
    {

        //Movement
            float moveZ = Input.GetAxis("Horizontal");

            moveDirection.z = -moveZ * speed;

            controller.Move(moveDirection * Time.deltaTime);

            // Rotate character if moving in the opposite direction
            if ((moveZ > 0 && !facingRight) || (moveZ < 0 && facingRight))
            {
                RotateCharacter();
            }

        //Jump
            // Apply gravity
            moveDirection.y -= gravity * Time.deltaTime;

            if (controller.isGrounded)
            {
                // Jump when the Jump key (e.g., spacebar) is pressed
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    moveDirection.y = jumpForce;
                }
            }
    }

    //Rotates character when moving opposite direction
    void RotateCharacter()
    {
        facingRight = !facingRight;
        body.transform.Rotate(Vector3.up, 180f);
    }
}

// To set up the script, follow these steps:

// Create an empty GameObject in your scene and attach a 3D character model to it.
// Add a Character Controller component to the GameObject by selecting it in the 
// Inspector and clicking on "Add Component" -> "Physics" -> "Character Controller."
// Attach the script above to the GameObject by dragging and dropping it onto the 
// Inspector window or using the "Add Component" button.
// Adjust the speed variable in the Inspector to control the movement speed of the character.
// This script captures the horizontal input axis 
// (typically left and right arrow keys or A and D keys) 
// and moves the character accordingly along the X-axis. The speed variable determines the character's movement speed.

// Note: This script assumes that your character is facing the positive X-axis direction. 
// If your character is facing a different direction, you may need to adjust the movement direction in the script accordingly.

// Remember to customize the script further based on your specific game requirements, such as implementing jumping or handling collisions.






