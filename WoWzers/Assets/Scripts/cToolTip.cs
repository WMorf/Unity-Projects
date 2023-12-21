using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class cToolTip : MonoBehaviour
{
    public GameObject infoPanel;
    public bMob script;
    private void Start()
    {
        try
        {
           infoPanel = GameObject.Find("InfoPanel");
        }
        catch { Debug.Log("Not found"); };
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
