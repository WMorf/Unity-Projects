using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cMobInfo : MonoBehaviour
{
    //[Header("")]
    //[Tooltip("")]

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject spawner;


    [Header("Stats")]

    public int baseReward; [Tooltip("How much value a mob is worth when calculating rewardScore for an opposing mob")]
    public float speed;
    public float maxLifeTime, maxTimeVariation;


    //Runtime
    private int rewardScore;
    private int currentSpeed;
    private float lifeTime;

    [Header("Logic")]
    public bool shouldVaryLifeTime;
    public bool shouldNest;


    void Start()
    {
        if (shouldVaryLifeTime) { maxLifeTime = Random.Range(maxLifeTime, maxLifeTime + maxTimeVariation); }; //Keeps certain mobs consistant
    }
}
