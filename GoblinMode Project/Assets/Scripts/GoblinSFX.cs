using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSFX : MonoBehaviour
{
    public AudioSource hit;
    public AudioSource die;
    public void DeathSFX()
    {
        die.Play();
        // remove physical components of goblin
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<CircleCollider2D>());
        Destroy(GetComponent<GoblinMovement>());
        Destroy(gameObject.transform.GetChild(0).gameObject);
        // destroy gameObject after SFX have finished 
        Destroy(gameObject,3);
    }

    public void HitSFX()
    {
        hit.Play();
    }
}
