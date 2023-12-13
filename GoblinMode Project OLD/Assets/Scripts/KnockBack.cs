using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float knockBackValue;
    private SwordVelocity swordVelocity;
    

    private 
    // Start is called before the first frame update
    void Start()
    {
        swordVelocity = gameObject.GetComponent<SwordVelocity>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
}


