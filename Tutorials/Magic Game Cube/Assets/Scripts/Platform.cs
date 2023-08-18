using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    int valueToSend = 9;
    void Start()
    {
        string stringFromOutside = FindObjectOfType<Cube>().PrintingFromOutside(valueToSend);
        Debug.Log(stringFromOutside);
    }

    void Update()
    {
        
    }
}
