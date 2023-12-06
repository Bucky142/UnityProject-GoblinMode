using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponRotateToCursor : MonoBehaviour
{
    private GameObject crosshair;
    public int rotationSpeed = 60;
    public int autoRotationSpeed = 60;

    // Start is called before the first frame update
    void Start()
    {
        crosshair = GameObject.Find("Crosshair");

        UnityEngine.Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        Vector2 playerTransform2D = transform.position;

        crosshair.transform.position = cursorPosition + playerTransform2D;

        if (Input.GetMouseButton(1))
        {
            transform.Rotate(0,0,autoRotationSpeed, Space.World);
        }
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(0, 0,-autoRotationSpeed, Space.Self);
        }
        if (!Input.GetMouseButton(1) && !Input.GetMouseButton(0))
        {
            float angle = Mathf.Atan2(cursorPosition.y, cursorPosition.x) * Mathf.Rad2Deg - 90f;

            Quaternion rotationVector = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotationVector, rotationSpeed * Time.deltaTime);

            

            
        }
       
    }
}
