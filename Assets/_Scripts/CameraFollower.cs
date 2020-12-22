using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.3f;
    public float offset = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (target.position.y > transform.position.y)
        {
            // Makes a vector3 position of a movement between two vectors at a set smoothness
            Vector2 newPos = Vector2.Lerp(new Vector2(0f, target.position.y), new Vector2(0f, transform.position.y), smoothSpeed);
            // Moves the current gameObject to the new position
            transform.position = newPos;
        }
    }
}
