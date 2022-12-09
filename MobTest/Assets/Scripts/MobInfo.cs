using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MobInfo : MonoBehaviour
{
    public static MobInfo instance;

    [Header("Components")]
    public GameObject NameSource;
    public Rigidbody theRB;
    public Animator anim;
    //public SpriteRenderer theBody;
    //public Transform emotePoint;

    [Header("Mob Body")]
    public MobBrain Brain;
    public MobInfo Info;
    public MobMotor Motor;
    public GameObject EmotePoint;

    [Header("Identity")]
    public string MyName;

    [Header("Stats")]
    public float moveSpeed;
    public float curSpeed;
    //public int endurance;
    //private int curEndurance;
    //private bool isPanicking;
    //private bool isCowering;

    [Header("Bools")]
    public bool shouldIdle;
    public bool shouldCharge;
    public bool shouldWander;
    public bool shouldShoot;
    public bool shouldFlee;
    public bool shouldCower;
    public bool shouldMelee;
    public bool shouldGib;
    public bool shouldDropItems;
    public bool shouldEmote;
    public bool shouldPanic;

    [Header("Timers and Ranges")]
    public float fleeLength;
    public float idleLength;
    public float wanderLength;
    public float panicLength;
    public float cowerLength;
    public float meleeTimeLength;
    public float stunLength;
    public float chargeLength;
    public float rangeToChase;
    public int rangeToFlee;

    //Trash Test
    public bool shouldTrash;
    public float trashFrequency;
    public int trashLimit;
    public GameObject trashBit;

    //[Header("Relations")]
    //public List<GameObject> friendsList;
    //public int maxFriends;
    //public string foe;
    //public string friend;

    //[Header("Threat and Morale")]
    //public float moraleBase;
    //private float curMorale;
    //public float threatBase;
    //private float curThreat;
    //private float targetThreat;

    //[Header("Shoot")]
    //public GameObject bullet;
    //public Transform firePoint;

    //[Header("Emotes")]
    //public GameObject[] emotions;
    public float timeBetweenEmotes;

    //[Header("Gibbing")]
    //public bool shouldLeaveCorpse;
    //public GameObject hitEffect;
    //public GameObject[] splatters;

    //[Header("Drops")]
    //public GameObject[] itemsToDrop;
    //public float itemDropPercent;

    //[Header("Sprites")]
    //public Sprite[] bodies;
    //public int curSpriteCount;
    //private Sprite curSprite;

    [Header("Tools")]
    public bool showDebug;
    public bool showEmoteDebug;

    void Start()
    {
        GameObject NameSource = Selection.activeGameObject;
    }


    void Update()
    {

        //Identity
        NameSource = FindObjectOfType<Names>().gameObject;

        MyName = NameSource.;

        //if (MyName == "" && NameSource.Names.firstNames.Length > 0)
        //{
        //    MyName = NameSource.firstNames[UnityEngine.Random.Range(0, NameSource.firstNames.Length)];
        //}

    }
}
