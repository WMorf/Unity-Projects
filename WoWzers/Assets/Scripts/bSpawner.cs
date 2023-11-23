using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bSpawner : MonoBehaviour
{
    public bSpawnCheck SpawnCheck;
    public GameObject N, S, E, W;
    public GameObject mob;
    public List<GameObject> spawnedMobs;
    public int popMax, popCurrent;

    private void Awake()
    {
        SpawnCheck = FindAnyObjectByType(typeof(Canvas)).GetComponent<bSpawnCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnMob();
    }

    private void SpawnMob()
    {
        if (popCurrent < popMax)
        {
            int rand = Random.Range(1, 4);

            if (rand == 1)
            {
                if (SpawnCheck.pointN == 0)
                {
                    GameObject spawnedMob = Instantiate(mob, N.transform.position, transform.rotation);
                    spawnedMob.GetComponent<bMob>().spawner = this;
                    popCurrent++;
                    SpawnCheck.spawnCount++;
                }
            }
            if (rand == 2)
            {
                if (SpawnCheck.pointS == 0)
                {
                    GameObject spawnedMob = Instantiate(mob, S.transform.position, transform.rotation);
                    spawnedMob.GetComponent<bMob>().spawner = this;
                    popCurrent++;
                    SpawnCheck.spawnCount++;
                }
            }
            if (rand == 3)
            {
                if (SpawnCheck.pointE == 0)
                {
                    GameObject spawnedMob = Instantiate(mob, E.transform.position, transform.rotation);
                    spawnedMob.GetComponent<bMob>().spawner = this;
                    popCurrent++;
                    SpawnCheck.spawnCount++;
                }
            }
            if (rand == 4)
            {
                if (SpawnCheck.pointW == 0)
                {
                    GameObject spawnedMob = Instantiate(mob, W.transform.position, transform.rotation);
                    spawnedMob.GetComponent<bMob>().spawner = this;
                    popCurrent++;
                    SpawnCheck.spawnCount++;
                }
            }
        }
    }
}
