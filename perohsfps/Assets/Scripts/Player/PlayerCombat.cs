using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private PlayerInput playerInput;
    
    [SerializeField]
    private Transform cam;

    [SerializeField]
    public Weapon weapon;

    [SerializeField]
    private LayerMask mask;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (playerInput.shooting) 
        {
            Shoot();
        }
    }

    void Shoot() 
    {
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, 100f, mask)) 
        {
            Debug.Log("We hit " + _hit.collider.name);
        }
    }
}
