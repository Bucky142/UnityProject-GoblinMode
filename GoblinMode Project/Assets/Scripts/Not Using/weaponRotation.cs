//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class weaponRotation : MonoBehaviour
//{
//    private Rigidbody2D weaponRigidBody;
//    private float weaponAngularVelocity;
//    // Start is called before the first frame update
//    void Start()
//    {
//        weaponRigidBody = GetComponent<Rigidbody2D>();
//        weaponAngularVelocity = weaponRigidBody.angularVelocity;
//    }

//    // Update is called once per frame
//    void Update()
//    {

//        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

//        //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

//        //float angle = Mathf.Tan(mousePosition.y / mousePosition.x);

//        //weaponAngularVelocity = angle;
//        //transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePosition - transform.position);


//        Vector2 cursorPosition = Input.mousePosition;
//        cursorPosition = Camera.main.ScreenToWorldPoint(cursorPosition);

//        Vector2 direction = new Vector2(cursorPosition.x - transform.position.x, cursorPosition.y - transform.position.y);

//        transform.up = direction;
//        float angle = Mathf.Tan(cursorPosition.y / cursorPosition.x) * Mathf.Rad2Deg;


//        transform.rotation = Quaternion.Euler(0, 0, angle / 100);
//    }
//}

////using System.Collections;
////using System.Collections.Generic;
////using UnityEngine;
////using static UnityEngine.GraphicsBuffer;

////public class weaponRotation : MonoBehaviour
////{
////    private Transform playerTransform;
////    private Rigidbody2D weaponRigidBody;
////    private float weaponAngularVelocity;
////    // Start is called before the first frame update
////    void Start()
////    {
////        playerTransform = GetComponent<Transform>();
////        weaponAngularVelocity = weaponRigidBody.angularVelocity;

////    }

////    // Update is called once per frame
////    void Update()
////    {
////        Vector2 mouse_pos = Input.mousePosition;
////        Vector2 object_pos = Camera.main.WorldToScreenPoint(playerTransform.position);
////        mouse_pos.x = mouse_pos.x - object_pos.x;
////        mouse_pos.y = mouse_pos.y - object_pos.y;
////        float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
////        transform.rotation = Quaternion.Euler(0, 0, angle);
////    }
////}
////using System.Collections;
////using System.Collections.Generic;
////using UnityEngine;

////public class weaponRotation : MonoBehaviour
////{
////    private Rigidbody2D weaponRigidBody;
////    private float weaponAngularVelocity;
////    private float pastAngle;



////    // Start is called before the first frame update
////    void Start()
////    {
////        weaponRigidBody = GetComponent<Rigidbody2D>();
////        weaponAngularVelocity = weaponRigidBody.angularVelocity;
////    }

////    // Update is called once per frame
////    void Update()
////    {

////        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

////        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

////        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;

////        weaponAngularVelocity = angle;

////        if (pastAngle != angle)
////        {
////            transform.Rotate(0, 0, angle);
////        }


////        pastAngle = angle;
////        //transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);


////        //Vector2 cursorPosition = Input.mousePosition;
////        //cursorPosition = Camera.main.ScreenToWorldPoint(cursorPosition);

////        //Vector2 direction = new Vector2(cursorPosition.x - transform.position.x, cursorPosition.y - transform.position.y);

////        //transform.up = direction;
////        // float angle = Mathf.Tan(cursorPosition.y/cursorPosition.x) * Mathf.Rad2Deg;


////        //transform.rotation = Quaternion.Euler(0, 0, angle/100);
////    }
////}