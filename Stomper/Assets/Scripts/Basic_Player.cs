using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Player : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody rb;
    //public int rewardScore { get; set; }

    public GameObject firePoint;
    public GameObject shotPrefab;
    public float shotSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        rb.velocity = movement * speed;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shot = Instantiate(shotPrefab, firePoint.transform.position, firePoint.transform.rotation);
            Rigidbody rb = shot.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = transform.forward * shotSpeed;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject mob = collision.gameObject;
        if (mob.tag == "Mob")
        {
            //this.rewardScore += mob.GetComponent<bMob>().rewardScore + mob.GetComponent<bMob>().baseReward;
            //print(this.rewardScore);
            Destroy(collision.gameObject);
        }
    }


}
