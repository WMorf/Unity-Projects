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
    public float idleTime, wanderTime, panicTime, recoverTime;
    public float wanderDistance;
    public string stateMessage;
    public bool variedTime;
    public float variation;
    public string mood;
    public bool hasTarget;


    void Awake()
    {
        mood = mobInfo.mood;
        manager = mobInfo.manager;
        currentState = manager.currentState;
        if (variedTime)
        {
            idleTime = Random.Range(idleTime + -variation, idleTime + variation);
            wanderTime = Random.Range(wanderTime + -variation, wanderTime + variation);
            panicTime = Random.Range(wanderTime + -variation, wanderTime + variation);
            recoverTime = Random.Range(wanderTime + -variation, wanderTime + variation);
        }
    }

    void Update()
    {
        switch (mood)
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
                        print(1);
                        timer += Time.deltaTime;
                        if (timer >= threshold)
                        {
                            timer = 0;
                            threshold = idleTime;
                            mood = "normal";
                            manager.ChangeState(manager.state_Idle);
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
            manager.ChangeState(manager.state_Wander);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (mobInfo.debug) { print(mobInfo.mobName + " saw a " + other.gameObject.tag); }
        if (other.gameObject.tag == "Player")
        {
            hasTarget = true;
            mood = "panic";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (mobInfo.debug) { print(mobInfo.mobName + " the " + other.gameObject.tag + " is gone now"); }
        if (other.gameObject.tag == "Player")
        {
            hasTarget = false;
        }
    }
}