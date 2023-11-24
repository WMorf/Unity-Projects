using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bMob : MonoBehaviour
{
    // Rigidbody2D component reference
    private Rigidbody2D rb;

    // Movement speed
    public float speed = 5f;
    public bSpawner spawner;
    public int rewardScore;

    public float lifeTime;
    public float moveDelay;
    public Vector2 newDirection;

    public GameObject nest;
    [SerializeField] bSpawnCheck SpawnCheck;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        SpawnCheck = FindAnyObjectByType(typeof(Canvas)).GetComponent<bSpawnCheck>();
        StartCoroutine(Shift());
    }

    void Update()
    {
        lifeTime += Time.deltaTime;
        // Apply a random direction every frame

        rb.velocity = newDirection * speed;


        if (rewardScore > 10)
        {
            Instantiate(nest, transform.position, transform.rotation);
            GameObject.Destroy(gameObject);
        }
    }

    IEnumerator Shift()
    {
        while (true)
        {
            this.newDirection = Random.insideUnitCircle;
            yield return new WaitForSeconds(moveDelay);
        }

    }

    private void OnDestroy()
    {
        spawner.popCurrent--;
        SpawnCheck.spawnCount--;
    }
}