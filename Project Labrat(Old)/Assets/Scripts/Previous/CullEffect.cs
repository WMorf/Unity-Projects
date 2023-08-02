using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullEffect : MonoBehaviour
{
    public float cullTime;

    // Update is called once per frame
    void Update()
    {

        cullTime -= Time.deltaTime;

        if(cullTime <= 0)
        {
            Destroy(gameObject);
        }
        
    }
}
