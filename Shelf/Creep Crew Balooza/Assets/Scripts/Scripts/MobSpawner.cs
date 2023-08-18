using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public static MobSpawner instance;

    public GameObject spawnPoint;
    public GameObject theBody;
    public GameObject mob, mobEffect;

    public bool shouldSpawn;
    public float spawnCount, spawnRate;
    public int spawnRangeMin, spawnRangeMax;

    public int currentPop, maxPop;

    public List<GameObject> pop = new List<GameObject>();


    private void Awake() 
    {
        instance = this;
    }

    void Start()
    {
        spawnCount = spawnRate;
    }

    void Update()
    {
        if(currentPop < maxPop)
        {
            spawnCount -= Time.deltaTime;
            
            if(spawnCount <= 0)
            {
                SpawnMob();
                currentPop++;
                spawnCount = spawnRate;
            }
        }

        //Debug
        if(Input.GetKey(KeyCode.T))
        {
            SpawnMob();
        }

        if(Input.GetKey(KeyCode.Y))
        {
            currentPop = 0;
        }
    }

    public void SpawnMob()
    {
        if(currentPop < maxPop)
        {
            int tempX = Random.Range(spawnRangeMin,spawnRangeMax);
            int tempY = Random.Range(spawnRangeMin,spawnRangeMax);

            /*In the future, sperate The Body from the spawn point with an ajustable Center constant.
            Allow for Orb Movement*/
            spawnPoint.transform.position = theBody.transform.position;
            spawnPoint.transform.position += new Vector3(tempX,tempY,0);
            Instantiate<GameObject>(mobEffect, spawnPoint.transform.position, transform.rotation);
            Instantiate<GameObject>(mob, spawnPoint.transform.position, transform.rotation);
            currentPop++;
        }
    }

    //add list and modify population accordingly with spawn delays and hard limits
}
