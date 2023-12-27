using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class cToolTip : MonoBehaviour
{
    public GameObject infoPanel;
    public cMobInfo script;
    private void Start()
    {
        try
        {
           infoPanel = GameObject.Find("InfoPanel");
        }
        catch { Debug.Log("Info Panel not found"); };
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        try
        {
            infoPanel.GetComponent<cInfoPanel>().GetMob(script);
        }
        catch
        {

        }
    }
}
