using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    public Animator animator;
    public SpriteRenderer sprite;
    private GameObject crosshair;
    public int dashPower;
    public Vector2 forceToApply;
    private float forceDamping = 1.2f;
    public float movementSpeed = 5f; 

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        crosshair = GameObject.Find("Crosshair");
    }

    void FixedUpdate()
    {
        // Handles base movement - W, A, S, D 
        Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Vector2 moveForce = movementVector * movementSpeed;

        // Handles forces that apply to the player -- "KnockBack" and "Abilities" 

        //adds knockback to movementVector
        moveForce += forceToApply;

        //decreases forceToApply 
        forceToApply /= forceDamping;

        // sets forceToApply to 0 if very small 
        if (forceToApply.magnitude <= 0.01f)
        {
            forceToApply = Vector2.zero;
        }
        playerRigidBody.velocity = moveForce;


        UpdateAnimation(movementVector, Input.GetAxisRaw("Horizontal"));  
    }

    void Update()
    {
        // Player dash
        if (Input.GetKeyDown("space"))
        {
            Vector2 crosshairVector = (crosshair.transform.position - transform.position).normalized;
            forceToApply = crosshairVector * dashPower;
            
        }
    }

    void UpdateAnimation(Vector2 movementVector, float horizontalMovementInput)
    {
        // Updates value in Player animation controller
        // If player is moveing then play run animation 
        animator.SetFloat("Speed", Mathf.Abs(movementVector.magnitude));

        // Faces the player in the direction of movement 
        if (horizontalMovementInput < 0)
        {
            sprite.flipX = true;
        }
        if (horizontalMovementInput > 0) 
        {
            sprite.flipX= false;
        }
    }

}
