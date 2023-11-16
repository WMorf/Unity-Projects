using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bSpawner : MonoBehaviour
{
    public bSpawnCheck SpawnCheck;
    public GameObject N, S, E, W;
    public GameObject mob;

    // Update is called once per frame
    void Update()
    {
        int rand = Random.Range(1, 4);

        if (rand == 1)
        {
            if (SpawnCheck.pointN == 0)
            {
                Instantiate(mob, N.transform.position, transform.rotation);
                SpawnCheck.spawnCount++;
            }
        }
        if (rand == 2)
        {
            if (SpawnCheck.pointS == 0)
            {
                Instantiate(mob, S.transform.position, transform.rotation);
                SpawnCheck.spawnCount++;
            }
        }
        if (rand == 3)
        {
            if (SpawnCheck.pointE == 0)
            {
                Instantiate(mob, E.transform.position, transform.rotation);
                SpawnCheck.spawnCount++;
            }
        }
        if (rand == 4)
        {
            if (SpawnCheck.pointW == 0)
            {
                Instantiate(mob, W.transform.position, transform.rotation);
                SpawnCheck.spawnCount++;
            }
        }

    }
}
