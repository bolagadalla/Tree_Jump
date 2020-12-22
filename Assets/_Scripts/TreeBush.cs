using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBush : MonoBehaviour
{
    private float jumpForce = 780f;

    /// <summary>
    /// This collision is for the player to jump up and down
    /// </summary>
    /// <param name="other">The other is the collider of the Bush</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.y <= 0f)
        {
            // Gets the rigidbody 2d of the other gameobject
            Rigidbody2D rb = other.collider.GetComponent<Rigidbody2D>();
            // If there is a rigidbody
            if (rb != null)
            {
                // Getting the velocity of the object that collidied with this collider
                Vector2 velocity = rb.velocity;
                // Medofiy the velocity
                velocity.y = jumpForce * Time.deltaTime;
                // Setting the velocity back to normal
                rb.velocity = velocity;
                // Play Jump Sound Effect \\
                // Play Particle Effect \\
            }
        }
    }
}
