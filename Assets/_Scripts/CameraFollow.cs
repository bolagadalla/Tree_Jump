using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.3f;

    // LateUpdate is called after Update. Runs after everything is settled with animationa and so one
    void LateUpdate()
    {
        // If the target position on the y is greater then the camera(whatever gameobject this script is attached to) position on the y, then ...
        if (target.position.y > transform.position.y)
        {
            // Make a new vector3 position where every axis is the same, but the y axis will equal to the target y axies
            Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
            // Move this object to the new position
            transform.position = newPos;
        }
    }
}
