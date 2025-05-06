using UnityEngine;

public class Breakable : MonoBehaviour
{
    public int hp;

    public bool vanish, report;

    public GameObject breakFX;
    void Start()
    {
        
    }

    void Update()
    {
        if(hp <= 0)
        {
            if (report)
            {
                Debug.Log(gameObject.name + " is destroyed");
            }
            Instantiate(breakFX, gameObject.transform);
            Debug.Log("hit");
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            hp -= 1;
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Laser"))
    //    {
    //        hp -= 1;
    //    }

    //}
}
