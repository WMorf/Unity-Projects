using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bPopManager : MonoBehaviour
{

    public List<GameObject> spawners;
    public List<bSpawner> spawnersScripts;


    void Awake()
    {
        foreach (GameObject spawner in spawners)
        {
            spawnersScripts.Add(spawner.GetComponent<bSpawner>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
