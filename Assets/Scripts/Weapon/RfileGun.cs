using UnityEngine;

public class RfileGun : BaseWeapon
{
    public override void Fire()
    {
        base.Fire();

        var bullet = PoolManager.instance.GetObject(PoolType.RifleBullet, firePoint.position);

        Vector3 force = firePoint.forward * weapon.bulletForce;

        bullet.transform.rotation = Quaternion.LookRotation(force) * Quaternion.Euler(0, 90, 90);
        bullet.GetComponent<Rigidbody>().velocity = force;
    }

    protected override void Awake()
    {
        base.Awake();
    }
}
