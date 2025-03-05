using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    private bool isGrounded;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandlJump();
    }

    private void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput*moveSpeed, rb.linearVelocity.y);
        if(moveInput > 0)
        {
            transform.localScale = new Vector3(10, 10, 1);
        }else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-10, 10, 1);
        }
    }

    private void HandlJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,0.2f, groundLayer);
    }
}
