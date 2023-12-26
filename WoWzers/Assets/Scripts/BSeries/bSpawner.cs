using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bSpawner : MonoBehaviour
{
    public bSpawnCheck SpawnCheck;
    public bPopManager PopManager;
    public GameObject N, S, E, W;
    public GameObject mob;
    public List<GameObject> spawnedMobs;
    public int popMax, popCurrent;
    public float spawnDelay = 1f;
    public bool shouldSpawn;
    public Color spawnColor;
    public SpriteRenderer nestSprite;
    public bool ifSpawnCheck;

    public float deadTime, deadTimeThreshold;
    //if (ifSpawnCheck){ }

    private void Awake()
    {
        if (ifSpawnCheck){ SpawnCheck = FindAnyObjectByType(typeof(Canvas)).GetComponent<bSpawnCheck>(); } 
        PopManager = FindAnyObjectByType<bPopManager>();
        PopManager.mobSpawners.Add(gameObject);
        StartCoroutine(Spawn());
        GetComponent<SpriteRenderer>().color = spawnColor;
    }

    // Update is called once per frame
    void Update()
    {
        //if (popCurrent < popMax)
        //{
        //    StartCoroutine(Spawn());
        //}

        if(popCurrent <= 0)
        {
            deadTime += Time.deltaTime;
        }
        if(deadTime >= deadTimeThreshold)
        {
            Debug.Log(gameObject.name + " has withered away");
            Destroy(gameObject);
        }
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            if (popCurrent < popMax && shouldSpawn)
            {
                int rand = Random.Range(1, 4);

                if (rand == 1)
                {
                    if (SpawnCheck.pointN == 0)
                    {
                        GameObject spawnedMob = Instantiate(mob, N.transform.position, transform.rotation);
                        spawnedMob.GetComponent<bMob>().spawner = this;
                        spawnedMob.GetComponentInChildren<SpriteRenderer>().color = spawnColor;
                        nestSprite.color = spawnColor;
                        popCurrent++;
                        if (ifSpawnCheck) { SpawnCheck.spawnCount++; }

                    }
                }
                if (rand == 2)
                {
                    if (SpawnCheck.pointS == 0)
                    {
                        GameObject spawnedMob = Instantiate(mob, S.transform.position, transform.rotation);
                        spawnedMob.GetComponent<bMob>().spawner = this;
                        spawnedMob.GetComponentInChildren<SpriteRenderer>().color = spawnColor;
                        popCurrent++;
                        if (ifSpawnCheck) { SpawnCheck.spawnCount++; }
                    }
                }
                if (rand == 3)
                {
                    if (SpawnCheck.pointE == 0)
                    {
                        GameObject spawnedMob = Instantiate(mob, E.transform.position, transform.rotation);
                        spawnedMob.GetComponent<bMob>().spawner = this;
                        spawnedMob.GetComponentInChildren<SpriteRenderer>().color = spawnColor;
                        popCurrent++;
                        if (ifSpawnCheck) { SpawnCheck.spawnCount++; }
                    }
                }
                if (rand == 4)
                {
                    if (SpawnCheck.pointW == 0)
                    {
                        GameObject spawnedMob = Instantiate(mob, W.transform.position, transform.rotation);
                        spawnedMob.GetComponent<bMob>().spawner = this;
                        spawnedMob.GetComponentInChildren<SpriteRenderer>().color = spawnColor;
                        popCurrent++;
                        if (ifSpawnCheck) { SpawnCheck.spawnCount++; }
                    }
                }
                yield return new WaitForSeconds(spawnDelay);
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
