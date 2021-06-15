using UnityEngine;

public class PlayerInput  : MonoBehaviour 
{
    public float x,y;
    public bool jumping, sprinting, crouching;

    void Update() 
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        jumping = Input.GetButton("Jump");
        sprinting = Input.GetKey(KeyCode.LeftShift);
        crouching = Input.GetKey(KeyCode.LeftControl);
    }
}
