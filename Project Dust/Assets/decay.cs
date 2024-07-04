using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decay : MonoBehaviour
{
    public float timer;
    public float rate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1 * Time.deltaTime;
        //rate *= Time.deltaTime;
        transform.localScale -= new Vector3(rate, rate, rate);

        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }
}
