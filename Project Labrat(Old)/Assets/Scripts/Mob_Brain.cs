using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Brain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {


    /*--------------------------------------------------------*/
    /*-----------------Switches and Logic---------------------*/
        switch(curState)
        {


    /*----------------------------------------------------------------------------*/

        case State.Idle:
        
            if(idleTick)
            {
                anim.SetBool("isMoving", false);
                if(showEmoteDebug) { Debug.Log("I am bored"); }
                
                idleCounter -= Time.deltaTime;

                lastState = curState;
                curState = State.Ready;


            }
            break;
    /*----------------------------------------------------------------------------*/
        case State.Wander:
            
            if(wanderTick)
            {

                if(showEmoteDebug) { Debug.Log("I'm the kind of sprite, who likes to roam around"); }

                if(!wanderTrip)
                {
                    moveDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
                    wanderTrip = true;
                }

                wanderCounter -= Time.deltaTime;
                
                Move();

                lastState = curState;
                curState = State.Ready;
            }

            break;
    }
}
