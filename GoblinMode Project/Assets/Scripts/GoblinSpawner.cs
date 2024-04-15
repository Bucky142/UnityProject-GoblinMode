using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class GoblinSpawner : MonoBehaviour
{
    
    public GameObject Goblin;
    private GameObject player;
    private Vector2 spawnPosition;

    public float spawnTime;
    private float currentSpawnTime;
    
    public float healthBarScale = 0.007f;
    private int RangeX;
    private int RangeY; 

    public GameObject healthBarCanvas;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Knight");
        currentSpawnTime = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpawnTime -= Time.deltaTime;

        // Instantiates Object and childen - healthbar object added above the goblin 
        if (currentSpawnTime <= 0)
        {
            GameObject goblinClone = Instantiate(Goblin, SpawnPosition(), new Quaternion(0, 0, 0, 0));   
            
            GameObject healthBarClone = Instantiate(healthBarCanvas);
            healthBarClone.transform.SetParent(goblinClone.transform);
            healthBarClone.transform.position = goblinClone.transform.position + new Vector3(0,0.6f,0);
            healthBarClone.transform.localScale = new Vector3(healthBarScale, healthBarScale, healthBarScale);

            // reduce the spawnTime of the goblins based on the time survived 
            if (spawnTime > 0.001)
            {
                spawnTime = spawnTime - Time.timeSinceLevelLoad / (100000 * 60);
            }
            currentSpawnTime = spawnTime;
        }
    }

    Vector2 SpawnPosition()
    {   // generate a point in a box of 24 width and height, centered at 0
        RangeX = Random.Range(12, -12);
        RangeY = Random.Range(12, -12);

        // X^2 + Y^2 = r^2 
        // is X^2 + Y^2 smaller than the radius^2 (106) of a circle 
        while (Mathf.Pow(RangeX, 2) + Mathf.Pow(RangeY, 2) < 106)
        {
            RangeX = Random.Range(12, -12);
            RangeY = Random.Range(12, -12);
        }
        // add generated point with player position
        spawnPosition = new Vector2(RangeX + player.transform.position.x, RangeY + player.transform.position.y);
        return spawnPosition;
    }
}
