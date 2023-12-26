using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cSpawner : MonoBehaviour
{
    //public GameObject mob;
    //public List<GameObject> spawnedMobs;
    //public int popMax, popCurrent;
    //public float spawnDelay = 1f;
    //public bool shouldSpawn;
    //public Color spawnColor;
    //public SpriteRenderer nestSprite;

    //public float deadTime, deadTimeThreshold;

    //private void Awake()
    //{
    //    StartCoroutine(Spawn());
    //    GetComponent<SpriteRenderer>().color = spawnColor;
    //}

    //void Update()
    //{

    //    if (popCurrent <= 0)
    //    {
    //        deadTime += Time.deltaTime;
    //    }
    //    if (deadTime >= deadTimeThreshold)
    //    {
    //        Debug.Log(gameObject.name + " has withered away");
    //        Destroy(gameObject);
    //    }
    //}

    //IEnumerator Spawn()
    //{
    //    while (true)
    //    {
    //        if (popCurrent < popMax && shouldSpawn)
    //        {
    //            GameObject spawnedMob = Instantiate(mob, transform.position, transform.rotation);
    //            spawnedMob.GetComponent<cMobInfo>().spawner = this;
    //            spawnedMob.GetComponentInChildren<SpriteRenderer>().color = spawnColor;
    //            nestSprite.color = spawnColor;
    //            popCurrent++;
    //        }
    //            yield return new WaitForSeconds(spawnDelay);
    //        }
    //        yield return new WaitForSeconds(spawnDelay);
    //    }
    //}
}
