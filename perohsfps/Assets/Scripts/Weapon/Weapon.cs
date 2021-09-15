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
    public AnimationClip muzzleFlash;
    public Vector3 muzzleOffset;

    [Header("Ammo")]
    public int maxAmmoInMag;
    [HideInInspector] public int ammoInMag;
    public bool hasMag; // true if weapon has mag or has to be reloaded bullet by bullet
    public float reloadTime; // per mag or per bullet
    [HideInInspector] public bool isReloading;
}
