using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "FPS/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public float damage;
    public float fireRate;
    public int ammoCapacity;
    public int currentAmmo;
    public float range;
    public GameObject projectilePrefab;
    public AudioClip fireSound;
}
