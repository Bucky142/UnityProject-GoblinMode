using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float knockBackValue;
    private SwordVelocity swordVelocity;
    
    // Start is called before the first frame update
    void Start()
    {
        swordVelocity = gameObject.GetComponent<SwordVelocity>();
    }

    //when sword hits enemy apply knockback in direction the sword is moving 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (swordVelocity.magnitudeOfVelocity > 20)
        {
            if (collision.gameObject.tag == "enemy")
            {
                GoblinMovement goblinMovement = collision.gameObject.GetComponent<GoblinMovement>();

                goblinMovement.forceToApply = swordVelocity.swordVector * knockBackValue;   
            }
        }
    }

    // WORKING 
    // knockes enemy backwards
            //private void OnTriggerEnter2D(Collider2D collision)
            //{

            //    if (swordVelocity.magnitudeOfVelocity > 20)
            //    {
            

            //        if (collision.gameObject.tag == "enemy")
            //        {
            //            GoblinMovement goblinMovement = collision.gameObject.GetComponent<GoblinMovement>();

            //            goblinMovement.forceToApply = -goblinMovement.movementVector * knockBackValue;

            //            Debug.Log(goblinMovement.forceToApply+"-----------------------------------------------------------");
            //        }
            //    }
       
            //}

    
}


