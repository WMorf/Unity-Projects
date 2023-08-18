using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount =1;

    public float waitToBeCollected = .5f;

    public GameObject healEffect;
    public int pickupSound;

    void Start()
    {
        
    }

    void Update()
    {
        if(waitToBeCollected > 0)
        {
            waitToBeCollected -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && waitToBeCollected <= 0)
        {

            Instantiate(healEffect, transform.position, transform.rotation);

            AudioManager.instance.PlaySFX(pickupSound);

            HealthManager.instance.HealPlayer(healAmount);

            Destroy(gameObject);
        }
    }
}
