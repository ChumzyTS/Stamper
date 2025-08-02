using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField]
    private KeyCode jumpKey = KeyCode.Space;
    
    [SerializeField]
    private KeyCode glideKey = KeyCode.W;

    [SerializeField]
    private KeyCode stampKey = KeyCode.S;

    [SerializeField]
    private KeyCode respawnKey = KeyCode.R;

    [Header("Walk Settings")]
    public float movementSpeed = 5f;

    [SerializeField]
    private bool startsFacingRight;
    private bool facingRight;

    [Header("Jump Settings")]
    [SerializeField]
    private float jumpVelocity = 3;
    [SerializeField]
    private float jumpTime = 0.4f;
    [SerializeField]
    AudioClip jumpSFX;

    [SerializeField]
    [Min(0)]
    private int extraJumps;
    private int extraJumpsLeft;

    private float currentJumpTime = 0;

    private float jumpMult = 1;

    // Remembers that jump was pressed a moment after
    [SerializeField]
    private float jumpRememberanceTime = 0.02f;
    private float currentJumpRememberanceTime;

    [Header("Glide Settings")]

    [SerializeField]
    private Vector2 glideTrajectory;
    private bool gliding;
    private float glideTime;

    [SerializeField]
    [Min(1)]
    private float minGlideMult;
    [SerializeField]
    [Min(1)]
    private float maxGlideMult;
    [SerializeField]
    [Min(0.01f)]
    private float glideAccelerationTime;

    [SerializeField]
    private TrailRenderer glideTrail;

    [Header("Stamp Setting")]
    [SerializeField]
    [Min(0)]
    private float stampSpeed = 20;

    [SerializeField]
    [Min(0)]
    private float stampPauseTime;
    private float currentStampPauseTime;

    [SerializeField]
    [Min(0)]
    private float stampJumpWindow;
    [SerializeField]
    private float currentStampJumpWindow;

    [SerializeField]
    [Min(1)]
    private float stampJumpMult;

    private bool stamping;

    [SerializeField]
    private GameObject stampDecal;

    [SerializeField]
    AudioClip stampSFX;

    [Header("Ground Detection")]

    public BoxCollider2D groundCollider;
    

    [SerializeField]
    private float coyoteTime = 0.02f;
    private float currentCoyoteTime;
    private bool onGround;

    [Header("Idle Stuff")]
    [SerializeField]
    [Min(0)]
    private Vector2 idleTimeRange;
    [SerializeField]
    [Min(0)]
    private int idleAnimationCount;

    private float idleWaitTime;
    private float currentIdleWaitTime;
    private int idleNumber;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Animator animator;
    
    // respawn point
    public GameObject respawnAnchor;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        glideTrajectory = glideTrajectory.normalized;
        ChooseIdle();
    }

    public void Update()
    {
        
        // Walking Input
        float movement = Input.GetAxisRaw("Horizontal") * movementSpeed;
        facingRight = movement == 0 ? facingRight : movement > 0 != startsFacingRight;
        spriteRenderer.flipX = facingRight;

        animator.SetBool("Walking", movement != 0);

        // Jumping Input

        onGround = groundCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
        currentCoyoteTime = onGround ? coyoteTime : (currentCoyoteTime > 0 ? currentCoyoteTime - Time.deltaTime : 0);

        glideTrail.emitting = gliding;

        if (onGround && movement == 0)
        {
            currentIdleWaitTime -= Time.deltaTime;
            if (currentIdleWaitTime <= 0)
            {
                animator.SetInteger("RandomIdle", idleNumber);
                animator.SetTrigger("Idle");
                ChooseIdle();
            }
        }
        else
        {
            currentIdleWaitTime = idleWaitTime;
        }

        animator.SetBool("Falling", !onGround);

        animator.SetBool("Gliding", gliding);

        if (onGround)
        {
            if (stamping)
            {
                StopStamping(true);
            }
            if (gliding)
            {
                StopGliding();
            }
            extraJumpsLeft = extraJumps;
        }

        currentJumpRememberanceTime = currentJumpRememberanceTime > 0 ? currentJumpRememberanceTime - Time.deltaTime : 0;

        if (Input.GetKeyDown(jumpKey) && (currentCoyoteTime > 0 || extraJumpsLeft > 0 || currentStampJumpWindow > 0))
        {
            // Remember Jump
            rb.rotation = 0;
            currentJumpRememberanceTime = jumpRememberanceTime;
            jumpMult = 1;



            if (currentStampJumpWindow > 0)
            {
                // Stamp Boosted Jump
                SFXManager.Instance.PlaySFXClip(stampSFX, transform, 0.75f);
                currentStampJumpWindow = 0;
                jumpMult = stampJumpMult;
                GameObject newStampDecal = Instantiate(stampDecal);
                newStampDecal.transform.position = transform.position - new Vector3(0, 0.5f, 0);
                newStampDecal.GetComponent<ParticleSystem>().Emit(150);
            }

            StopStamping(false);
            StopGliding();
        }


        // Gliding
        if (Input.GetKeyDown(glideKey) && !onGround)
        {
            StopStamping(false);
            StartGliding();
        }
        if (Input.GetKeyUp(glideKey))
        {
            StopGliding();
        }

        if (Input.GetKeyDown(stampKey) && !onGround)
        {
            StartStamping();
        }

        if (stamping)
        {
            StampMovement();
        }
        else if (gliding)
        {
            GlideMovement(movement);
        }
        else
        {
            RegularMovement(movement);
        }

        // Respawn
        if (Input.GetKeyDown(respawnKey))
        {
            Respawn();
        }

        currentStampJumpWindow = currentStampJumpWindow > 0 ? currentStampJumpWindow - Time.deltaTime : currentStampJumpWindow;

    }

    // Stamp
    private void StartStamping()
    {
        StopGliding();
        stamping = true;
        currentStampPauseTime = stampPauseTime;
        animator.SetTrigger("Stamp");
    }

    private void StopStamping(bool jumpable)
    {
        stamping = false;
        currentStampJumpWindow = jumpable ? stampJumpWindow : 0;
    }

    private void StampMovement()
    {
        if (currentStampPauseTime <= 0)
        {
            rb.linearVelocity = new Vector2(0, -stampSpeed);
        }
        else
        {
            currentStampPauseTime -= Time.deltaTime;
            rb.linearVelocity = Vector2.zero;
        }
    }

    // Gliding
    private void GlideMovement(float movement)
    {
        glideTime += Time.deltaTime;
        rb.gravityScale = 0;

        float glideMult = math.lerp(movementSpeed * minGlideMult, movementSpeed * maxGlideMult, glideTime / glideAccelerationTime);

        if (movement != 0)
        {
            rb.linearVelocity = facingRight ? glideMult * glideTrajectory : glideMult * new Vector2(-glideTrajectory.x, glideTrajectory.y);
        }
        else
        {
            rb.linearVelocity = glideMult * new Vector2(0, glideTrajectory.y);
            glideTime = 0;
        }
    }

    private void StartGliding()
    {
        gliding = true;
        rb.gravityScale = 0;
        glideTime = 0;
    }

    private void StopGliding()
    {
        gliding = false;
        rb.gravityScale = 1;
        glideTime = 0;
    }

    // Other Movement
    private void RegularMovement(float movement)
    {
        if ((currentCoyoteTime > 0 || extraJumpsLeft > 0) && currentJumpRememberanceTime > 0)
        {
            // Jump!
            // play SFX?
            SFXManager.Instance.PlaySFXClip(jumpSFX, transform, 1f);
            Jump();
            animator.SetTrigger("Jump");
        }

        if (currentJumpTime > 0)
        {
            // Jumping
            currentJumpTime -= Time.deltaTime;
            rb.linearVelocityY = jumpVelocity * jumpMult;
        }

        // Movement
        rb.linearVelocityX = movement;
    }
    
    private void Jump()
    {
        currentJumpTime = jumpTime;
        currentJumpRememberanceTime = 0;

        if (currentCoyoteTime <= 0)
        {
            extraJumpsLeft--;
        }

        currentCoyoteTime = 0;
    }

    private void StopAllMovement()
    {
        StopGliding();
        StopStamping(false);
        currentJumpTime = 0;
        rb.linearVelocity = Vector2.zero;
    }

    public void Respawn()
    {
        if (respawnAnchor != null)
        {
            StopAllMovement();
            transform.position = respawnAnchor.transform.position;
        }

    }

    // Idle Stuff
    private void ChooseIdle()
    {
        idleWaitTime = math.lerp(idleTimeRange.x, idleTimeRange.y, UnityEngine.Random.Range(0f, 1f));
        idleNumber = UnityEngine.Random.Range(0, idleAnimationCount);
        currentIdleWaitTime = idleWaitTime;
    }


    // Debug Stuff
    public void OnDrawGizmos()
    {
        // Velocity Vector
        if (rb)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + (Vector3)rb.linearVelocity);
        }
    }
}
