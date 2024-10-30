using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGenerated_Bullet : MonoBehaviour
{
    public GameObject impactDecalPrefab; // Prefab for the impact decal
    public GameObject particleEmitterPrefab; // Prefab for the particle emitter

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall") )
        {
            // Spawn impact decal at the collision point
            SpawnImpactDecal(collision.contacts[0].point, collision.contacts[0].normal, collision);

            // Spawn particle emitter for smoke and debris
            SpawnParticleEmitter(collision.contacts[0].point, collision.contacts[0].normal);
        }


        // Destroy the bullet
        Destroy(gameObject);
    }

    private void SpawnImpactDecal(Vector3 position, Vector3 normal, Collision collision)
    {
        // Spawn impact decal at the collision point with proper rotation
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, normal);
        GameObject impactDecal = Instantiate(impactDecalPrefab, position, rotation);

        // Ensure the impact decal always appears slightly above the surface
        impactDecal.transform.Translate(Vector3.up * 0.01f, Space.Self);

        // Attach the decal to the hit object
        impactDecal.transform.SetParent(collision.gameObject.transform, true);
    }


    private void SpawnParticleEmitter(Vector3 position, Vector3 normal)
    {
        // Spawn particle emitter at the collision point with proper rotation
        Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, normal);
        Instantiate(particleEmitterPrefab, position, rotation);
    }
}
