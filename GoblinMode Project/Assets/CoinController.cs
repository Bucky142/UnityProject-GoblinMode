using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CoinController : MonoBehaviour
{
    public float goldPickUpRange = 3;

    private Transform playerTransform;
    private Rigidbody2D coinRigidBody;
    private float movementSpeed = 4;
    private Vector2 movementVector;
    private float velocityDamping = 1.2f;
    private Vector2 startVelocity;
    private SetCounters SetCounters;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Knight").gameObject.GetComponent<Transform>();
        coinRigidBody = GetComponent<Rigidbody2D>();

        //generates starting velocity of coin 
        startVelocity = -10 * FindMovementVector() + (new Vector2(Random.Range(-1, 1), Random.Range(-1, 1) * 10));

        SetCounters = GameObject.Find("GameUI").GetComponent<SetCounters>();
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        float CoinToPlayerDistance = (playerTransform.position - gameObject.transform.position).magnitude;

        //decreases starting velocity  
        startVelocity /= velocityDamping;

        if (CoinToPlayerDistance <= goldPickUpRange)
        {
            movementVector = FindMovementVector();

            //add starting velocity 
            movementVector += startVelocity;

            //set starting velocity to zero if small
            if (startVelocity.magnitude <= 0.01f)
            {
                startVelocity = Vector2.zero;
            }

            coinRigidBody.velocity = movementVector;
        }
        else 
        {
            //reduce velocity 
            coinRigidBody.velocity /= velocityDamping;
            //set velocity to zero if small
            if(coinRigidBody.velocity.magnitude < 0.01)
            {
                coinRigidBody.velocity = Vector2.zero;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("ding");

            Destroy(gameObject);
            SetCounters.IncrementGoldCounter();
        }
    }
    

    Vector2 FindMovementVector()
    {
        Vector2 playerPosition = playerTransform.position;

        Vector2 coinPosition = gameObject.transform.position;

        movementVector = (playerPosition - coinPosition).normalized * movementSpeed;

        return movementVector;
    }
}










//using System.Linq;
//using UnityEngine;
//using UnityEngine.UIElements;

//public class CoinController : MonoBehaviour
//{
//    public GameObject[] coinsArray;
//    public Rigidbody2D[] coinRigidBodyArray;
//    public float goldPickUpRange = 5;
//    private Transform playerTransform;
//    // Start is called before the first frame update
//    void Start()
//    {
//        playerTransform = GameObject.Find("Knight").gameObject.GetComponent<Transform>();
//    }

//    public void addToCoinArrays(GameObject coinObject, Rigidbody2D coinRigidBody2D)
//    { 
//        coinsArray.Append(coinObject).ToArray();
//        coinRigidBodyArray.Append(coinRigidBody2D).ToArray();
//    } 
//    // Update is called once per frame
//    void Update()
//    {
//        for (int i = 0; i < coinsArray.Length; i++)
//        {
//            float CoinToPlayerDistance = (playerTransform.position - coinsArray[i].transform.position).magnitude;
//            Debug.Log(CoinToPlayerDistance);
//            if (CoinToPlayerDistance <= goldPickUpRange)
//            {

//                //float movementSpeed = (1 / CoinToPlayerDistance);
//                float movementSpeed = 2;
//                Vector2 playerPosition = playerTransform.position;

//                Vector2 coinPosition = coinsArray[i].transform.position;

//                Vector2 movementVector = (playerPosition - coinPosition).normalized * movementSpeed;

//                coinRigidBodyArray[i].velocity = movementVector;

//            }
//        }
//    }
//}
