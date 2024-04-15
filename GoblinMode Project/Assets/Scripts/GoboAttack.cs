using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GoboAttack : MonoBehaviour
{
    private PlayerHealth playerHealth;
    public Animator animator;
    public float attackRange;
    private float distanceToPlayer;
    private Transform playerTransform;
    private float VerticalDistanceToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Knight").gameObject.GetComponent<Transform>();
        playerHealth = GameObject.Find("Knight").gameObject.GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(Random.Range(5, 15));
        }
    }

    void FixedUpdate()
    {
        distanceToPlayer = (playerTransform.position - transform.position).magnitude;
        //plays attack animation if goblin is in range 
        if (distanceToPlayer < attackRange)
        {
            animator.SetBool("inAttackRange", true);
        }
        else
        {
            animator.SetBool("inAttackRange", false);
        }

        VerticalDistanceToPlayer = playerTransform.position.y - transform.position.y;

        //sets direction of attack animation
        //is player above or below player 
        if (VerticalDistanceToPlayer < 0)
        {
            animator.SetBool("isPlayerAboveGoblin", false);
        }
        else
        {
            animator.SetBool("isPlayerAboveGoblin", true);
        }
    }
}
