using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Platform : MonoBehaviour
{
    public float jumpForce = 600f;
    public int currentScene;
    public ParticleSystem branchEffect;
    public AudioSource jumpSound;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // This if statment will check if player is coming from below or above, in this case its coming from below because the relative velocity on the y axis is less then 0.
        if (other.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rigi2d = other.collider.GetComponent<Rigidbody2D>();

            // If we collieded with something with a collider. 
            //rb != null means if rigidbody is not equal to null which means if rigidbody is collieded and did not return nothing.
            if (rigi2d != null)
            {
                // Getting the velocity of the object that collidied with this collider
                Vector2 velocity = rigi2d.velocity;
                // Medofiy the velocity
                velocity.y = jumpForce * Time.deltaTime;
                // Setting the velocity back to normal
                rigi2d.velocity = velocity;

                // Play Animation
                var jumpAnimation = other.gameObject.GetComponent<Animator>();
                jumpAnimation.SetTrigger("Jump");
                // Play partical effect
                branchEffect.Play();

                // Play bounce effect
                jumpSound.Play();

                // This will detach the branch from the tree
                if (currentScene == 2)
                {
                    Rigidbody2D branchRigi = GetComponent<Rigidbody2D>();
                    branchRigi.bodyType = RigidbodyType2D.Dynamic;
                }
            }
        }
    }
}
