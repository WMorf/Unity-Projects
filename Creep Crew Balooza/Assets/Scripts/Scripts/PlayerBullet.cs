using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 7.5f;
    public Rigidbody2D theRB;
    public GameObject impactEffect;
    public GameObject impactEffectSkelly;
    public GameObject trailDust;
    public int distanceCounter,DistanceMax;

    public int health;

    [Header("Boom Boom")]
    public bool shouldExplode;
    public GameObject[] explosionBits;
    public int numberOfBitsMax,numberBitsMin;
    public int damageToGive = 5;
    public GameObject explosionDust;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        theRB.velocity = transform.right * speed;
        Instantiate(trailDust, transform.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        AudioManager.instance.PlaySFX(4);

        health = health - 1;

        if (health <= 0)
        {

            //Launch Explosives
            if (shouldExplode)
            {

                Instantiate(explosionDust, transform.position, transform.rotation);

                int boomBits = Random.Range(numberBitsMin, numberOfBitsMax);

                for (int i = 0; i < boomBits; i++)
                {
                    int randomPiece = Random.Range(0, explosionBits.Length);

                    Instantiate(explosionBits[randomPiece], transform.position, transform.rotation);
                }

            }

            Destroy(gameObject);

        }

        if(other.tag == "Mob" || other.tag == "Mob2")
        {
            Instantiate(impactEffectSkelly, transform.position, transform.rotation);
            other.GetComponent<EnemyController>().damageEnemy(damageToGive);
        }
        
        if(other.tag == "Player")
        {
            HealthManager.instance.DamagePlayer(); 
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
