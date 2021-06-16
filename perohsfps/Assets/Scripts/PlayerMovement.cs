using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private PlayerInput pInput;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private float playerHeight;

    [Header("Movement")]
    public float moveSpeed;
    public float maxSpeed;
    public float movementMultiplier = 10f;
    public float airMultiplier = 0.5f;
    public float extraGravity = 10f;

    [Header("Jumping")]
    public float jumpForce = 8f;

    [Header("Ground Detection")]
    [SerializeField] LayerMask groundMask;
    bool isGrounded;
    float groundDistance = 0.4f;

    [Header("Drag")]
    public float groundDrag = 6f;
    public float airDrag = 2f;

    void Start()
    {
        pInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        //playerHeight = GetComponent<Collider>().bounds.size.y;
        //print("Player height = " + playerHeight);
    }

    void Update()
    {
        // Using transform.forward and transform.right to move where the player is looking
        moveDirection = transform.forward * pInput.y + transform.right * pInput.x;

        // Check if grounded
        // to-do: improve ground checks + add slope support
        isGrounded = Physics.CheckSphere(transform.position - new Vector3(0,1,0), groundDistance, groundMask);
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

        // Determine movement speed and directon, and multiply by air multiplier if player is not grounded
        Vector3 movement = moveDirection.normalized * moveSpeed * movementMultiplier;
        if (!isGrounded) { movement *= airMultiplier; }

        // Move
        rb.AddForce(movement, ForceMode.Acceleration);
    }
    private void ControlDrag(float grounddrag, float airdrag) 
    {
        if (isGrounded) { rb.drag = grounddrag; }
        else { rb.drag = airdrag; }
    }
}
