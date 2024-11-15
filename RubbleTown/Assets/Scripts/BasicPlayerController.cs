using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerController : MonoBehaviour
{
    // Player movement
    [SerializeField] float horizontalInput, verticalInput;
    public float movementSpeed;
    public float rotationSpeed;
    public BasicGun gunObject;

    public Transform bodyTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);

        if (Input.GetButtonDown("Fire1"))
        {
            gunObject.triggerDown = true;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            gunObject.triggerDown = false;
        }

    }

    public void RotateBody(float rotationY)
    {
        // Rotate the player's body around the Y-axis
        bodyTransform.localRotation = Quaternion.Euler(0f, rotationY, 0f);
    }
}
