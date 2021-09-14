using System;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{

    [Header("Player")]
    public Transform playerHead;
    public Transform player;
    public PlayerMovement playerMovement;

    [Header("Mouse")]
    [Range(0.1f, 100f)]
    public float sens = 1f;
    public float sensMultiplier = 100f;
    float xRotation = 0f;

    [Header("Camera")]
    public Camera cam;
    [SerializeField] private float minFov = 90f;
    [SerializeField] private float maxFov = 115f;
    [SerializeField] private float FovSpeed = 0.11f;

    void Start() 
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Position camera in player
        gameObject.transform.position = playerHead.transform.position;

        Look();

        // Increase FOV if above x speed
        if (playerMovement.forwardSpeed > playerMovement.maxSpeed * 0.8)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, maxFov, FovSpeed);
        }
        else if (cam.fieldOfView > minFov)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, minFov, FovSpeed);
        }
    }

    private void Look() 
    {
        // Get mouse movement and multiply by sensitivity
        // Note: Apparently this doesn't need Time.deltatime
        Vector2 mouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * (sens*sensMultiplier);

        // Find current view rotation and add mouse movement
        float desiredX = gameObject.transform.localRotation.eulerAngles.y + mouse[0];
        
        xRotation -= mouse[1];
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, desiredX, 0f);
        player.transform.localRotation = Quaternion.Euler(0, desiredX, 0);
    }
}
