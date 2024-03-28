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
        public GameObject nest;
        public SpriteRenderer render;
        public cStateManager manager;
        public GameObject eyes;


    [Header("Stats")]

        [Tooltip("How much value a mob is worth when calculating rewardScore for an opposing mob")]
        public int baseReward;
        public float speed;
        public float maxLifeTime;

    [Header("Runtime")]
        public int rewardScore;
        public float lifeTime;

    [Header("Logic")]
        public bool shouldNest;
        public int nestScore;
        public bool eatRotten;
        public string friend, foe;


    private void Start()
    {

    }

    private void Update()
    {
        lifeTime += Time.deltaTime;
    }
}
