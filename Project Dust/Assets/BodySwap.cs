using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySwap : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject[] bodies;

    // Start is called before the first frame update
    void Start()
    {
        GameObject body = Instantiate(bodies[Random.Range(0, bodies.Length)], spawnPoint.transform);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    Destroy(body)
        //    render.sprite = faceOptions[Random.Range(0, faceOptions.Length)];
        //}
    }
}
