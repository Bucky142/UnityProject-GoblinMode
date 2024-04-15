using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    private int health = 100;
    public Slider healthBar;
    private GameObject GameOver;

    private void Start()
    {
        GameOver = GameObject.Find("GameOverScreen");
        GameOver.SetActive(false);  
    }
    public void TakeDamage(int damage)
    { 
        health -= damage;

        healthBar.value = health;

        if (health <= 0)
        {
            Time.timeScale = 0;
            GameOver.SetActive(true);
            UnityEngine.Cursor.visible = true;
        }
    }
}
