using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bPlant : MonoBehaviour
{

    public bPlantSource spawner;


    void Update()
    {
        if(transform.localScale.x <= .4f)
        {
            spawner.popCurrent--;
            GameObject.Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mob")
        {
            transform.localScale = new Vector3(transform.localScale.x - .1f, transform.localScale.y - .1f, transform.localScale.z - .1f);
            try 
            { 
                collision.gameObject.GetComponent<bMob>().rewardScore++;
                collision.gameObject.GetComponent<bMob>().maxLifeTime += 1f;
            }
            catch { };
        }
    }
}
