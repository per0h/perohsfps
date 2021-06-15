using UnityEngine;

public class PlayerInput  : MonoBehaviour 
{
    [HideInInspector] public float x,y;
    [HideInInspector] public bool jumping, sprinting, crouching;

    void Update() 
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        jumping = Input.GetButton("Jump");
        sprinting = Input.GetKey(KeyCode.LeftShift);
        crouching = Input.GetKey(KeyCode.LeftControl);
    }
}
