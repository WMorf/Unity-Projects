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


    [Header("Points")]
    public GameObject firePoint1;
    public GameObject shellEjectionPoint1;

    [Header("Gun Stats")]
    public float fireRate ;
    private float delay;
    public float gunAccuracy;
    public float bulletSpeed;
    public float debrisTime;
    public bool triggerDown;
    public float shellEjectionForce;

    void Start()
    {
        delay = fireRate;
    }

    void Update()
    {
        if (triggerDown)
        {
            if(delay >= fireRate)
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
        //Vector3 spread = Random.insideUnitCircle * gunAccuracy;

        // Spawn projectile at the fire point with spread
        Spawn(firePoint1);
        EjectShell(shellEjectionPoint1);

        //Destroy(bullet, debrisTime);
    }

    public void Spawn(GameObject firePoint)
    {
        Vector3 spread = Random.insideUnitCircle * gunAccuracy;
        //print(spread);

        Instantiate(muzzleFlash, firePoint.transform.position, firePoint.transform.rotation);
        GameObject bullet = Instantiate(bulletePrefab, firePoint.transform.transform.position, firePoint.transform.rotation);
        bullet.transform.Rotate(spread.x, spread.y, 0f);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            Vector3 directionWithSpread = bullet.transform.forward + new Vector3(spread.x, spread.y, 0f);
            bulletRb.velocity = directionWithSpread.normalized * bulletSpeed;
        }
    }

    private void EjectShell(GameObject ejectPoint)
    {
        GameObject shell = Instantiate(shellPrefab, ejectPoint.transform.transform.transform.position, ejectPoint.transform.transform.rotation);

        try
        {
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();
            shell.GetComponent<Rigidbody>().AddForce(ejectPoint.transform.forward * shellEjectionForce, ForceMode.Impulse);
            if (shellRb != null)
            {
                float forcePower = Random.Range(shellEjectionForce * .5f, shellEjectionForce * 1.5f);
                Vector3 forceDirection = Quaternion.Euler(Random.Range(-30f, 30f), Random.Range(-30f, 30f), Random.Range(-30f, 30f)) * ejectPoint.transform.forward;
                shellRb.AddForce(forceDirection * forcePower, ForceMode.Impulse);
            }
        }
        catch
        {
            Debug.LogError("Shell prefab does not have a Rigidbody component.");
        }



        Destroy(shell, debrisTime);
    }
}
