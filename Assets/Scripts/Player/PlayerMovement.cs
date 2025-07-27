using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Walk Settings")]
    public float movementSpeed = 5f;

    [SerializeField]
    private bool startsFacingRight;
    private bool facingRight;

    [Header("Jump Settings")]
    public float jumpVelocity = 3;
    public float jumpTime = 0.4f;

    private float currentJumpTime = 0;

    // Remembers that jump was pressed a moment after
    public float jumpRememberanceTime = 0.02f;
    [SerializeField]
    private float currentJumpRememberanceTime;

    [Header("Glide Settings")]

    [SerializeField]
    [Min(0.1f)]
    private float initialGlideSpeed;

    [SerializeField]
    private Vector2 defaultGlideTrajectory = Vector2.right;
    private Vector2 glideTrajectory;
    private bool gliding;

    [Header("Ground Detection")]

    public BoxCollider2D groundCollider;

    // Allows player to still count as on ground for a moment after leaving
    public float coyoteTime = 0.02f;
    [SerializeField]
    private float currentCoyoteTime;
    [SerializeField]
    private bool onGround;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultGlideTrajectory = defaultGlideTrajectory.normalized;
    }

    public void Update()
    {
        // Walking Input
        float movement = Input.GetAxisRaw("Horizontal") * movementSpeed;
        if (!gliding)
        {
            facingRight = movement == 0 ? facingRight : movement > 0 != startsFacingRight;
            spriteRenderer.flipX = facingRight;
        }

        // Jumping Input
        onGround = groundCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
        currentCoyoteTime = onGround ? coyoteTime : (currentCoyoteTime > 0 ? currentCoyoteTime - Time.deltaTime : 0);

        if (onGround)
        {
            gliding = false;
            rb.gravityScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentCoyoteTime > 0)
            {
                // Remember Jump
                Debug.Log("JAUSDN");
                gliding = false;
                currentJumpRememberanceTime = jumpRememberanceTime;
            }
            else
            {
                // Start Gliding
                gliding = true;
                glideTrajectory = facingRight ? defaultGlideTrajectory : new Vector2(-defaultGlideTrajectory.x, defaultGlideTrajectory.y);
                glideTrajectory *= initialGlideSpeed;
            }
        }

        if (!gliding)
        {

            if (currentCoyoteTime > 0 && currentJumpRememberanceTime > 0)
            {
                // Jump!
                currentJumpTime = jumpTime;
                currentJumpRememberanceTime = 0;
                currentCoyoteTime = 0;
            }

            if (currentJumpTime > 0)
            {
                // Jumping
                currentJumpTime -= Time.deltaTime;
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpVelocity);
            }

            // Horizontal Movement
            rb.linearVelocity = new Vector2(movement, rb.linearVelocity.y);
        }

        currentJumpRememberanceTime = currentJumpRememberanceTime > 0 ? currentJumpRememberanceTime - Time.deltaTime : 0;

        // Gliding
        if (gliding)
        {
            rb.gravityScale = 0;
            rb.linearVelocity = glideTrajectory;
        }
    }

    public void OnDrawGizmos()
    {
        // Gliding Vectors
        if (gliding)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + (Vector3)glideTrajectory);
        }
    }
}
