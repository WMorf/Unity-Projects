using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cMobEyes : MonoBehaviour
{
    public cMobInfo info;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.gameObject.tag);
        //print("Hit Outside");
        if (collision.gameObject.CompareTag("Wolf"))
        {
            target = collision.gameObject;
            info.manager.target = target;
            info.manager.panic = true;

            print("Hit");

        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wolf"))
        {
            target = null;
            info.manager.target = null;

            print("Leave");

        }
    }

}
