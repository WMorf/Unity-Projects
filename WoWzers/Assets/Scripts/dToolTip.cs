using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dToolTip : MonoBehaviour
{
    //Makes GameObject Mobs "clickable" and will populate InfoPanel object if found

    [Header("Scripts")]
    public dMobInfo mobInfo;

    [Header("Objects")]
    public GameObject infoPanel;

    [Header("Cursor")]
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = new Vector2(-1f, -1f);

    void Start()
    {
        try
        {
            infoPanel = GameObject.Find("InfoPanel");
        }
        catch { if (mobInfo.debug) { Debug.Log("Info Panel not found"); } };
    }

    private void OnMouseDown()
    {
        if (mobInfo.debug) { Debug.Log("Clicked"); }
        try
        {
            infoPanel.GetComponent<dInfoPanel>().GetMob(mobInfo);
        }
        catch { if (mobInfo.debug) { Debug.Log("Mob not found"); } }
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
