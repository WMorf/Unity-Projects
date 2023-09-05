using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile_Decay : MonoBehaviour
{

    public float lifetime = 4f; // duration of the effect in seconds

    private float timeElapsed = 0f; // time elapsed since the effect started

    void Update()
    {
        // increment the time elapsed
        timeElapsed += Time.deltaTime;

        // destroy the effect after the specified lifetime
        if (timeElapsed >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
