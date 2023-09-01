using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossBall : MonoBehaviour
{
    public GameObject emission;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        Instantiate<GameObject>(emission, transform.position, Quaternion.identity);
    }
}
