using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int damage, health;
    public Rigidbody2D rb;

    void Start()
    {
        rb.linearVelocity = transform.up * speed;
        Destroy(gameObject, lifeTime);
    }


    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
