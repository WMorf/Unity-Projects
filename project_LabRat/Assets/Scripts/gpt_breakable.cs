using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gpt_breakable : MonoBehaviour
{
    public string destructibleTag = "Player"; // This is the tag that you will set in the editor.
    public GameObject chunkPrefab; // This is the prefab that will be spawned when the object is destroyed.
    public int numberOfChunks = 10; // Number of chunks to spawn
    public float explosionForce = 1.0f; // Explosion force to apply to chunks

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(destructibleTag))
        {
            Destroy(gameObject);

            for (int i = 0; i < numberOfChunks; i++)
            {
                // Spawn chunks at object's position
                var chunk = Instantiate(chunkPrefab, transform.position, Quaternion.identity);
                var rb = chunk.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    // Apply a force to make chunks fly off in different directions
                    rb.AddExplosionForce(explosionForce, transform.position, 1.0f);
                }
            }
        }
    }
}