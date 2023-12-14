using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bMobInfo : MonoBehaviour
{

    //Components
    public SpriteRenderer render;

    //Generation
    public bool shouldMutate;
    public Color color, colorMutation;
    public float colorRangeMin, colorRangeMax;


    // Start is called before the first frame update
    void Start()
    {
        //Color
        color = render.color;
        if(shouldMutate) 
        {
            Color lerpColor = Random.ColorHSV();
            lerpColor.a = 1.0f;
            colorMutation = Color.Lerp(color, lerpColor, Random.Range(colorRangeMin, colorRangeMax));
            //Debug.Log(colorMutation);
            render.color = colorMutation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
