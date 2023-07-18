using UnityEngine;

public class RotateGun : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Get the mouse position on the screen
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane; // Set the Z distance from the camera to the object

        // Convert the mouse position from screen space to world space
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculate the direction from the object's position to the mouse position
        Vector3 directionToMouse = worldMousePosition - transform.position;

        // Rotate the object to face the mouse position
        transform.forward = directionToMouse.normalized;
    }
}