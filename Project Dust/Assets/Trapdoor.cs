using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : MonoBehaviour
{
    public GameObject pawn;
    public GameObject fakePawn;

    public float delay = 0.1f;

    private bool dumping = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!dumping)
            {
                StartCoroutine(Dump());
                dumping = true;
            }
        }
        else
        {
            if (dumping)
            {
                StopCoroutine(Dump());
                dumping = false;
            }
        }
    }

    private IEnumerator Dump()
    {
        while (true)
        {

            // Spawn the chosen prefab at the trapdoor position
            GameObject spawnedObject = Instantiate(pawn, transform.position, Quaternion.identity);

            // Adjust spawn rate by changing spawnInterval
            yield return new WaitForSeconds(delay);
        }
    }
}
