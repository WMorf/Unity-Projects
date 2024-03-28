using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cFood : MonoBehaviour
{
    public bool shouldGrow;
    public float growRate;
    public int reward;
    public float lifeReward;
    public float rotTime;
    public float maxLifeTime;
    public SpriteRenderer bodySprite;
    public SpriteRenderer rotRender;

    [Header("Runtime")]
    public float lifeTime;
    public bool rotten;

    void Update()
    {
        lifeTime += Time.deltaTime;

        //Grow over time 
        if (transform.localScale.x <= 1f && shouldGrow)
        {
            transform.localScale = new Vector3(transform.localScale.x + growRate, transform.localScale.y + growRate, transform.localScale.z + growRate);
        }
        if (transform.localScale.x <= .2f || lifeTime >= maxLifeTime)
        {
            GameObject.Destroy(gameObject);
        }

        if (!rotten && lifeTime >= rotTime)
        {
            rotten = true;
            rotRender.enabled = true;
            //bodySprite.enabled = false;
            shouldGrow = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mob" && !collision.gameObject.GetComponent<cMobInfo>().eatRotten)
        {
            if (!rotten)
            {
                transform.localScale = new Vector3(transform.localScale.x - .1f, transform.localScale.y - .1f, transform.localScale.z - .1f);
                if (shouldGrow) { shouldGrow = false; } //half eaten food won't grow again.
                try
                {
                    collision.gameObject.GetComponent<cMobInfo>().rewardScore += reward;
                    collision.gameObject.GetComponent<cMobInfo>().maxLifeTime += lifeReward;
                }
                catch { };
            }

            if (collision.gameObject.GetComponent<cMobInfo>().eatRotten) //Allows carrion/bottom feeders to clean up corpses
            {
                transform.localScale = new Vector3(transform.localScale.x - .1f, transform.localScale.y - .1f, transform.localScale.z - .1f);
                if (shouldGrow) { shouldGrow = false; } //half eaten food won't grow again.
                try
                {
                    collision.gameObject.GetComponent<cMobInfo>().rewardScore += reward;
                    collision.gameObject.GetComponent<cMobInfo>().maxLifeTime += lifeReward;
                }
                catch { };
            }

        }
    }
}
