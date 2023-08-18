using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Character movement speed

    // Update is called once per frame
    void Update()
    {
        // Get horizontal and vertical inputs (WASD or arrow keys)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction based on inputs
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Move the character based on the movement direction
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);

        // Rotate the character towards the movement direction (optional)
        if (movementDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movementDirection);
        }
    }
}