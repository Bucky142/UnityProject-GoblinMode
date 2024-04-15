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

    public Sprite stillSwordSprite;
    public Sprite movingSwordSprite;
    public Sprite fastMovingSwordSprite;

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
        if (magnitudeOfVelocity < 10 )
        {
            spriteRenderer.sprite = stillSwordSprite;
        }      
        if ((magnitudeOfVelocity >= 10) && (magnitudeOfVelocity < 20))
        {
            spriteRenderer.sprite = movingSwordSprite;
        }
        if ((magnitudeOfVelocity >= 20))
        {
            spriteRenderer.sprite = fastMovingSwordSprite;
        }

        // Flips sword sprite to face direction of motion 
        float playerToSwordVerticalDistance = transform.position.y - player.transform.position.y;
        bool isSwordAbovePlayer;

        if (playerToSwordVerticalDistance < 0)
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
                // set sprite right
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
