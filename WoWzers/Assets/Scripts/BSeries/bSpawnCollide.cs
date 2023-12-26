using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bSpawnCollide : MonoBehaviour
{
    [SerializeField] bool N, S, E, W;
    [SerializeField] bSpawnCheck SpawnCheck;

    private void Awake()
    {
        SpawnCheck = FindAnyObjectByType(typeof(Canvas)).GetComponent<bSpawnCheck>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (N)
        {
            SpawnCheck.pointN = 1;
        }
        if (S)
        {
            SpawnCheck.pointS = 1;
        }
        if (E)
        {
            SpawnCheck.pointE = 1;
        }
        if (W)
        {
            SpawnCheck.pointW = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (N)
        {
            SpawnCheck.pointN = 0;
        }
        if (S)
        {
            SpawnCheck.pointS = 0;
        }
        if (E)
        {
            SpawnCheck.pointE = 0;
        }
        if (W)
        {
            SpawnCheck.pointW = 0;
        }
    }

}
