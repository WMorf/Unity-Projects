using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cPlantSource : MonoBehaviour
{
    public float spawnInterval;
    public float spawnRange;
    public GameObject spawnObject;
    public bool shouldSpawn;

    public SpriteRenderer render;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPlant());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnPlant()
    {
        while (true)
        {
            if (shouldSpawn)
            {
                Vector3 spawnPoint = new Vector3(Random.Range(spawnRange, -spawnRange), Random.Range(spawnRange, -spawnRange), 0f);

                GameObject spawnedPlant = Instantiate(spawnObject, transform.position + spawnPoint, transform.rotation);
                spawnedPlant.GetComponent<cFood>().bodySprite.color = render.color;
                spawnedPlant.transform.parent = transform;
            }
            yield return new WaitForSeconds(spawnInterval);
        }

    }
}

