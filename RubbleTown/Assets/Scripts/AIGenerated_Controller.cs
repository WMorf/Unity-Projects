using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGenerated_Controller : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 3f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public Transform shellEjectionPoint; // Point to eject shells from
    public GameObject shellPrefab; // Prefab of the spent shell
    public GameObject muzzleFLash;
    public float projectileSpeed = 20f;
    public float fireRate = 0.5f; // Time between shots in seconds
    private float nextFireTime;
    public float accuracy;
    public GameObject gunObject;


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
        Instantiate(muzzleFLash, firePoint.position, firePoint.rotation);
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectile.transform.Rotate(spread.x, spread.y, 0f);

        // Set the projectile's velocity
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        if (projectileRb != null)
        {
            projectileRb.velocity = projectile.transform.forward * projectileSpeed;
        }
        EjectShell();

        // Destroy the projectile after a set time (to prevent clutter)
        Destroy(projectile, 10f);
    }

    private void EjectShell()
    {
        // Instantiate the spent shell at the ejection point
        GameObject shell = Instantiate(shellPrefab, shellEjectionPoint.position, shellEjectionPoint.rotation);

        // Add a random force to the shell to simulate ejection arc
        Rigidbody shellRb = shell.GetComponent<Rigidbody>();
        if (shellRb != null)
        {
            float forceMagnitude = Random.Range(5f, 10f); // Adjust the force range as needed
            Vector3 forceDirection = Quaternion.Euler(Random.Range(-30f, 30f), Random.Range(-30f, 30f), Random.Range(-30f, 30f)) * shellEjectionPoint.forward;
            shellRb.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
        }

        // Destroy the shell after a set time (to prevent clutter)
        //Destroy(shell, 2f);
    }

}