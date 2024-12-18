using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakables : MonoBehaviour
{
    public GameObject[] brokenPieces;
    public int maxPieces = 5;

    public bool shouldDropItems,shouldSmoke;
    public GameObject[] itemsToDrop;
    public float itemDropPercent;

    public bool leaveBase;
    public bool shouldShatterBits;
    public GameObject baseRemains,residue;
    
    public int breakSound;

    [Header("Boom Boom")]
    public bool shouldExplode;
    public GameObject[] explosionBits;
    public int numberOfBitsMax,numberBitsMin;
    public GameObject explosionDust;

    //private int shardRecolorCount;
    //public Color shardRecolor;


    // Start is called before the first frame update
    void Start()
    {
        /*
        for(int i = 0; i < shardRecolorCount; i++)
        {

        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Smash()
    {
        Destroy(gameObject);

        AudioManager.instance.PlaySFX(breakSound);

        if(shouldSmoke)
        {
            Instantiate(residue, transform.position, transform.rotation);
        }

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

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            //Addd isSlashing timer with attack time for bettter hit detection
            if(PlayerController.instance.dashCounter > 0)
            {   
                Smash();
            }
        }

        if(other.tag == "PlayerBullet" || other.tag == "MobBullet")
        {
            Smash();
        };
    }
    
}

