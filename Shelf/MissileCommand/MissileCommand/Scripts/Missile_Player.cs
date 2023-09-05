using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile_Player : MonoBehaviour
{
    public float speed = 10.0f;         // The speed of the missile
    public float rotateSpeed = 360.0f;  // The speed of the missile's rotation

    private Vector3 moveDirection;      // The direction the missile is moving in

    private Missile_Turret turret;
    private Vector3 target;
    public GameObject explosionPrefab;

    private void Explode()
    {
        // Instantiate an explosion effect at the missile's position
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        // Destroy the missile
        Destroy(gameObject);
    }

    void Start()
    {
        // Set the move direction to be the forward direction of the missile
        moveDirection = transform.forward;
        turret = FindObjectOfType<Missile_Turret>();
        target = turret.targetPosition;
    }

    void Update()
    {
        // Move the missile in the direction it is facing
        transform.position += moveDirection * speed * Time.deltaTime;

        // Destroy the missile if it reaches the target position
        if (Vector3.Distance(transform.position, target) < .1f)
        {
            Explode();
        }

    }


    }
