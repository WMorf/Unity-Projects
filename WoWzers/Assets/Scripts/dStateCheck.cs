using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dStateCheck : MonoBehaviour
{
    public dMobInfo mobInfo;
    public dStateManager manager;
    public dState currentState;

    [Header("Logic")]
    public float timer, threshold;
    public float idleTime, wanderTime, panicTime, recoverTime, stunTime;
    public float wanderDistance;
    public string stateMessage;
    public bool variedTime;
    public float variation;
    public bool hasTarget;

    public GameObject sightIndicator;

    void Awake()
    {
        manager = mobInfo.manager;
        currentState = manager.currentState;
        if (variedTime)
        {
            idleTime = Random.Range(idleTime + -variation, idleTime + variation);
            wanderTime = Random.Range(wanderTime + -variation, wanderTime + variation);
            panicTime = Random.Range(wanderTime + -variation, wanderTime + variation);
            recoverTime = Random.Range(wanderTime + -variation, wanderTime + variation);
            stunTime = Random.Range(wanderTime + -variation, wanderTime + variation);
        }
    }

    void Update()
    {
        switch (mobInfo.mood)
        {
            case "normal":
                switch (currentState)
                {
                    /*-------------------------------------------------------*/
                    case dState_Idle:
                        timer += Time.deltaTime;
                        if (timer >= threshold)
                        {
                            timer = 0;
                            threshold = wanderTime;
                            manager.ChangeState(manager.state_Wander);
                        }
                        break;

                    /*-------------------------------------------------------*/
                    case dState_Wander:
                        timer += Time.deltaTime;
                        if (timer >= threshold)
                        {
                            timer = 0;
                            threshold = idleTime;
                            manager.ChangeState(manager.state_Idle);
                        }

                        break;

                    /*-------------------------------------------------------*/
                }
            break;

            case "panic":
                switch (currentState)
                {
                    /*-------------------------------------------------------*/
                    case dState_Idle:
                        timer = 0;
                        threshold = panicTime;
                        manager.ChangeState(manager.state_Panic);
                        break;

                    /*-------------------------------------------------------*/
                    case dState_Wander:
                        timer = 0;
                        threshold = panicTime;
                        manager.ChangeState(manager.state_Panic);
                        break;

                    /*-------------------------------------------------------*/
                    case dState_Panic:
                        if (!hasTarget)
                        {
                            timer += Time.deltaTime;
                            if (timer >= threshold)
                            {
                                timer = 0;
                                threshold = recoverTime;
                                manager.ChangeState(manager.state_Recover);
                            }
                        }
                        break;

                    /*-------------------------------------------------------*/
                    case dState_Recover:
                        timer += Time.deltaTime;
                        if (timer >= threshold)
                        {
                            timer = 0;
                            threshold = idleTime;
                            mobInfo.mood = "normal";
                            manager.ChangeState(manager.state_Idle);
                        }
                        break;

                    /*-------------------------------------------------------*/
                    case dState_Stun:
                        timer += Time.deltaTime;
                        if (timer >= threshold)
                        {
                            timer = 0;
                            threshold = recoverTime;
                            manager.ChangeState(manager.state_Recover);
                        }
                        break;

                        /*-------------------------------------------------------*/
                }
                break;

        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (mobInfo.debug) { print(mobInfo.mobName + " hit a " +  collision.gameObject.tag); }
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Mob")
        {
            if (mobInfo.mood == "panic") 
            {
                manager.ChangeState(manager.state_Stun);
            }
            else
            {
                manager.ChangeState(manager.state_Wander);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (mobInfo.debug) 
        { 
            print(mobInfo.mobName + " saw a " + other.gameObject.tag + " " + other.gameObject.name); 
            GameObject dot = Instantiate(sightIndicator, other.transform);
            dot.transform.parent = other.transform;
        }
        if (other.gameObject.tag == "Player")
        {
            hasTarget = true;
            mobInfo.mood = "panic";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (mobInfo.debug) { print(mobInfo.mobName + " the " + other.gameObject.tag + " " + other.gameObject.name + " is gone now"); }
        if (other.gameObject.tag == "Player")
        {
            hasTarget = false;
        }
    }
}
