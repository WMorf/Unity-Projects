using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dIndicator : MonoBehaviour
{
    public float timer, threshold;
    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > threshold)
        {
            Destroy(gameObject);
        }
    }
}
