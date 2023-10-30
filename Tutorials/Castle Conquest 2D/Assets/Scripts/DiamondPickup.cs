using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class DiamondPickup : MonoBehaviour
{
    [SerializeField] int diamondValue = 100;
    [SerializeField] AudioClip diamondPickupSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetType() == typeof(BoxCollider2D)) // Added to prevent double pickups
        {
            AudioSource.PlayClipAtPoint(diamondPickupSFX, Camera.main.transform.position);
            FindObjectOfType<GameSession>().AddToScore(diamondValue);
            Destroy(gameObject);
        }
    }
}
