using UnityEngine;

public class GrenadeGun : BaseWeapon
{
    public override void Fire()
    {
        base.Fire();

        GameObject bullet = PoolManager.instance.GetObject(PoolType.GrenadeBullet, firePoint.position);

        Vector3 force = firePoint.forward * weapon.bulletForce;

        bullet.transform.rotation = Quaternion.LookRotation(force) * Quaternion.Euler(0, 90, 90);
        bullet.GetComponent<Rigidbody>().velocity = force;
    }

    protected override void Awake()
    {
        base.Awake();
    }
}
