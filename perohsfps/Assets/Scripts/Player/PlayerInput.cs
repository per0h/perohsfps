using UnityEngine;

public class PlayerInput  : MonoBehaviour 
{
    [HideInInspector] public float x,y;
    [HideInInspector] public bool jumping, sprinting, crouching, shooting, drop, pickup;
    [SerializeField] public KeyCode pickupKey, dropKey;

    void Update() 
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        jumping = Input.GetButton("Jump");
        sprinting = Input.GetKey(KeyCode.LeftShift);
        crouching = Input.GetKey(KeyCode.LeftControl);
        shooting = Input.GetMouseButton(0);
        drop = Input.GetKey(dropKey);
        pickup = Input.GetKey(pickupKey);
    }
}
