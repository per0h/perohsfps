using UnityEngine;

public class PlayerInput  : MonoBehaviour 
{
    [HideInInspector] public float x,y;
    [HideInInspector] public bool jumping, sprinting, crouching, shooting, holdShooting, drop, pickup, reload;
    [SerializeField] public KeyCode pickupKey, dropKey, reloadKey;

    void Update() 
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        jumping = Input.GetButton("Jump");
        sprinting = Input.GetKey(KeyCode.LeftShift);
        crouching = Input.GetKey(KeyCode.LeftControl);
        holdShooting = Input.GetMouseButton(0); // Auto fire
        shooting = Input.GetMouseButtonDown(0); // Semi fire
        drop = Input.GetKey(dropKey);
        pickup = Input.GetKey(pickupKey);
        reload = Input.GetKey(reloadKey);
    }
}
