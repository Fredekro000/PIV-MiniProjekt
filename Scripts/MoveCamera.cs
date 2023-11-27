using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DISCLAIMER!!! Not my script! 

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    private void FixedUpdate()
    {
        // makes the camera update its position to match the cameraPosition object
        // which sits on the player
        transform.position = cameraPosition.position;
    }
}
