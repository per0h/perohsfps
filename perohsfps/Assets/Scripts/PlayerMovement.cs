using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private PlayerInput pInput;
    public float jumpForce = 8f;
    private Rigidbody rb;
    bool grounded;

    void Start()
    {
        pInput = gameObject.GetComponent<PlayerInput>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (pInput.jumping) { Jump(); }

    }

    private void Jump() 
    {
        rb.AddForce(Vector3.up * 8);
    }

    private void checkIfGrounded() 
    {

    }

    private void Movement() 
    {
        
    }
}
