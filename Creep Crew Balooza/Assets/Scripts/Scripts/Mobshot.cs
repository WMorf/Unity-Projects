using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobshot : MonoBehaviour
{
    public float speed;
    private Vector3 direction;
    public float dustCount, dustMax = 1f;
    public bool shouldTrail;
    public GameObject trailDust;
    public GameObject impactEffect;

    [Header("Boom Boom")]
    public bool shouldExplode;
    public GameObject[] explosionBits;
    public int numberOfBitsMax,numberBitsMin;
    public int damageToGive = 5;
    public GameObject explosionDust;

    // Start is called before the first frame update
    void Start()
    {
        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
        dustCount = dustMax;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += direction * speed * Time.fixedDeltaTime;
        if(shouldTrail && dustCount <= 0)
            {
                Instantiate(trailDust, transform.position, transform.rotation);

                dustCount = dustMax;
            }else
            {
                dustCount -= Time.fixedDeltaTime;
            }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Instantiate(impactEffect, transform.position, transform.rotation);

         //Launch Explosives
        if(shouldExplode)
        {
        
            Instantiate(explosionDust,transform.position,transform.rotation);
                    
            int boomBits = Random.Range(numberBitsMin, numberOfBitsMax);

            for(int i = 0; i < boomBits; i++)
            {
                int randomPiece = Random.Range(0, explosionBits.Length);

                Instantiate(explosionBits[randomPiece], transform.position, transform.rotation);
            }

        }

        if(other.tag == "Player")
        {
                HealthManager.instance.DamagePlayer(); 
        }

        Destroy(gameObject);

    }

    private void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }

}
