using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class cToolTip : MonoBehaviour
{
    public GameObject infoPanel;
    public cMobInfo script;


    //Mouse Cursor
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = new Vector2(-1f,-1f);

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
        catch{ Debug.Log("Mob not found"); }
    }

    //Cursor
    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        // Pass 'null' to the texture parameter to use the default system cursor.
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
