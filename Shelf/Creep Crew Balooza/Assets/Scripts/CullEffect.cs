using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullEffect : MonoBehaviour
{
    public float cullTime;
    public bool shotPoint;

    // Update is called once per frame
    void Update()
    {
        if(shotPoint)
        {
            cullTime = PlayerController.instance.timeBetweenShots;
        }

        cullTime -= Time.deltaTime;

        if(cullTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
