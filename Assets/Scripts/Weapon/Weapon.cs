using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public WeaponType typeWeapon { get; private set; }
    public int damage { get; private set; }
    public float fireRate { get; private set; }
    public float bulletForce { get; protected set; }

    public Weapon(WeaponType typeWeapon, int damage, float fireRate, float bulletForce)
    {
        this.typeWeapon = typeWeapon;
        this.damage = damage;
        this.fireRate = fireRate;
        this.bulletForce = bulletForce;
    }
}
