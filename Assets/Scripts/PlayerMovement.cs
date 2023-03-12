using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    
    public Rigidbody2D rigidbody2D;
    public Animator animator;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public SpriteRenderer spriteRenderer;
    
    private bool isJumping;
    public bool isGrounded;
    
    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        // crée une zone entre ces 2 éléments
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement);
        
        Flip(rigidbody2D.velocity.x);
        animator.SetFloat("Speed", Math.Abs(rigidbody2D.velocity.x));
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
            isJumping = true;
    }

    void MovePlayer(float horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(horizontalMovement, rigidbody2D.velocity.y);
        rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping)
        {
            rigidbody2D.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    private void Flip(float velocityX)
    {
        if (velocityX > 0.1f)
            spriteRenderer.flipX = false;
        else if(velocityX < -0.1f)
            spriteRenderer.flipX = true;
    }
}
