using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoboAttack : MonoBehaviour
{
    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.Find("Knight").gameObject.GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.takeDamage(Random.Range(5, 15));
        }
        
    }
}
