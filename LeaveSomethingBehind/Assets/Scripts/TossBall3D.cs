using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossBall3D : MonoBehaviour
{
    public GameObject emission;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.tag);
        if(collision.gameObject.tag == "Ground")
        Instantiate<GameObject>(emission, transform.position, Quaternion.identity);
    }
}
