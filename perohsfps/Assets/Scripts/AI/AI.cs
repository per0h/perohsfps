using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [SerializeField]
    private float health;

    private void Awake() 
    {

    }

    private void Update() 
    {
    }

    public void TakeDamage(float dmg) 
    {
        health -= dmg;
        Debug.Log("health: " + health);
    }
}
