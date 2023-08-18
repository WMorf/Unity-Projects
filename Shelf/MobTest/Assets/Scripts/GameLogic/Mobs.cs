using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobs : MonoBehaviour
{
    public List<GameObject> mobList = new List<GameObject>();
    public List<GameObject> rat = new List<GameObject>();

    void Start()
    {
        
    }

    public void UpdateMobs() //Updates mobs in list, then sorts based on name.
    {
        if (mobList.Count > 0)
        {
            
            foreach (GameObject mob in mobList)
            {

                mob.GetComponent<MobInfo>().UpdateName(); // calls each mob to update their information

                if (mob.name.Contains("Rat"))
                {
                    rat.Add(mob.gameObject);
                }
            }
            mobList.Clear(); //Removes mobs from mobList after being sorted to appropriate lists

        }
    }

    void Update()
    {
        UpdateMobs();
    }
}
