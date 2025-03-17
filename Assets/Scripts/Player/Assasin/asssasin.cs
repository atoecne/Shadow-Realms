using UnityEngine;

public class asssasin : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private float direction = 0f;
    private bool isFacingRight = true;

    private Rigidbody2D player;
    private Animator anim;

    public Transform groundCheck;     // ?i?m ki?m tra m?t ??t
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Ki?m tra có ?ang ch?m ??t không
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Nh?n input di chuy?n
        direction = Input.GetAxisRaw("Horizontal");

        // Di chuy?n nhân v?t
        player.linearVelocity = new Vector2(direction * moveSpeed, player.linearVelocity.y);

        // Xoay nhân v?t n?u c?n
        if (direction != 0)
            Flip();

        // X? lý nh?y
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            player.linearVelocity = new Vector2(player.linearVelocity.x, jumpForce);
        }

        // Set animation
        anim.SetFloat("Speed", Mathf.Abs(direction));
        anim.SetBool("isGrounded", isGrounded);
    }

    void Flip()
    {
        if ((isFacingRight && direction < 0) || (!isFacingRight && direction > 0))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1; // ??o chi?u
            transform.localScale = scale;
        }
    }

}
