using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponSwing : MonoBehaviour
{
    private GameObject crosshair;
    public int rotationSpeed = 60;
    public int autoSwingVelocity = 60;

    // Start is called before the first frame update
    void Start()
    {
        crosshair = GameObject.Find("Crosshair");

        UnityEngine.Cursor.visible = false;
    }

    void FixedUpdate()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector2 playerTransform2D = transform.position;
        
        // Ingame cursor
        crosshair.transform.position = cursorPosition + playerTransform2D;
        // Auto swing sowrd 
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(0,0, autoSwingVelocity, Space.World);
        }
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(0, 0,-autoSwingVelocity, Space.Self);
        }

        // Point Sword in direction of cursor 
        if (!Input.GetMouseButton(1) && !Input.GetMouseButton(0))
        {
            float angle = Mathf.Atan2(cursorPosition.y, cursorPosition.x) * Mathf.Rad2Deg - 90f;

            Quaternion rotationVector = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotationVector, rotationSpeed * Time.deltaTime); 
        }
       
    }
}
