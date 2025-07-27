using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 5f;
    private Rigidbody2D rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        float movement = Input.GetAxisRaw("Horizontal") * movementSpeed;

        rb.linearVelocity = new Vector2(movement, rb.linearVelocity.y);
    }
}
