using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSwap : MonoBehaviour
{

    public SpriteRenderer render;
    public Sprite[] faceOptions;


    void Start()
    {
        render.sprite = faceOptions[Random.Range(0, faceOptions.Length)];
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            render.sprite = faceOptions[Random.Range(0, faceOptions.Length)];
        }
    }
}
