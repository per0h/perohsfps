using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public Transform playerHead;
    public Transform player;

    [Range(0.1f, 100f)]
    public float sens = 1f;
    public float sensMultiplier = 100f;
    float xRotation = 0f;

    void Start() 
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Snap camera to player
        gameObject.transform.position = playerHead.transform.position;

        Look();
    }

    private void Look() 
    {
        // Get mouse movement and multiply by sensitivity
        // Note: Apparently this doesn't need Time.deltatime
        Vector2 mouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * (sens*sensMultiplier);

        // Find current view rotation and add mouse movement
        // Note: Could just put this on the rotation
        float desiredX = gameObject.transform.localRotation.eulerAngles.y + mouse[0];
        
        xRotation -= mouse[1];
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, desiredX, 0f);
        player.transform.localRotation = Quaternion.Euler(0, desiredX, 0);
    }
}
