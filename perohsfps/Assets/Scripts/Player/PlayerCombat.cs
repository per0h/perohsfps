using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private PlayerInput playerInput;

    [Header("Raycasts")]
    [SerializeField] private Transform cam;
    [SerializeField] private LayerMask mask;
    [SerializeField] private LayerMask enemy;
    
    [Header("Player")]
    [SerializeField]
    private float health;

    [Header("Gun")]
    public Weapon weapon;
    public Transform viewModel;

    [Header("Misc")]
    public AudioManager audioManager;

    private bool canShoot = true;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (weapon.auto) 
        {
            if (playerInput.holdShooting) Shoot();
        }
        else 
        {
            // Used else to include punching
            /// Note: probably better to include punch as a weapon

            if (playerInput.shooting) Shoot();
        }
    }

    void Shoot() 
    {
        if (!canShoot) return;

        RaycastHit _hit;
        
        if (weapon != null) 
        {
            audioManager.Play(weapon.shootSound); // Gunshot
        
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, 100f, mask)) 
            {
                // Redesign this code when adding multiplayer

                Debug.Log("We hit " + _hit.collider.name);

                AI enemy = _hit.collider.GetComponent<AI>();
                if (enemy == null) 
                {
                    // effects when hitting scenery etc etc
                }
                else 
                {
                    enemy.TakeDamage(30f);
                }
            }
        }
        else 
        {
            // Punching?
            Debug.Log("No weapon");
        }

        canShoot = false;
        StartCoroutine(ShootDelay(weapon.fireRate)); // Delay between shots
    }

    IEnumerator ShootDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }
}
