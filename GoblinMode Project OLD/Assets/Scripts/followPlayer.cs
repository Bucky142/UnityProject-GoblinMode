using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    private Rigidbody2D goblinRigidBody2D;
    private Transform playerTransform;
    private float movementSpeed = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        goblinRigidBody2D = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.Find("Knight").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPosition = playerTransform.position;


        

        float horizontalDirection = (playerTransform.position.x - transform.position.x);
        float scaledHorizontalDirection = (horizontalDirection / ((int)horizontalDirection.ToString().Length * 10));

        float verticalDirection = (playerTransform.position.y - transform.position.y);
        float scaledVerticalDirection = (verticalDirection / ((int)verticalDirection.ToString().Length * 10));


        Vector2 movementVector = new Vector2(scaledHorizontalDirection, scaledVerticalDirection);

        goblinRigidBody2D.velocity = movementVector * movementSpeed;
    }
}
