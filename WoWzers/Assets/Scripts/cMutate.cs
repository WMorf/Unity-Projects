using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cMutate : MonoBehaviour
{
    [Header("Components")]
    public cMobInfo mobInfo;

    [Header("Color")]
    public bool shouldMutate_Color;
    private Color color, colorMutation;
    public float colorRangeMin, colorRangeMax;

    [Header("Time")]
    public bool shouldMutate_Time;
    public float maxTimeVariation;


    // Start is called before the first frame update
    void Start()
    {
        //Color Mutation
        if (shouldMutate_Color)
        {
            try
            {
                color = mobInfo.render.color;
                Color lerpColor = Random.ColorHSV();
                lerpColor.a = 1.0f;
                colorMutation = Color.Lerp(color, lerpColor, Random.Range(colorRangeMin, colorRangeMax));
                mobInfo.render.color = colorMutation;
            }
            catch 
            {
                Debug.Log("Error Mutating Color");
            }
        }

        //LifeTime Mutation
        if (shouldMutate_Time) 
        {
            try
            {
                mobInfo.maxLifeTime = Random.Range(mobInfo.maxLifeTime, mobInfo.maxLifeTime + maxTimeVariation);
            }
            catch 
            {
                Debug.Log("Error Mutating LifeTime");
            }
        }
    }
}
