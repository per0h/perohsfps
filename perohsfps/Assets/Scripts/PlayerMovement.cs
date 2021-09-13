using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private PlayerInput pInput;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private float playerHeight;

    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    public float movementMultiplier = 10f;
    public float airMultiplier = 0.5f;
    public float extraGravity = 10f;

    [Header("Sprinting")]
    public float walkSpeed = 5f;
    public float sprintSpeed;
    public float acceleration;
    public float maxSpeed;

    [Header("Jumping")]
    public float jumpForce = 8f;

    [Header("Ground Detection")]
    public Transform groundCheck;
    public LayerMask groundMask;
    bool isGrounded;
    float groundDistance = 0.4f;

    [Header("Drag")]
    public float groundDrag = 6f;
    public float airDrag = 2f;

    [Header("Slope")]
    private Vector3 slopeMoveDirection;
    private RaycastHit slopeHit;

    void Start()
    {
        pInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        playerHeight = GetComponent<Collider>().bounds.size.y;
    }

    void Update()
    {
        // Using transform.forward and transform.right to move where the player is looking
        moveDirection = transform.forward * pInput.y + transform.right * pInput.x;

        // Check if grounded
        // to-do: improve ground checks + add slope support
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // to-do: move this to a better place instead of straight up update
        slopeMoveDirection = Vector3.ProjectOnPlane(moveDirection, slopeHit.normal);

        OnSlope();
    }

    void FixedUpdate() 
    {
        // Movement (duh)
        Movement();

        // Change drag when on air vs on ground
        ControlDrag(groundDrag, airDrag);

        // Jumping (obviously)
        if (pInput.jumping && isGrounded) { Jump(); }
    }

    private void Jump() 
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void Movement() 
    {
        // Extra gravity cuz stuff in unity is too floaty and I don't wanna mess with physics settings
        rb.AddForce(Vector3.down * Time.deltaTime * extraGravity);

        // Control walking/sprinting
        ControlSpeed();

        // Determine movement speed and directon, and multiply by air multiplier if player is not grounded
        // note: clean this
        Vector3 movement;
        if(isGrounded && !OnSlope()) { movement = moveDirection.normalized * moveSpeed * movementMultiplier; }
        else if (isGrounded && OnSlope()) { movement = slopeMoveDirection.normalized * moveSpeed * movementMultiplier; }
        else { movement = moveDirection.normalized * moveSpeed * movementMultiplier * airMultiplier; }

        // Move
        rb.AddForce(movement, ForceMode.Acceleration);
    }

    private void ControlSpeed() 
    {
        if (pInput.sprinting && isGrounded)
        {
            moveSpeed = Mathf.Lerp(moveSpeed, sprintSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, acceleration * Time.deltaTime);
        }
    }
    private void ControlDrag(float grounddrag, float airdrag) 
    {
        if (isGrounded) { rb.drag = grounddrag; }
        else { rb.drag = airdrag; }
    }

    private bool OnSlope() 
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight / 2 + 0.5f)) 
        {
            if (slopeHit.normal != Vector3.up) 
            {
                return true;
            }
            return false;
        }
        return false;
    }
}
