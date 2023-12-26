using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bMob : MonoBehaviour
{
    public bMobInfo info;
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
        moveDelay += Random.Range(.5f, -.5f);
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


        if (rewardScore >= 12 && shouldNest )
        {
            shouldNest = false;
            GameObject newNest = Instantiate(nest, transform.position, transform.rotation);
            newNest.GetComponent<bSpawner>().spawnColor = info.render.color;
            //GameObject.Destroy(gameObject);
        }

        if (lifeTime > maxLifeTime)
        {
            GameObject.Destroy(gameObject);
        }
    }

    IEnumerator Shift()
    {
        anim.SetBool("Moving", true);
        //Debug.Log("Shift Start");
        currentSpeed = speed;
        this.newDirection = Random.insideUnitCircle;
        //StartCoroutine(Idle());
        yield return new WaitForSeconds(moveDelay);
        //Debug.Log("Shift End");
        StartCoroutine(Idle());
    }
    
    IEnumerator Home()
    {
        Debug.Log(new Vector2(spawner.transform.position.x, spawner.transform.position.y));
        anim.SetBool("Moving", true);
        //Debug.Log("Shift Start");
        currentSpeed = speed;
        this.newDirection = new Vector2(spawner.transform.position.x, spawner.transform.position.y);
        //StartCoroutine(Idle());
        yield return new WaitForSeconds(moveDelay);
        //Debug.Log("Shift End");
        StartCoroutine(Idle());
    }
    
    IEnumerator Idle()
    {
        anim.SetBool("Moving", false);
        //Debug.Log("Idle Start");
        currentSpeed = 0f;
        yield return new WaitForSeconds(moveDelay);
        //Debug.Log("Idle End");
        //Unused until I fix movement code
        int rando = Random.Range(0, 3);
        if(rando == 4)
        {
            StartCoroutine(Home());
        }
        else
        {
            StartCoroutine(Shift());
        }
    }

    private void OnDestroy()
    {
        spawner.popCurrent--;
        SpawnCheck.spawnCount--;
    }
}