using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DISCLAIMER!!! Not my script! 

public class PlayerCamera : MonoBehaviour
{
    // Sets important varibles to be used later
    public float sensX;
    public float sensY;
    
    public Transform orientation;
    
    float xRotation;
    float yRotation;

    private void Start()
    {
        // Locks the cursor to the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // This records the players raw mouse movement, so essentially the camera
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY;
        
        // updates the rotation around the x and y axis based on horizontal and vertical movement
        yRotation += mouseX;
        xRotation -= mouseY;
        
        // Clamp the vertical rotation to ensure it stays within a certain range
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        // updates the rotation of the GameObject and orientation gameobject to the new Euler angles
        // which is calculated from the vertical and horizontal rotations. The orientation object only 
        // gets updated to rotate around the y axis.
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}
