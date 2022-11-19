using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobInfo : MonoBehaviour
{
    public static MobInfo instance;

    public Names NameSource;
    public string MyName;

    void Start()
    {
        
    }


    void Update()
    {
        //Identity
        if(MyName == "" && NameSource.firstNames.Length > 0)
        {
            MyName = NameSource.firstNames[UnityEngine.Random.Range(0, NameSource.firstNames.Length)];
        }

    }
}
