using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bMob : MonoBehaviour
{
    // Rigidbody2D component reference
    private Rigidbody2D rb;

    // Movement speed
    public float speed =2f, currentSpeed;
    public bSpawner spawner;
    public int rewardScore;
    public int baseReward;

    public bool shouldNest;

    public float lifeTime, maxLifeTime, maxTimeVariation;
    public float moveDelay;
    public Vector2 newDirection;

    public Animator anim;

    public GameObject nest;
    [SerializeField] bSpawnCheck SpawnCheck;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        SpawnCheck = FindAnyObjectByType(typeof(Canvas)).GetComponent<bSpawnCheck>();
        maxLifeTime = Random.Range(maxLifeTime, maxLifeTime + maxTimeVariation);
        currentSpeed = speed;
        StartCoroutine(Shift());
    }

    void Update()
    {
        lifeTime += Time.deltaTime;
        // Apply a random direction every frame

        rb.velocity = newDirection * currentSpeed;


        if (rewardScore >= 20 && shouldNest )
        {
            GameObject newNest = Instantiate(nest, transform.position, transform.rotation);
            newNest.GetComponent<bSpawner>().spawnColor = this.GetComponent<SpriteRenderer>().material.color;
            GameObject.Destroy(gameObject);
        }

        if (lifeTime > maxLifeTime)
        {
            GameObject.Destroy(gameObject);
        }
    }

    IEnumerator Shift()
    {
        anim.SetBool("Moving", true);
        Debug.Log("Shift Start");
        currentSpeed = speed;
        this.newDirection = Random.insideUnitCircle;
        //StartCoroutine(Idle());
        yield return new WaitForSeconds(moveDelay);
        Debug.Log("Shift End");
        StartCoroutine(Idle());
    }
    //IEnumerator Shift()
    //{
    //    while (true)
    //    {
    //        this.newDirection = Random.insideUnitCircle;
    //        yield return new WaitForSeconds(moveDelay);
    //    }

    //}
    IEnumerator Idle()
    {
        anim.SetBool("Moving", false);
        Debug.Log("Idle Start");
        currentSpeed = 0f;
        yield return new WaitForSeconds(moveDelay);
        Debug.Log("Idle End");
        StartCoroutine(Shift());
    }

    private void OnDestroy()
    {
        spawner.popCurrent--;
        SpawnCheck.spawnCount--;
    }
}