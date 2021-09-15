using UnityEngine;
using UnityEngine.UI;

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

    [Header("Recoil")]
    public float initialKickback;

    [Header("Effects")]
    public string shootSound;
    public string reloadAudio;
    public Image muzzleFlashImage;
    public Sprite[] flashes; // Particle system?

    [Header("Ammo")]
    public int maxAmmoInMag;
    public int ammoInMag;
    public bool mag; // true if weapon has mag or has to be reloaded bullet by bullet
    public float reloadTime; // per mag or per bullet
}
