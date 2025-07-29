using System;
using Unity.Mathematics;
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
    private float currentJumpRememberanceTime;

    [Header("Flight Settings")]
    [SerializeField]
    [Min(0)]
    private float flightTime;
    [SerializeField]
    private float currentFlightTime;

    [SerializeField]
    [Min(0)]
    private float rotationSpeed;

    [SerializeField]
    [Min(0)]
    private float rotateLockTime = 0.1f;
    private float currentRotateLockTime;

    private Vector2 glideTrajectory;
    private bool gliding;

    [SerializeField]
    [Min(0)]
    private float boostMult;
    [SerializeField]
    [Min(0)]
    private float boostTime;
    private float currentBoostTime;

    [SerializeField]
    private bool hasBoost;

    

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
            rb.rotation = 0;
            gliding = false;
            rb.gravityScale = 1;
            currentFlightTime = flightTime;
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
                rb.linearVelocityY = jumpVelocity;
            }

            // Movement
            rb.linearVelocityX = movement;
        }

        currentJumpRememberanceTime = currentJumpRememberanceTime > 0 ? currentJumpRememberanceTime - Time.deltaTime : 0;

        // Gliding
        if (gliding && (currentFlightTime > 0 || currentBoostTime > 0))
        {
            rb.gravityScale = 0;

            float rotateDir = Input.GetAxisRaw("Horizontal");

            // Boost
            if (Input.GetKeyDown(KeyCode.Space) && hasBoost)
            {
                currentBoostTime = boostTime;
            }

            float speedMult = currentBoostTime > 0 ? boostMult : 1;

            if (currentRotateLockTime <= 0)
            {
                glideTrajectory = Quaternion.Euler(0, 0, -rotateDir * rotationSpeed * speedMult * Time.deltaTime) * glideTrajectory;
            }
            else
            {
                currentRotateLockTime -= Time.deltaTime;
                currentRotateLockTime = currentRotateLockTime < 0 ? 0 : currentRotateLockTime;
            }
            rb.linearVelocity = glideTrajectory * speedMult;

            /*
            if (!Input.GetKey(KeyCode.Space))
            {
                rb.rotation = 0;
                gliding = false;
                rb.gravityScale = 1;
            }
            */

            currentFlightTime -= Time.deltaTime;
            currentBoostTime -= Time.deltaTime;
        }
        else
        {
            rb.gravityScale = 1;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentCoyoteTime > 0 || currentFlightTime <= 0)
            {
                // Remember Jump
                rb.rotation = 0;
                gliding = false;
                rb.gravityScale = 1;
                currentJumpRememberanceTime = jumpRememberanceTime;
            }
            else
            {
                // Start Flying
                gliding = true;
                glideTrajectory = rb.linearVelocity.normalized * movementSpeed;
                rb.linearVelocity = glideTrajectory;
                currentRotateLockTime = rotateLockTime;
            }
        }
    }


    public void OnDrawGizmos()
    {
        // Velocity Vector
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)rb.linearVelocity);

        // Gliding Vectors
        if (gliding)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + (Vector3)glideTrajectory);
        }
    }
}
