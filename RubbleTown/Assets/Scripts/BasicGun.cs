using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : MonoBehaviour
{
    [Header("Gun Components")]
    //public Rigidbody rigidBody;
    public GameObject bulletePrefab;
    public GameObject shellPrefab;
    public GameObject muzzleFlash;


    [Header("Transforms")]
    public Transform firePoint;
    public Transform shellEjectionPoint;

    [Header("Gun Stats")]
    public float fireRate ;
    private float delay;
    public float gunAccuracy;
    public float bulletSpeed;
    public float debrisTime;
    public bool triggerDown;

    void Start()
    {
        delay = fireRate;
    }

    void Update()
    {
        if (triggerDown)
        {
            if(delay <= fireRate)
            {
                Shoot();
                delay = 0f;
            }
            else
            {
                delay += Time.deltaTime;
            }
        }


    }

    public void Shoot()
    {
        // Apply bullet spread
        Vector3 spread = Random.insideUnitCircle * gunAccuracy;

        // Spawn projectile at the fire point with spread
        Instantiate(muzzleFlash, firePoint.position, firePoint.rotation);
        Spawn(out GameObject bullet);
        EjectShell();

        Destroy(bullet, debrisTime);
    }

    public void Spawn(out GameObject bullet)
    {
        Vector3 spread = Random.insideUnitCircle * gunAccuracy;

        bullet = Instantiate(bulletePrefab, firePoint.position, firePoint.rotation);
        bullet.transform.Rotate(spread.x, spread.y, 0f);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            bulletRb.velocity = bullet.transform.forward * bulletSpeed;
        }
    }

    private void EjectShell()
    {
        GameObject shell = Instantiate(shellPrefab, shellEjectionPoint.position, shellEjectionPoint.rotation);

        Rigidbody shellRb = shell.GetComponent<Rigidbody>();
        if (shellRb != null)
        {
            float forcePower = Random.Range(2f, 10f);
            Vector3 forceDirection = Quaternion.Euler(Random.Range(-30f, 30f), Random.Range(-30f, 30f), Random.Range(-30f, 30f)) * shellEjectionPoint.forward;
            shellRb.AddForce(forceDirection * forcePower, ForceMode.Impulse);
        }

        Destroy(shell, 2f);
    }
}
