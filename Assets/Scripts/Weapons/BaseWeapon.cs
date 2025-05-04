using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour, IWeapon
{
   public WeaponData weaponData;

    public int currentAmmo;
    protected float lastFireTime;

    protected virtual void Awake()
    {
        currentAmmo = weaponData.ammoCapacity;
    }

    public virtual void Fire()
    {
        if (!CanFire) return;
        UnityEngine.Debug.Log($"{currentAmmo}");
        currentAmmo--;
        lastFireTime = Time.time;
        OnFire();
    }

    protected abstract void OnFire();

    public virtual void Reload()
    {
        currentAmmo = weaponData.ammoCapacity;
    }

    public bool CanFire => Time.time >= lastFireTime + 1f / weaponData.fireRate && currentAmmo > 0;
}
