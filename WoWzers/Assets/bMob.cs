using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bMob : MonoBehaviour
{
    // Rigidbody2D component reference
    private Rigidbody2D rb;

    // Movement speed
    public float speed = 5f;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Apply a random direction every frame
        Vector2 newDirection = Random.insideUnitCircle;
        rb.velocity = newDirection * speed;
    }
}