using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeGun : BaseWeapon
{
    public override void Fire()
    {
        base.Fire();
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = firePoint.position;

        Vector3 force = firePoint.forward * weapon.bulletForce;

        bullet.transform.rotation = Quaternion.LookRotation(force) * Quaternion.Euler(0, 90, 90);
        bullet.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    }

    protected override void Start()
    {
        base.Start();
    }
}