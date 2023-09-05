using System.Collections.Generic;
using UnityEngine;

public class Missile_Enemy : MonoBehaviour
{
    public float speed = 5f;

    public GameObject explosionPrefab;

    private Vector3 targetPosition;

    void Start()
    {
        // Get the array of city locations from the GameManager
        List<Vector3> cityLocations = Missile_GameManager.Instance.cityLocations;


        // Set the target position to a random city location
        targetPosition = cityLocations[Random.Range(0, cityLocations.Count)];
    }

    private void Explode()
    {
        // Instantiate an explosion effect at the missile's position
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        // Destroy the missile
        Destroy(gameObject);
    }

    void Update()
    {
        // Move the missile towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Rotate the missile towards its move direction
        if (transform.position != targetPosition)
        {
            transform.LookAt(targetPosition);
        }

        // Destroy the missile if it reaches the target position
        if (transform.position == targetPosition)
        {
            Explode();
        }
    }
}