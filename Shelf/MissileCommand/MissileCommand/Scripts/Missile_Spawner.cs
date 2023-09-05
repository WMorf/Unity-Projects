using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile_Spawner : MonoBehaviour
{
    public GameObject missilePrefab;
    public Missile_GameManager manager;
    public float spawnInterval = 2f;

    private float timeSinceLastSpawn = 0f;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (manager.cityLocations.Count <=0)
        {
            //Debug.Log("No CIty");
        }
        else
        {
            if (timeSinceLastSpawn >= spawnInterval && manager.emissileCount <= manager.emissileMax)
        {
            // Reset spawn timer
            timeSinceLastSpawn = 0f;

            // Instantiate a new missile at a random position at the top of the screen
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;
            Vector3 spawnPosition = new Vector3(Random.Range(0f, screenWidth), screenHeight, 0f);
            spawnPosition = Camera.main.ScreenToWorldPoint(spawnPosition);
            spawnPosition.z = 0f;
            GameObject newMissile = Instantiate(missilePrefab, spawnPosition, Quaternion.identity);
            manager.emissileCount += 1;
        }
        }
        
    }
}