using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile_Explosive : MonoBehaviour
{

    public GameObject explosionPrefab;


    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
