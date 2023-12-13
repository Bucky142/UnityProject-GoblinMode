using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class GoblinSpawner : MonoBehaviour
{
    
    public GameObject Goblin;
    private GameObject player;
    private Vector3 position;

    public float spawnTime;
    private float currentSpawnTime;

    public float healthBarScale = 0.007f;

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
        float RangeX = player.transform.position.x + Random.Range(5, -5);
        float RangeY = player.transform.position.y + Random.Range(5, -5);
        // Creates a random position in around the player 
        position = new Vector3(Random.Range(RangeX, RangeX + Random.Range(5, -5)), Random.Range(RangeY, RangeY + Random.Range(5,-5)));

        currentSpawnTime -= Time.deltaTime;

        // Instantiates Object and childen
        if (currentSpawnTime <= 0)
        {
            GameObject goblinClone = Instantiate(Goblin, position, new Quaternion(0, 0, 0, 0));   
            
            GameObject healthBarClone = Instantiate(healthBarCanvas);
            healthBarClone.transform.SetParent(goblinClone.transform);
            healthBarClone.transform.position = goblinClone.transform.position + new Vector3(0,0.6f,0);
            healthBarClone.transform.localScale = new Vector3(healthBarScale, healthBarScale, healthBarScale);

            currentSpawnTime = spawnTime;
        }
    }
}
