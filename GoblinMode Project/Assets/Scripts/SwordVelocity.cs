using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SwordVelocity : MonoBehaviour
{
    private Vector3 OriginalPosition;
    public Vector2 swordVector;
    public int magnitudeOfVelocity;
    private GameObject player;

    public Sprite swordSprite0;
    public Sprite swordSprite2;
    public Sprite swordSprite3;

    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        player = GameObject.Find("Knight");
    }
 
    void FixedUpdate()
    {
        // Calculates sword speed
        swordVector = (transform.position - OriginalPosition).normalized;

        magnitudeOfVelocity = (int)((transform.position - OriginalPosition).magnitude / Time.deltaTime);

        OriginalPosition = transform.position;

        UpdateAnimation();   
    }

    void UpdateAnimation()
    {
        // Changes sword sprite - based on sword speed 
        if (magnitudeOfVelocity < 10 )
        {
            spriteRenderer.sprite = swordSprite0;
        }      
        if ((magnitudeOfVelocity >= 20))
        {
            spriteRenderer.sprite = swordSprite2;
        }
        if ((magnitudeOfVelocity >= 10) && (magnitudeOfVelocity < 20))
        {
            spriteRenderer.sprite = swordSprite3;
        }
        
        // Flips sword sprite to face direction of motion 
        float playerToSword = transform.position.y - player.transform.position.y;
        
        if (playerToSword < -1)
        {
            if (magnitudeOfVelocity >= 10)
            {
                if (swordVector.x < 0)
                {
                    spriteRenderer.flipX = false;
                }
                if (swordVector.x > 0)
                {
                    spriteRenderer.flipX = true;
                }
            }
        }
        if (playerToSword > 1)
        {
            if (magnitudeOfVelocity >= 10)
            {
                if (swordVector.x < 0)
                {
                    spriteRenderer.flipX = true;
                }
                if (swordVector.x > 0)
                {
                    spriteRenderer.flipX = false;
                }
            }
        }

        
        

    }
    

}
