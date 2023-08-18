using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{

    public GameObject GameSource;
    public Props props;

    void Start()
    {
        GameSource = FindObjectOfType<Props>().gameObject; // Searches for GameLogic object

        props = GameSource.GetComponent<Props>(); // gets Mobs component from GameLogic
        props.trash.Add(this.gameObject);
    }


    void Update()
    {
        
    }

    private void OnDestroy()
    {
        props.trash.Remove(this.gameObject);
    }

}
