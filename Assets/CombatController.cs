using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : Damageable
{
    private Rigidbody2D rb;

    public float speed = 10f;

    public float jumpForce = 10f;

    public bool isGrounded = false;

    public virtual void Attack() { }

    // Declare the Movement() method as virtual and public
    public virtual void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public virtual void GroundCheck()
    {
        // Create a LayerMask variable and set it to the "Ground" and "Rigidbody2D" layers
        LayerMask groundMask = LayerMask.GetMask("Ground", "Rigidbody2D");

        // Use a Raycast to check if the object is colliding with the ground
        // Use the position of the player's feet as the starting point for the Raycast
        Vector2 startingPoint = new Vector2(transform.position.x, transform.position.y - 0.5f);
        // Use a longer Raycast to cover the area around the player's feet
        RaycastHit2D hit = Physics2D.Raycast(startingPoint, Vector2.down, 1f, groundMask);
        if (hit.collider != null && hit.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        GroundCheck();
        Movement();
    }
}