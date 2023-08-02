using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [Header("Stats")]
    public float speed = 7.5f;
    public float lifeTime = 10f;
    public Rigidbody theRB;
    public GameObject impactEffect;
    public GameObject trailDust;
    public float dustInterval;
    private float dustTime;
    public int health;

    [Header("Boom Boom")]
    public bool shouldExplode;
    public GameObject[] explosionBits;
    public int numberOfBitsMax,numberBitsMin;



    void Start() 
    {
        //transform.Rotate(0, 90, 0);
    }

    void FixedUpdate()
    {
        Move();

        lifeTime -= Time.deltaTime;
        dustTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            //Launch Explosives
            if (shouldExplode)
            {
                Explode();
            }
                    
            Destroy(gameObject);
        }

        if(dustTime <= 0)
        {
            Instantiate(trailDust, transform.position, transform.rotation);
            dustTime = dustInterval;
        }
    }

    private void Move()
    {
        theRB.velocity = transform.forward * speed;
    }

    private void Explode()
    {
        int boomBits = Random.Range(numberBitsMin, numberOfBitsMax);

        for (int i = 0; i < boomBits; i++)
        {
            int randomPiece = Random.Range(0, explosionBits.Length);

            Instantiate(explosionBits[randomPiece], transform.position, transform.rotation);
            //Debug.Log("Boom");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Instantiate(impactEffect, transform.position, transform.rotation);

        health = health - 2;

        if (health <= 0)
        {
            //Launch Explosives
            if (shouldExplode)
            {
                Explode();
            }

            Destroy(gameObject);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        Instantiate(impactEffect, transform.position, transform.rotation);

        health = health - 2;

        if (health <= 0)
        {
            //Launch Explosives
            if (shouldExplode)
            {
                Explode();
            }

            Destroy(gameObject);
        }
    }
}