using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Player : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    //public int rewardScore { get; set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        rb.velocity = movement * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
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
