using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    
    public Rigidbody2D rigidbody2D;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    
    private bool isJumping;
    public bool isGrounded;
    
    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        // crée une zone entre ces 2 éléments
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement);
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
    
}
