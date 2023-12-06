using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSFX : MonoBehaviour
{

    public AudioSource hit;
    public AudioSource die;

    private Death Death;
    // Start is called before the first frame update
    void Start()
    {
        Death = gameObject.GetComponent<Death>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeathSFX()
    {
        die.Play();
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<CircleCollider2D>());
        Destroy(GetComponent<GoblinMovement>());
        Destroy(gameObject.transform.GetChild(0).gameObject);
        Destroy(gameObject,3);

    }

    public void HitSFX()
    {
        hit.Play();
    }
}
