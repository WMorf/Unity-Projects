using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGenerated_Controller : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 3f;
    public GameObject projectilePrefab;
    public GameObject muzzleFLash;
    public Transform firePoint;
    public float projectileSpeed = 20f;
    public float fireRate = 0.5f; // Time between shots in seconds
    public float accuracy = 0.1f; // Accuracy value (smaller values result in tighter spread)
    private float nextFireTime;

    private void Update()
    {
        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Player rotation
        float rotationInput = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * rotationInput * rotationSpeed);

        // Shooting
        if (Input.GetButton("Fire1") && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Shoot()
    {
        // Apply bullet spread
        Vector3 spread = Random.insideUnitCircle * accuracy;

        // Spawn projectile at the fire point with spread
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Instantiate(muzzleFLash, firePoint.position, firePoint.rotation);
        projectile.transform.Rotate(spread.x, spread.y, 0f);

        // Set the projectile's velocity
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        if (projectileRb != null)
        {
            projectileRb.velocity = projectile.transform.forward * projectileSpeed;
        }

        // Destroy the projectile after a set time (to prevent clutter)
        Destroy(projectile, 10f);
    }
}