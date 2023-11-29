using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bPopManager : MonoBehaviour
{

    public List<GameObject> mobSpawners,plantSpawners;
    public List<bSpawner> spawnersScripts;
    public List<bPlantSource> plantScripts;

    public float checkDelay;

    public int plantMax, plantCurrent, plantTemp;
    public int mobMax, mobCurrent, mobTemp;


    void Awake()
    {
        StartCoroutine(GetSpawners());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetSpawners()
    {
        while(true) 
        {
            spawnersScripts.Clear();
            plantScripts.Clear();

            foreach (GameObject spawner in mobSpawners)
            {
                mobTemp += spawner.GetComponent<bSpawner>().popCurrent;
                //spawnersScripts.Add(spawner.GetComponent<bSpawner>());
            }
            foreach (GameObject spawner in plantSpawners)
            {
                bPlantSource i = spawner.GetComponent<bPlantSource>();
                plantScripts.Add(i);
                plantTemp += i.popCurrent;
            }

            if (mobCurrent >= mobMax)
            {
                foreach (bSpawner spawner in spawnersScripts)
                {
                    spawner.shouldSpawn = false;
                }
            }
            else
            {
                foreach (bSpawner spawner in spawnersScripts)
                {
                    spawner.shouldSpawn = true;
                }
            }

            if (plantCurrent >= plantMax)
            {
                foreach (bPlantSource spawner in plantScripts)
                {
                    spawner.shouldSpawn = false;
                }
            }
            else
            {
                foreach (bPlantSource spawner in plantScripts)
                {
                    spawner.shouldSpawn = true;
                }
            }

            string message = string.Format("Checking For Spawners\n {0} PlantSpawners found - {1} Plants, {2} MobSpawners - {3} - Mobs", plantSpawners.Count, plantCurrent, mobSpawners.Count, mobCurrent);
            Debug.Log(message);

            mobCurrent = mobTemp;
            plantCurrent = plantTemp;
            mobTemp = 0;
            plantTemp = 0;

            yield return new WaitForSeconds(checkDelay);
        }
    }
}
