using UnityEngine;
using System.Collections;

public class AiGenerated_Enemy : MonoBehaviour
{
    public enum State { Idle, Wander, Chase }
    public State currentState;

    public float idleDuration = 2f;
    public float wanderSpeed = 3f;
    public float chaseSpeed = 6f;
    public float detectionRange = 10f;
    public float wanderRadius = 20f;

    private Transform player;
    private Vector3 wanderTarget;
    private float idleTimer;

    void Start()
    {
        currentState = State.Idle;
        player = GameObject.FindGameObjectWithTag("Player").transform; // Make sure the player has the "Player" tag
        idleTimer = idleDuration;
        StartCoroutine(StateMachine());
    }

    IEnumerator StateMachine()
    {
        while (true)
        {
            switch (currentState)
            {
                case State.Idle:
                    Idle();
                    break;
                case State.Wander:
                    Wander();
                    break;
                case State.Chase:
                    Chase();
                    break;
            }
            yield return null;
        }
    }

    void Idle()
    {
        idleTimer -= Time.deltaTime;
        if (idleTimer <= 0)
        {
            idleTimer = idleDuration;
            SetRandomWanderTarget();
            currentState = State.Wander;
        }
        DetectPlayer();
    }

    void Wander()
    {
        transform.position = Vector3.MoveTowards(transform.position, wanderTarget, wanderSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, wanderTarget) < 0.5f)
        {
            currentState = State.Idle;
        }
        DetectPlayer();
    }

    void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, player.position) > detectionRange)
        {
            currentState = State.Idle;
        }
    }

    void SetRandomWanderTarget()
    {
        Vector3 randomDirection = new Vector3(Random.Range(-wanderRadius, wanderRadius), 0, Random.Range(-wanderRadius, wanderRadius));
        wanderTarget = transform.position + randomDirection;
    }

    void DetectPlayer()
    {
        if (Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            currentState = State.Chase;
        }
    }
}