using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] Collider2D groundCheckColider;
    [SerializeField] float jumpDelay;
    float jumpTimer;
    InputSystem_Actions actions;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Vector2 vec;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        actions = new InputSystem_Actions();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocityX = vec.x;
        if (jumpTimer > 0)
            jumpTimer -= Time.deltaTime;
    }

    void OnEnable()
    {
        actions.Player.Move.performed += context =>
        {
            vec = context.ReadValue<Vector2>();
            vec.x *= moveSpeed;
            if (vec.x < 0)
                spriteRenderer.flipX = true;
            else
                spriteRenderer.flipX = false;
        };
        actions.Player.Move.canceled += constext =>
        {
            vec = Vector2.zero;
        };
        actions.Player.Move.Enable();

        actions.Player.Jump.performed += context =>
        {
            if (groundCheckColider.IsTouchingLayers() == false)
                return;
            if (jumpTimer > 0)
                return;

            rb.AddForceY(jumpForce);
            jumpTimer = jumpDelay;
        };
        actions.Player.Jump.Enable();
    }
    void OnDisable()
    {
        actions.Player.Move.Disable();
        actions.Player.Jump.Disable();
    }
}
