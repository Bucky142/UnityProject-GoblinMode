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
        // Auto swing sowrd 
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(0,0, autoSwingVelocity, Space.World);
        }
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(0, 0,-autoSwingVelocity, Space.World);
        }

        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        
        // Point Sword in direction of cursor 
        if (!Input.GetMouseButton(1) && !Input.GetMouseButton(0))
        {
            // calculates angle between cursor and center of screen 
            float angle = Mathf.Atan2(cursorPosition.y, cursorPosition.x) * Mathf.Rad2Deg - 90f;
            // caculates a rotation of (angle) degrees
            Quaternion rotationVector = Quaternion.AngleAxis(angle, Vector3.forward);
            // interpolates between staring angle and end angle 
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationVector, rotationSpeed * Time.deltaTime); 
        }

        // replace cursor
        Vector2 playerTransform2D = transform.position;
        crosshair.transform.position = cursorPosition + playerTransform2D;

    }
}
