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
        // distance travelled over time 
        magnitudeOfVelocity = (int)((transform.position - OriginalPosition).magnitude / Time.deltaTime);

        OriginalPosition = transform.position;

        UpdateAnimation();   
    }

    void UpdateAnimation()
    {
        // Changes sword sprite - based on sword speed / direction
        // change names -- spriteRenderer.sprite = swordSprite0; 
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
        float playerToSwordVerticalDistance = transform.position.y - player.transform.position.y;
        bool isSwordAbovePlayer;

        if (playerToSwordVerticalDistance < -1)
        {
            isSwordAbovePlayer = false;
        }
        else
        {
            isSwordAbovePlayer = true;
        }
        
        if (isSwordAbovePlayer == false)
        {
            if (magnitudeOfVelocity >= 10)
            {
                // set sprite left
                if (swordVector.x < 0)
                {
                    spriteRenderer.flipX = false;
                }
                //set sprite right
                if (swordVector.x > 0)
                {
                    spriteRenderer.flipX = true;
                }
            }
        }
        else 
        {           
            if (magnitudeOfVelocity >= 10)
            {
                // set sprite left
                if (swordVector.x < 0)
                {
                    spriteRenderer.flipX = true;
                }
                // set sprite right
                if (swordVector.x > 0)
                {
                    spriteRenderer.flipX = false;
                }
            }
        }
    }   
}
