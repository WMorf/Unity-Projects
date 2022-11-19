using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Names : MonoBehaviour
{
    public static Names instance;
    public string[] firstNames;


void Start()
    {
        //Adds 1 name per line from the text file
        firstNames = System.IO.File.ReadAllLines(@"Names.txt");
    }



    void Update()
    {

    }

}
