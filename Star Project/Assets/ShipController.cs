using UnityEngine;

public class ShipController : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    public float speedThrust,speedSpin;


    void Start()
    {
        
    }
    void Update()
    {
       CheckKey();
    }

    void FixedUpdate()
    {

    }

    void CheckKey()
    {
        //Thrust
        if (Input.GetKeyDown(KeyCode.W))
        {
            Thrust(1f);
            spriteRenderer.color = Color.red;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            spriteRenderer.color = Color.grey;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Thrust(-1f);
            spriteRenderer.color = Color.red;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            spriteRenderer.color = Color.grey;
        }

        //Rotate
        if (Input.GetKeyDown(KeyCode.A))
        {
            Rotate(1f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Rotate(-1f);
        }

    }

    void Thrust(float i)
    {
        rb.AddForce(transform.up * speedThrust  * i, ForceMode2D.Force);
    }

    void Rotate(float i)
    {
        rb.AddTorque(speedSpin * i);
    }
}
