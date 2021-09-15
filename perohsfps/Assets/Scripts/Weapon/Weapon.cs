using UnityEngine;

// https://youtu.be/aPXvoWVabPY (Scriptable objects guide)

[CreateAssetMenu(fileName = "New weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    [Header("Info")]
    public int id;
    public new string name;
    public GameObject model;

    [Header("Stats")]
    public float damage;
    public float range;
    public float fireRate;
    public bool auto;

    [Header("Effects")]
    public string shootSound;
    public string reloadAudio;

    int maxAmmo;
    int ammoInMag;
    bool isReloading;
}
