using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEye : MonoBehaviour
{
    public BasicPlayerController playerController;

    public float rotationSpeed = 3f;
    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        // Lock the cursor to the center of the screen and make it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Calculate rotation
        rotationX -= mouseY * rotationSpeed;
        rotationY += mouseX * rotationSpeed;

        // Clamp the vertical rotation to prevent flipping
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // Apply rotation to the camera
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // Communicate with the player controller to rotate the body
        if (playerController != null)
        {
            playerController.RotateBody(rotationY);
        }
    }
    //public float rotationInput;
    //public float rotationSpeed = 3f;

    //void Start()
    //{

    //}

    //void Update()
    //{
    //    rotationInput = Input.GetAxis("Mouse X");
    //    transform.Rotate(Vector3.up * rotationInput * rotationSpeed);
    //}
}
