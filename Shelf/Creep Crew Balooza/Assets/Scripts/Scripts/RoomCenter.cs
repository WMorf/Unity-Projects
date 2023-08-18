using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCenter : MonoBehaviour
{
    public bool openWhenMobsCleared;

    public List <GameObject> mobs = new List<GameObject>();

    public Room theRoom;

    void Start()
    {
        if(openWhenMobsCleared)
        {
            theRoom.closeWhenEntered = true;
        }
    }

    void Update()
    {
        if(mobs.Count > 0 && theRoom.roomActive && openWhenMobsCleared)
        {
            for(int i = 0; i < mobs.Count; i++)
            {
                if(mobs[i] == null)
                {
                    mobs.RemoveAt(i);
                    i--;
                }
            }

            if(mobs.Count == 0)
            {
                theRoom.OpenDoors();
            }
        }
    }
}
