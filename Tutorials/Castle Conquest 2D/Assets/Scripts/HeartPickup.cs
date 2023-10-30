using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    [SerializeField] AudioClip heartPickupSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetType() == typeof(BoxCollider2D)) // Added to prevent double pickups
        {
            AudioSource.PlayClipAtPoint(heartPickupSFX, Camera.main.transform.position);
            FindObjectOfType<GameSession>().AddToLives();
            Destroy(gameObject);
        }

    }
}