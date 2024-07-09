using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Weapone Data", order = 1)]
public class WeaponSO : ScriptableObject
{
    [SerializeField] private WeaponType weaponType;
    [SerializeField] private int damage;
    [SerializeField] private float fireRate;
    [SerializeField] private float bulletForce;

    public Weapon GetData() => new Weapon(weaponType, damage, fireRate, bulletForce);
}
