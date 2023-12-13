using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMeleeAttack : MonoBehaviour
{
    //GameObject weaponHitBox;
    //public float angle = 100f;
    //private GameObject swordPivot;
    //public int rotaionSpeed = 1;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    weaponHitBox = GameObject.Find("weaponHitBox");
    //    weaponHitBox.SetActive(false);
    //    swordPivot = GameObject.Find("SwordPivot");

    //}

    //// Update is called once per frame
    //void  Update()
    //{
        
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        // when m1 is clicked 

    //        // stop rotaion of weapon
    //        //Quaternion rotationVector = Quaternion.AngleAxis(angle - 90f, Vector3.forward);

    //        //swordPivot.transform.rotation = Quaternion.Slerp(swordPivot.transform.rotation, rotationVector, rotaionSpeed * Time.deltaTime);

    //        //StartCoroutine(Sleep(1));

    //        //Quaternion rotationVector2 = Quaternion.AngleAxis((angle * 3) - 90f, Vector3.forward);

    //        //swordPivot.transform.rotation = Quaternion.Slerp(swordPivot.transform.rotation,rotationVector2 , rotaionSpeed * 3 * Time.deltaTime);


    //        weaponHitBox.SetActive(true);
    //        StartCoroutine(Sleep(2));
            
    //    }

        

       
    //}
    //IEnumerator Sleep(int time)
    //{
    //   yield return new WaitForSeconds(time);
    //   Deactivate();
    //}

    //void Deactivate()
    //{
    //    weaponHitBox.SetActive(false);
    //}
}











//if (Input.GetMouseButtonDown(0))
//{
//    //float timer = 0;
//    //Debug.Log("m1 input");
//    //weaponHitBox.SetActive(true);
//    //Debug.Log(weaponHitBox.activeSelf);

//    //Debug.Log(timer);
//    //while (timer < 10)
//    //{
//    //    timer += Time.fixedDeltaTime;
//    //}

//    //Debug.Log(timer);
//    //if (timer >= 1)
//    //{
//    //    Debug.Log("time greater than 1 ");
//    //    weaponHitBox.SetActive(false);
//    //}
//    weaponHitBox.SetActive(true);
//    StartCoroutine(Sleep());


//}