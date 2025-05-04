using System.Diagnostics;
using UnityEngine;

public class RaycastWeapon : BaseWeapon
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private ParticleSystem muzzleFlash;

    protected override void OnFire()
    {
       UnityEngine.Debug.Log("Shooting");

        if (muzzleFlash != null)
          muzzleFlash.Play();
      

        if (Physics.Raycast(firePoint.position, firePoint.forward, out RaycastHit hit, weaponData.range))
        {
           
            if (hit.collider.TryGetComponent<IDamageable>(out var damageable))
                damageable.TakeDamage(weaponData.damage);
        }
    }
}
