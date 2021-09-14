using UnityEngine;

[System.Serializable]
public class Weapon : MonoBehaviour
{
    [Header("Info")]
    public int id;
    public string weaponName;
    public GameObject model;

    [Header("Stats")]
    public float damage;
    public float range = 100f;
    public float fireRate;
    public bool auto;

    [Header("Effects")]
    public AudioClip shootSound;
    public AudioClip reloadAudio;

    int maxAmmo;
    int ammoInMag;
    bool isReloading;
    bool canShoot;
}
