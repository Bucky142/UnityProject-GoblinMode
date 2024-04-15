using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CoinController : MonoBehaviour
{
    public float goldPickUpRange = 0.1f;

    private Transform playerTransform;
    private Rigidbody2D coinRigidBody;
    private float movementSpeed = 6;
    private Vector2 movementVector;
    private float velocityDamping = 1.2f;
    private Vector2 velocityToAdd;
    private SetCounters SetCounters;
    // Start is called before the first frame update
    void Start()
    {

        playerTransform = GameObject.Find("Knight").gameObject.GetComponent<Transform>();
        coinRigidBody = GetComponent<Rigidbody2D>();

        SetCounters = GameObject.Find("GameUI").GetComponent<SetCounters>();

        // generates starting velocity of coin 
        // opposite to player direction with some added noise 
        velocityToAdd = -30 * FindMovementVector().normalized + (new Vector2(Random.Range(-1, 1) * 10, Random.Range(-1, 1) * 10));
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float CoinToPlayerDistance = (playerTransform.position - gameObject.transform.position).magnitude;

        // decreases velocity to add each frame   
        velocityToAdd /= velocityDamping;

        // if player in range
        // add velocity to coin in direction of player 
        if (CoinToPlayerDistance <= goldPickUpRange)
        {
            movementVector = FindMovementVector();

            // add starting velocity 
            movementVector += velocityToAdd;

            // set starting velocity to zero if small
            if (velocityToAdd.magnitude <= 0.01f)
            {
                velocityToAdd = Vector2.zero;
            }

            coinRigidBody.velocity = movementVector;
        }
        // if player out of range 
        else
        {
            // reduce velocity 
            coinRigidBody.velocity /= velocityDamping;
            // set velocity to zero if small
            if (coinRigidBody.velocity.magnitude < 0.01)
            {
                coinRigidBody.velocity = Vector2.zero;
            }
        }
    }

    Vector2 FindMovementVector()
    {
        Vector2 playerPosition = playerTransform.position;

        Vector2 coinPosition = gameObject.transform.position;

        movementVector = (playerPosition - coinPosition).normalized * movementSpeed;

        return movementVector;
    }
    // if coin collide with player destroy coin and increment coin counter
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            SetCounters.IncrementGoldCounter();
        }
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
