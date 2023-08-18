using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;       // Reference to the player's Transform component
    public float smoothSpeed = 0.125f;   // Smoothing factor for camera movement

    private Vector3 offset;        // Distance between the camera and player

    private void Start()
    {
        
        player = GameObject.Find("Player"); // Grabbed on start to work with level load

        offset = transform.position - player.transform.position;
        
    }

    private void Update()
    {
        // Calculate the target position for the camera to follow the player smoothly
        Vector3 targetPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // Point the camera at the player
        transform.LookAt(player.transform);

    }
}