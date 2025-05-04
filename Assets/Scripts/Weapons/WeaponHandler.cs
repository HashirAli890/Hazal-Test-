using System;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private Transform weaponMountPoint;
    [SerializeField] private GameObject defaultWeaponPrefab;

    private BaseWeapon currentWeapon;

    public static event Action<int, int> OnAmmoChanged; 

    private void Start()
    {
        if (defaultWeaponPrefab != null)
            EquipWeapon(defaultWeaponPrefab);
    }

    public void EquipWeapon(GameObject weaponPrefab)
    {
        
        foreach (Transform child in weaponMountPoint)
        {
            Destroy(child.gameObject);
        }

        
        GameObject weaponInstance = Instantiate(weaponPrefab, weaponMountPoint);
        currentWeapon = weaponInstance.GetComponent<BaseWeapon>();

        if (currentWeapon == null)
        {
            Debug.LogError("The weapon prefab does not contain a BaseWeapon-derived script.");
        }
        else
        {
            UpdateAmmoUI(); 
        }
    }

    public void TryFire()
    {
        if (currentWeapon != null && currentWeapon.CanFire)
        {
            currentWeapon.Fire();
            UpdateAmmoUI();
        }
    }

    public void TryReload()
    {
        currentWeapon?.Reload();
        UpdateAmmoUI();
    }

    private void UpdateAmmoUI()
    {
        if (currentWeapon != null && currentWeapon.weaponData != null)
        {
            OnAmmoChanged?.Invoke(currentWeapon.currentAmmo, currentWeapon.weaponData.ammoCapacity);
        }
    }


}
