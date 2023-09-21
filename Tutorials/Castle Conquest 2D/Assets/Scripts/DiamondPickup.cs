using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class DiamondPickup : MonoBehaviour
{
    [SerializeField] AudioClip diamondPickupSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(diamondPickupSFX, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
