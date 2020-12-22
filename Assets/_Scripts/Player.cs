using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Variables")]
    public float pushForce;

    [Tooltip("This will be false if the player is dead. He will not be able to move if this is false")]
    public bool moveable = true; // This will be false if he is dead


    [Header("Cached Components")]
    private Rigidbody2D rb;
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        #region PC Controller Only
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        PC_Controller();
#endif
        #endregion
        PlayerController();
        FlipPlayer();
    }

    /// <summary>
    /// Only for PC controllers
    /// </summary>
    private void PC_Controller()
    {
        if (moveable)
        {
            float playerMovement = Input.GetAxis("Horizontal") * pushForce * 5;
            // declares the velocity
            Vector2 velocity = rb.velocity;
            // Modefies the velocity
            velocity.x = playerMovement * Time.deltaTime;
            // Rest the velocity
            rb.velocity = velocity;
        }
    }

    /// <summary>
    /// Controlls how the character moves
    /// </summary>
    private void PlayerController()
    {
        if (moveable)
        {
            // Gets the points in space of the touch position
            Vector2 touch = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            if (Input.touchCount > 0)
            {
                float touchMovement = touch.x * pushForce;

                Vector2 movementVelocity = new Vector2(touchMovement, 0f);
                rb.velocity += movementVelocity;

            }
        }
    }

    /// <summary>
    /// Flips the player depending on where it would be going
    /// </summary>
    private void FlipPlayer()
    {
        // Creates a bool whether the player has any horizontal movement at all, return true if it does
        bool playerHasHorizontalMovement = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalMovement)
        {
            // Sets the scale of the player to be a new vector2 where the x axis is equal to the sign (-1, +1) of the velocity on its x axis
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Destroyer"))
        {
            moveable = false;
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}
