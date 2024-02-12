using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GoblinSpawner : MonoBehaviour
{
    
    public GameObject Goblin;
    private GameObject player;
    private Vector2 spawnPosition;

    public float spawnTime;
    private float currentSpawnTime;
    
    public float healthBarScale = 0.007f;
    float RangeX = 0;
    float RangeY = 0;

    float radiusSquared = Mathf.Pow(15, 2) + Mathf.Pow(15, 2);
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

        
        

        //position = new Vector2(Mathf.Pow(RangeX,2), RangeYSquared);

        // Creates a random position in around the player 
        //position = new Vector3(Random.Range(RangeX, RangeX + Random.Range(5, -5)), Random.Range(RangeY, RangeY + Random.Range(5,-5)));

        currentSpawnTime -= Time.deltaTime;

        // Instantiates Object and childen
        if (currentSpawnTime <= 0)
        {
            GameObject goblinClone = Instantiate(Goblin, SpawnPosition(), new Quaternion(0, 0, 0, 0));   
            
            GameObject healthBarClone = Instantiate(healthBarCanvas);
            healthBarClone.transform.SetParent(goblinClone.transform);
            healthBarClone.transform.position = goblinClone.transform.position + new Vector3(0,0.6f,0);
            healthBarClone.transform.localScale = new Vector3(healthBarScale, healthBarScale, healthBarScale);

            if (spawnTime > 0.001)
            {
                spawnTime = spawnTime - Time.timeSinceLevelLoad / (100000 * 60);
            }
            currentSpawnTime = spawnTime;
        }
    }

    Vector2 SpawnPosition()
    {
        RangeX = Random.Range(15, -15);
        RangeY = Random.Range(15, -15);
        // X^2 + Y^2 = r^2
        while (Mathf.Pow(RangeX, 2) + Mathf.Pow(RangeY, 2) > radiusSquared)
        {
            RangeX = Random.Range(15, -15);
            RangeY = Random.Range(15, -15);
            while (Mathf.Pow(RangeX, 2) + Mathf.Pow(RangeY, 2) < 25)
            {
                RangeX = Random.Range(15, -15);
                RangeY = Random.Range(15, -15);
            }
        }
        spawnPosition = new Vector2(RangeX + player.transform.position.x, RangeY + player.transform.position.y);
        return spawnPosition;
    }
}
