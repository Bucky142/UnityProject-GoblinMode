using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMovement : MonoBehaviour
{
    
    private SpriteRenderer sprite;
    private Rigidbody2D goblinRigidBody2D;
    private Transform playerTransform;   
    public float movementSpeed = 100f;
    public Vector2 movementVector;
    public Vector2 forceToApply;
    public float forceDamping = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        
        goblinRigidBody2D = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.Find("Knight").transform;
        sprite = GetComponent<SpriteRenderer>();
    }

    
    void FixedUpdate()
    {
        movementVector = FindMovementVector();
        
        Vector2 moveForce = movementVector * movementSpeed;

        // Handles forces that apply to the player -- "KnockBack" and "Abilities" 
        moveForce += forceToApply;
        forceToApply /= forceDamping;
        
        if (forceToApply.magnitude <= 0.01f)
        {
            forceToApply = Vector2.zero;
        }
        goblinRigidBody2D.velocity = moveForce; 

        LookDirection(movementVector);
    }

    
    void LookDirection(Vector2 movemetVector)
    {       
        if (movemetVector.x < 0)
        {
            sprite.flipX = true;
        }
        if (movemetVector.x > 0)
        {
            sprite.flipX = false;               
        }       
    }
    
    Vector2 FindMovementVector()
    {   
        Vector2 playerPosition = playerTransform.position;

        Vector2 goboPosition = transform.position;

        movementVector = (playerPosition - goboPosition).normalized;

        return movementVector;
    }
}