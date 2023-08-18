using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakables : MonoBehaviour
{
    public GameObject[] brokenPieces;
    public int maxPieces = 5;

    public int health;

    public bool shouldDropItems,shouldSmoke;
    public GameObject[] itemsToDrop;
    public float itemDropPercent;

    public bool leaveBase;
    public bool shouldShatterBits;
    public GameObject baseRemains,smoke;

    public string collisionTag;

    [Header("Boom Boom")]
    public bool shouldExplode;
    public GameObject[] explosionBits;
    public int numberOfBitsMax,numberBitsMin;
    public GameObject explosionDust;
    private Vector3 hitDir;
    private Quaternion hitRot;

    //private int shardRecolorCount;
    //public Color shardRecolor;


    void Start()
    {

    }

    void FixedUpdate()
    {
        if(health <= 0)
        {
            Smash();
        }
    }

    public void Smash()
    {
        Destroy(gameObject);


        if(shouldSmoke)
        {
            Instantiate(smoke, transform.position, transform.rotation);
        }

        //Launch Explosives
        if(shouldExplode)
        {
        
            Instantiate(explosionDust, hitDir, hitRot);
                    
            int boomBits = Random.Range(numberBitsMin, numberOfBitsMax);

            for(int i = 0; i < boomBits; i++)
            {
                int randomPiece = Random.Range(0, explosionBits.Length);

                Instantiate(explosionBits[randomPiece], transform.position, transform.rotation);
            }

        }

        //show broken pieces
        if(shouldShatterBits)
        {
            shouldShatterBits = false;
                    
            int piecesToDrop = Random.Range(1, maxPieces);

            for(int i = 0; i < piecesToDrop; i++)
            {
                int randomPiece = Random.Range(0, brokenPieces.Length);

                Instantiate(brokenPieces[randomPiece], transform.position, transform.rotation);
            }
        }

        //leave behind remains
        if(leaveBase)
        {
            Instantiate(baseRemains, transform.position, transform.rotation);
            leaveBase = false;
        }

        //drop items
        if(shouldDropItems)
        {
            shouldDropItems = false;
            
            float dropRoll = Random.Range(0f, 100f);

            if(dropRoll < itemDropPercent)
            {
                int randomItem = Random.Range(0, itemsToDrop.Length);

                Instantiate(itemsToDrop[randomItem], transform.position, transform.rotation);
            }

        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == collisionTag)
        {
            health -= 1;
            
            hitDir = other.contacts[0].point - transform.position;
            hitRot = other.transform.rotation;
        }
    }

    private void OnCollisionStay(Collision other) 
    {
        if(other.gameObject.tag == collisionTag)
        {
            health -= 1;
        }
    }
    
}

