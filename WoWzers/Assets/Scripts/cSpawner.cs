using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cSpawner : MonoBehaviour
{
    //[Header("")]
    //[Tooltip("")]

    [Header("Components")]
        public SpriteRenderer nestSprite;
        public GameObject mob;
        //public List<GameObject> spawnedMobs;

    [Header("Stats")]
        public bool shouldSpawn;
        public Color spawnColor;
        public float spawnDelay;
        public float spawnRange;
        public float deadTime, deadTimeThreshold;
        public int popMax, popCurrent;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = spawnColor;
        StartCoroutine(Spawn());
    }

    void Update()
    {
        //if (popCurrent < popMax)
        //{
        //    StartCoroutine(Spawn());
        //}

        if (popCurrent <= 0)
        {
            deadTime += Time.deltaTime;
        }
        if (deadTime >= deadTimeThreshold)
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
                Vector3 spawnPoint = new Vector3(Random.Range(spawnRange, -spawnRange), Random.Range(spawnRange, -spawnRange), 0f);

                GameObject spawnedMob = Instantiate(mob, transform.position + spawnPoint, transform.rotation);

                spawnedMob.GetComponent<cMobInfo>().nest = gameObject;
                spawnedMob.GetComponentInChildren<SpriteRenderer>().color = spawnColor;
                popCurrent++;

                yield return new WaitForSeconds(spawnDelay);
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
