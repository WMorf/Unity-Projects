using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool closeWhenEntered /*, openWhenMobsCleared */;

    public GameObject[] doors;

    //public List <GameObject> mobs = new List<GameObject>();

    [HideInInspector]
    public bool roomActive;

    private bool doorCount;
    public float doorWait = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        /*if(mobs.Count > 0 && roomActive && openWhenMobsCleared)
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
                foreach(GameObject door in doors)
                {
                    door.SetActive(false);

                    closeWhenEntered = false;
                }
            }
        }*/
        
        if(doorCount == true && doorWait > 0)
        {
            doorWait -= Time.deltaTime;
            
            if (closeWhenEntered)
                
                if(doorWait <= 0)
                {
                    foreach(GameObject door in doors)
                    {
                        door.SetActive(true);
                    }
                }
        }
    }

    public void OpenDoors()
    {
        foreach(GameObject door in doors)
        {
            door.SetActive(false);

            closeWhenEntered = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        
        if(other.tag == "Player")
        {
            CameraController.instance.ChangeTarget(transform);

            roomActive = true;
            doorCount = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            roomActive = false;
            doorCount = false;
        }
    }
}
