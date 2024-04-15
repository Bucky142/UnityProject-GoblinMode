using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
    public GameObject Coin;
    private Transform dropTransform;
    private Rigidbody2D coinRigidBody2D;
    private CoinController coinController;

    private void Start()
    {
        coinController = gameObject.GetComponent<CoinController>();
    }
    public void DropGold(Transform enemyTransform)
    {
        
        int goldDropChance = 50; // 1% - 100%
        int rand = Random.Range(1, 100);

        if (rand <= goldDropChance)
        {
            GameObject coinClone = Instantiate(Coin, gameObject.transform);
            
            coinClone.transform.position = enemyTransform.position;

            //chance for dropping multiple coins 
            DropGold(enemyTransform);
        }
    }
}
