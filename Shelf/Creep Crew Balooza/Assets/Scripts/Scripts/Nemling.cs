using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nemling : MonoBehaviour
{
    public static Nemling instance;

    private void Awake() 
    {
        instance= this;
    }

    void Start()
    {
        
    }

    void Update()
    {
    
    }

    private void OnTriggerEnter2D(Collider2D other) 
        {
            
        }
}
