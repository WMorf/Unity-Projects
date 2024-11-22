using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGenerated_Destroy : MonoBehaviour
{
    public float hitPoints = 100f;
    public GameObject gibPrefab;
    public GameObject lootPrefab;

    // Update is called once per frame
    void Update()
    {

    }

    public void ReceiveDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (gibPrefab != null)
        {
            Instantiate(gibPrefab, transform.position, transform.rotation);
        }

        if (lootPrefab != null)
        {
            Instantiate(lootPrefab, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
}
