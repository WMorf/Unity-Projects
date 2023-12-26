using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bSpawnCheck : MonoBehaviour
{
    public Text textN, textS, textE, textW, textSpawn;
    public int pointN, pointS, pointE, pointW;
    public int spawnCount;


    private void Update()
    {
        textN.text = pointN.ToString();
        textS.text = pointS.ToString();
        textE.text = pointE.ToString();
        textW.text = pointW.ToString();
        textSpawn.text = spawnCount.ToString();
    }
}
