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

    // Update is called once per frame
    void FixedUpdate()
    {
        

        movementVector = FindMovementVector();
        
        Vector2 moveForce = movementVector * movementSpeed;
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

        //this can be calculated much more simply and fixed the problem of the enemies moveing faster the further away they are from the player
                //float horizontalDirection = (playerTransform.position.x - transform.position.x);
                //float scaledHorizontalDirection = (horizontalDirection / ((int)horizontalDirection.ToString().Length * 10));

                //float verticalDirection = (playerTransform.position.y - transform.position.y);
                //float scaledVerticalDirection = (verticalDirection / ((int)verticalDirection.ToString().Length * 10));
                
                //movementVector = new Vector2(scaledHorizontalDirection, scaledVerticalDirection);

        //better version

        movementVector = (playerPosition - goboPosition).normalized;

        

        return movementVector;




    }
}