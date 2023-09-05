using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile_Turret : MonoBehaviour
{
    public GameObject missilePrefab;
    public GameObject firepoint;

    public Missile_GameManager manager;

    public float missileSpeed = 10f;

    public Vector3 targetPosition;

    public float spawnInterval = .75f;

    private float timeSinceLastSpawn = 0f;

    void Update()
    {
        // Check for mouse click and set target position
        if (Input.GetMouseButtonDown(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0f;
        }

        // Rotate the turret to face the target
        Vector3 targetDir = targetPosition - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        timeSinceLastSpawn += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
            {
                if (timeSinceLastSpawn >= spawnInterval)
                {
                    // Reset spawn timer
                    timeSinceLastSpawn = 0f;
            
                    if(manager.missileCount < manager.missileMax)
                    {
                        // Fire missile when mouse button is pressed
                        GameObject lastMissle = Instantiate(missilePrefab, firepoint.transform.position, firepoint.transform.rotation);
                        manager.missileCount += 1;
                    }


                }

        }

    }
}