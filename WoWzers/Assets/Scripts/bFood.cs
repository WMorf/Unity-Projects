using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bFood : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

        if(transform.localScale.x <= .4f)
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mob")
        {
            transform.localScale = new Vector3(transform.localScale.x - .1f, transform.localScale.y - .1f, transform.localScale.z - .1f);
            try { collision.gameObject.GetComponent<bMob>().rewardScore++; }
            catch { };
        }
    }
}
