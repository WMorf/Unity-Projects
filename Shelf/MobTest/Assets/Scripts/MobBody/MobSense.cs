using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobSense : MonoBehaviour
{
    [Header("Mob Body")]
    public MobBrain Brain;
    public MobInfo Info;
    public MobMotor Motor;
    public MobSense Sense;
    public GameObject EmotePoint;

    enum Bump { Null, Trash, Friend, Foe, Building }
    Bump beenBumped;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Trash") { beenBumped = Bump.Trash;}
        if (other.gameObject.tag == "Building") { beenBumped = Bump.Building; }

        switch (beenBumped)
        {

            case Bump.Trash:

                if (Info.showDebug) { Debug.Log(string.Format(Info.MyName + " Collided With: " + other.gameObject.name)); }

                break;

            case Bump.Building:

                if (Info.showDebug) { Debug.Log(string.Format(Info.MyName + "Who put that " + other.gameObject.name + " there?")); }

                //if

                break;
        }

        ////Friendly
        //if (other.gameObject.tag == Info.friend)
        //{
        //    moveDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        //}

        ////Enemy
        //if (other.gameObject.tag == Info.foe)
        //{
        //    Info.mobTarget = other.gameObject;

        //    if (Info.showEmoteDebug) { Debug.Log(string.Format("Kill that SOB {0}", Info.mobTarget)); }
        //}

        ////Bump
        //if (other.gameObject.tag == "Building")
        //{
        //    Motor.moveDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        //}

    }
}
