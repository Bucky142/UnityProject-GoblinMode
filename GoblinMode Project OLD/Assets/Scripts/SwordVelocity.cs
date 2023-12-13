using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SwordVelocity : MonoBehaviour
{
    Vector3 OriginalPosition;
    public int magnitudeOfVelocity;
    public Vector2 swordVector;
    private GameObject player;

    public Sprite swordSprite0;
    public Sprite swordSprite1;
    public Sprite swordSprite2;
    public Sprite swordSprite3;
    public Sprite swordSprite4;

    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        player = GameObject.Find("Knight");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        swordVector = (transform.position - OriginalPosition).normalized;

        magnitudeOfVelocity = (int)((transform.position - OriginalPosition).magnitude / Time.deltaTime);

        OriginalPosition = transform.position;

        UpdateAnimation();

        
    }

    void UpdateAnimation()
    {
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
        //if ((magnitudeOfVelocity >= 2) && (magnitudeOfVelocity < 5))
        //{
        //    spriteRenderer.sprite = swordSprite4;
        //}

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
