using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Walk Settings")]
    public float movementSpeed = 5f;

    [Header("Jump Settings")]
    public float jumpVelocity = 3;
    public float jumpTime = 0.4f;

    private float currentJumpTime = 0;

    // Remembers that jump was pressed a moment after
    public float jumpRememberanceTime = 0.02f;
    [SerializeField]
    private float currentJumpRememberanceTime;

    [Header("Ground Detection")]

    public BoxCollider2D groundCollider;

    // Allows player to still count as on ground for a moment after leaving
    public float coyoteTime = 0.02f;
    [SerializeField]
    private float currentCoyoteTime;
    
    private bool onGround;

    private Rigidbody2D rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        // Vertical Movement
        onGround = groundCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
        currentCoyoteTime = onGround ? coyoteTime : (currentCoyoteTime > 0 ? currentCoyoteTime - Time.deltaTime : 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentJumpRememberanceTime = jumpRememberanceTime;
        }

        if (currentCoyoteTime > 0 && currentJumpRememberanceTime > 0)
        {
            currentJumpTime = jumpTime;
        }

        if (currentJumpTime > 0)
        {
            currentJumpTime -= Time.deltaTime;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpVelocity);
        }

        currentJumpRememberanceTime = currentJumpRememberanceTime > 0 ? currentJumpRememberanceTime - Time.deltaTime : 0;

        // Horizontal Movement
        float movement = Input.GetAxisRaw("Horizontal") * movementSpeed;
        
        rb.linearVelocity = new Vector2(movement, rb.linearVelocity.y);


    }
}
