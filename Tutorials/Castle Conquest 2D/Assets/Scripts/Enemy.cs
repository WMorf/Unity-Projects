using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemyRunSpeed = 5f;

    Rigidbody2D enemyRigidBody;
    Animator enemyAnimator;


    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        EnemyMovement();
    }

    public void Dying()
    {
        enemyAnimator.SetTrigger("Die");
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        enemyRigidBody.bodyType = RigidbodyType2D.Static;

        StartCoroutine(DestroyEnemy());
    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }

    private void EnemyMovement()
    {
        if (IsFacingLeft())
        {
            enemyRigidBody.velocity = new Vector2(-enemyRunSpeed, 0f);
        }
        else
        {
            enemyRigidBody.velocity = new Vector2(enemyRunSpeed, 0f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FlipSprite();
    }

    private void FlipSprite()
    {
        transform.localScale = new Vector2(Mathf.Sign(enemyRigidBody.velocity.x), 1f);
    }

    private bool IsFacingLeft()
    {
        return transform.localScale.x > 0;
    }
}
