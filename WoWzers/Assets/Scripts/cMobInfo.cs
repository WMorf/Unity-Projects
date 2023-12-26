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
        public SpriteRenderer render;
        public cStateManager manager;


    [Header("Stats")]

        [Tooltip("How much value a mob is worth when calculating rewardScore for an opposing mob")]
        public int baseReward;
        public float speed;
        public float maxLifeTime;

    //Runtime
        private int rewardScore;
        private int currentSpeed;
        private float lifeTime;

    //[Header("Logic")]
        //public bool shouldNest;


    void Start()
    {
        
    }
}
