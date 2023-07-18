using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public int health;

    [Header("Boom Boom")]
    public bool shouldExplode;
    private bool ignite;
    public GameObject[] explosionBits;
    public int numberOfBitsMax,numberBitsMin;
    public float timeBetweenExplosions;
    private float explosionIntervalCounter;
    public float fuseTime;
    private float fuseCounter;
    public int numberOfExplosions;
    private int explosionCounter;


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

    void Start() 
    {
        fuseCounter = fuseTime;
        explosionIntervalCounter = timeBetweenExplosions;

    }

    void FixedUpdate()
    {
        if(shouldExplode)
        {
            fuseCounter -= Time.deltaTime;
            if(fuseCounter <= 0)
            {
                ignite = true;
                Explode();
                explosionCounter += 1;
            }

            if(ignite && explosionCounter < numberOfExplosions)
            {
                explosionIntervalCounter -= Time.deltaTime;
                if(explosionIntervalCounter <= timeBetweenExplosions)
                {
                    Explode();
                    explosionCounter += 1;
                    explosionIntervalCounter = timeBetweenExplosions;
                }
            }
        }


    }
}
