using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dMobInfo : MonoBehaviour
{
    

    [Header("Components")]
    public Rigidbody rb;
    public Animator anim;
    public SpriteRenderer render;

    [Header("Scripts")]
    public dStateManager manager;

    [Header("Objects")]
    public GameObject eyes;
    public GameObject nest;


    [Header("Stats")]
    [Tooltip("How much value a mob is worth when calculating rewardScore for an opposing mob")]
    public int baseReward;
    public float speed;
    public float maxLifeTime;

    [Header("Logic")]
    public bool shouldNest;
    public int nestScore;
    public bool eatRotten;
    public string friend, foe;

    [Header("Runtime")]
    public bool debug;
    public int rewardScore;
    public float lifeTime;
    public string mood = "normal";



    private void Start()
    {

    }

    private void Update()
    {
        lifeTime += Time.deltaTime;
    }
}
