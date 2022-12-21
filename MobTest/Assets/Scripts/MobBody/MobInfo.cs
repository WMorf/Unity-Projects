using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MobInfo : MonoBehaviour
{
    //Overall Stats, Rates, Ranges, and other info for each Mob
    //Acts as a Big Switchboard for other Mob body parts to

    public static MobInfo instance;

    [Header("Components")]
    public GameObject GameSource;
    public Names nameComp;
    public Mobs mobComp;
    public Rigidbody theRB;
    public Animator anim;
    //public SpriteRenderer theBody;
    //public Transform emotePoint;

    [Header("Mob Body")]
    public MobBrain Brain;
    public MobInfo Info;
    public MobMotor Motor;
    public MobSense Sense;
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

    //Allows user to check boxes which will affect MobBrain
    [Header("Bools")] 
    public bool shouldIdle;
    public bool shouldWander;
    public bool shouldSearch;
    public bool shouldCharge;
    public bool shouldShoot;
    public bool shouldFlee;
    public bool shouldCower;
    public bool shouldMelee;
    public bool shouldGib;
    public bool shouldDropItems;
    public bool shouldEmote;
    public bool shouldPanic;

    [Header("Timers")]
    public float idleLength;
    public float wanderLength;
    public float searchLength;
    public float fleeLength;
    public float panicLength;
    public float cowerLength;
    public float meleeTimeLength;
    public float stunLength;
    public float chargeLength;

    [Header("Ranges")]
    public float rangeToChase;
    public int rangeToFlee;

    [Header("Trash Test")]
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
        //Identity
        GameSource = FindObjectOfType<Names>().gameObject; // Searches for GameLogic object

        mobComp = GameSource.GetComponent<Mobs>(); // gets Mobs component from GameLogic
        nameComp = GameSource.GetComponent<Names>(); // gets Names component from GameLogic

        // Add mob to mobList
        mobComp.mobList.Add(this.gameObject);

    }

    // Called from Game Logic as List Populates
    public void UpdateName()
    {
        // Assigns name after list is populated
        if (MyName == "" && this.nameComp.firstNames.Length > 0)
        {
            MyName = this.nameComp.firstNames[UnityEngine.Random.Range(0, this.nameComp.firstNames.Length)];
        }
    }


    void Update()
    {

    }
}
