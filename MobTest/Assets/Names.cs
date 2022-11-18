using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Names : MonoBehaviour
{
    public static Names instance;
    public List<string> firstNames;


void Start()
    {
        firstNames.Add("Bob"); firstNames.Add("Larry"); firstNames.Add("Mark");
        firstNames.Add("Luke"); firstNames.Add("John"); firstNames.Add("Peter");
        firstNames.Add("Paul"); firstNames.Add("Saul"); firstNames.Add("Tom");
        string[] someNames = System.IO.File.ReadAllLines(@"Names.txt");
    }



    void Update()
    {
        //"Bob","Larry","Steve","Jackie"
    }

    //public GetName(string name)
    //{       
    //    name = this.firstNames[UnityEngine.Random.Range(0, this.firstNames.Count + 1)];
    //    return name;
    //}

}
