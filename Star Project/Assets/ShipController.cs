using UnityEngine;

public class ShipController : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public bool thrustOn = false;


    public float speed;


    void Start()
    {
        
    }
    void Update()
    {
       CheckKey();
    }

    void FixedUpdate()
    {
        Thrust();
    }

    void CheckKey()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            thrustOn = true;
            spriteRenderer.color = Color.red;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            thrustOn = false;
            spriteRenderer.color = Color.grey;
        }

    }

    void Thrust()
    {
        if (thrustOn)
        {
            rb.AddForce(transform.up * speed, ForceMode2D.Force);
        }

    }
}
