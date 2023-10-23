using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetTrigger("Open");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
