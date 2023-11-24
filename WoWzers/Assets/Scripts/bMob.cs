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

    public bool shouldNest;

    public float lifeTime, maxLifeTime, maxTimeVariation;
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
        maxLifeTime = Random.Range(maxLifeTime, maxLifeTime + maxTimeVariation);
    }

    void Update()
    {
        lifeTime += Time.deltaTime;
        // Apply a random direction every frame

        rb.velocity = newDirection * speed;


        if (rewardScore >= 10 && shouldNest )
        {
            Instantiate(nest, transform.position, transform.rotation);
            GameObject.Destroy(gameObject);
        }

        if (lifeTime > maxLifeTime)
        {
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