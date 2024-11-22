using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiGenerated_EnemeySmart : MonoBehaviour
{
    public enum State { Wander, Pursue, Attack }
    public State currentState = State.Wander;

    public float wanderSpeed = 3f;
    public float pursueSpeed = 5f;
    public float wanderRadius = 20f;
    public float detectionRange = 15f;
    public float firingRange = 10f;
    public float hitscanInterval = 2f; // Time interval for hitscan

    public GameObject projectilePrefab; // Projectile to shoot at target
    public Transform firePoint; // Point where the projectile is fired from
    public float fireRate = 1f; // Delay between shots

    public string targetTag = "Player"; // Tag of the target to pursue and attack

    private Transform target;
    private Vector3 wanderTarget;
    private float fireTimer = 0f;
    private float hitscanTimer = 0f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag).transform; // Make sure target has the specified tag
        SetRandomWanderTarget();
        StartCoroutine(StateMachine());
    }

    IEnumerator StateMachine()
    {
        while (true)
        {
            switch (currentState)
            {
                case State.Wander:
                    Wander();
                    break;
                case State.Pursue:
                    Pursue();
                    break;
                case State.Attack:
                    Attack();
                    break;
            }
            yield return null;
        }
    }

    void Wander()
    {
        // Move towards wander target
        transform.position = Vector3.MoveTowards(transform.position, wanderTarget, wanderSpeed * Time.deltaTime);

        // If close to the wander target, pick a new one
        if (Vector3.Distance(transform.position, wanderTarget) < 1f)
        {
            SetRandomWanderTarget();
        }

        // Periodically perform hitscan for the target
        hitscanTimer += Time.deltaTime;
        if (hitscanTimer >= hitscanInterval)
        {
            hitscanTimer = 0f;
            PerformHitscan();
        }
    }

    void Pursue()
    {
        // Move towards the target
        transform.position = Vector3.MoveTowards(transform.position, target.position, pursueSpeed * Time.deltaTime);

        // Switch to Attack if within firing range
        if (Vector3.Distance(transform.position, target.position) <= firingRange)
        {
            currentState = State.Attack;
        }
    }

    void Attack()
    {
        // Look at target
        transform.LookAt(target);

        // Fire at target if fire timer has elapsed
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireRate)
        {
            fireTimer = 0f;
            FireProjectile();
        }

        // Switch to Pursue if the target moves out of firing range
        if (Vector3.Distance(transform.position, target.position) > firingRange)
        {
            currentState = State.Pursue;
        }
    }

    void SetRandomWanderTarget()
    {
        Vector3 randomDirection = new Vector3(Random.Range(-wanderRadius, wanderRadius), 0, Random.Range(-wanderRadius, wanderRadius));
        wanderTarget = transform.position + randomDirection;
    }

    void PerformHitscan()
    {
        // Check if target is within detection range using a raycast
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        if (Vector3.Distance(transform.position, target.position) <= detectionRange)
        {
            if (Physics.Raycast(transform.position, directionToTarget, out RaycastHit hit, detectionRange))
            {
                if (hit.transform.CompareTag(targetTag))
                {
                    currentState = State.Pursue;
                }
            }
        }
    }

    void FireProjectile()
    {
        // Instantiate and shoot the projectile towards the target
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        projectile.transform.LookAt(target);

        // Optional: Add force to the projectile if it has Rigidbody
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce((target.position - firePoint.position).normalized * 10f, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Adjust direction upon collision
        if (collision.gameObject.CompareTag("Wall"))
        {
            SetRandomWanderTarget();
        }
    }
}
