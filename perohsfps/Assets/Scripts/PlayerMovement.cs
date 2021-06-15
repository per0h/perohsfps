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
        playerHeight = GetComponent<Collider>().bounds.size.y;
        print("Player height = " + playerHeight);
    }

    void Update()
    {
        // Using transform.forward and transform.right to move where the player is looking
        moveDirection = transform.forward * pInput.y + transform.right * pInput.x;

        // Check if grounded
        isGrounded = Physics.CheckSphere(transform.position - new Vector3(0,1,0), groundDistance, groundMask);

        // Jumping code
        if (pInput.jumping && isGrounded) { Jump(); }
    }

    void FixedUpdate() 
    {
        Movement();
        ControlDrag(groundDrag, airDrag);
    }

    private void Jump() 
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void Movement() 
    {
        // Extra gravity cuz stuff in unity is too floaty and I don't wanna mess with physics settings
        rb.AddForce(Vector3.down * Time.deltaTime * extraGravity);

        // Move
        rb.AddForce(moveDirection * moveSpeed, ForceMode.Acceleration);
    }
    private void ControlDrag(float grounddrag, float airdrag) 
    {
        if (isGrounded) { rb.drag = grounddrag; }
        else { rb.drag = airdrag; }
    }
}
