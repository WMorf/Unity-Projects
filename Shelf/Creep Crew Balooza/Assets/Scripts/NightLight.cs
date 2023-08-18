using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class NightLight : MonoBehaviour
{

    public static NightLight instance;

    public Light2D lightSource;

    public int brightTick;
    public float maxBright,smallBright;
    //counter and threshold to toggle light
    public float tockTick, tockThreshold;
    //true = Light
    public bool darkLight;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        tockTick = 0f;
        lightSource = GetComponent<Light2D>();
    }

    void Update()
    {
        //
        tockTick += Time.deltaTime;
        if(tockTick >= tockThreshold)
        {
            darkLight = !darkLight;
            tockTick = 0f;
        }

        if(darkLight)
        {
            lightSource.intensity = maxBright;            
        }else
        {
            lightSource.intensity = smallBright;
        }
    }
}
