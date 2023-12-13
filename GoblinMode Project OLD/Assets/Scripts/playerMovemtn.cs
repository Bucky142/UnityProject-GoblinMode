using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovemtn : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    public Animator animator;
    public SpriteRenderer sprite;
    private GameObject crosshair;
    public int dashPower;
    public Vector2 forceToApply;
    private float forceDamping = 1.2f;


    [SerializeField] private float movementSpeed = 5f; 

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        crosshair = GameObject.Find("Crosshair");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        Vector2 moveForce = movementVector * movementSpeed;
        moveForce += forceToApply;
        forceToApply /= forceDamping;

        if (forceToApply.magnitude > 0.01f)
        {
            forceToApply = Vector2.zero;
        }
        playerRigidBody.velocity = moveForce;


        UpdateAnimation(movementVector, Input.GetAxisRaw("Horizontal"));  
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Vector2 crosshairVector = (crosshair.transform.position - transform.position).normalized;
            forceToApply = crosshairVector * dashPower;
            
        }
    }

    void UpdateAnimation(Vector2 movementVector, float horizontalMovementInput)
    {
        animator.SetFloat("Speed", Mathf.Abs(movementVector.magnitude));

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
