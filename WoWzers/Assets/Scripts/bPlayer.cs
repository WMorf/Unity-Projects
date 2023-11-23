using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bPlayer : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;

    void

    Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void

    Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        rb.velocity = movement * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mob")
        {
            Destroy(collision.gameObject);
        }
    }
}
