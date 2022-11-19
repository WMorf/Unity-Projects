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
        //firstNames.Add("Bob"); firstNames.Add("Larry"); firstNames.Add("Mark");
        //firstNames.Add("Luke"); firstNames.Add("John"); firstNames.Add("Peter");
        //firstNames.Add("Paul"); firstNames.Add("Saul"); firstNames.Add("Tom");
        firstNames = System.IO.File.ReadAllLines(@"Names.txt");
    }



    void Update()
    {

    }

}
