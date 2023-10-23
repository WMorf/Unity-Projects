using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] float radius = 3f;
    [SerializeField] Vector2 explosionForce = new Vector2 (200f, 100f);

    [SerializeField] AudioClip explodingSFX, burningSFX;

    Animator myAnimator;
    AudioSource myAudioSource;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        myAnimator.SetTrigger("Burn");
        myAudioSource.PlayOneShot(burningSFX);
    }

    void ExplodeBomb()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, radius, LayerMask.GetMask("Player"));
        myAudioSource.PlayOneShot(explodingSFX);

        if (playerCollider)
        {
            //print("Got You");

            playerCollider.GetComponent<Rigidbody2D>().AddForce(explosionForce);
            playerCollider.GetComponent<Player>().PlayerHit();
        }
    }

    void DestroyBomb()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
