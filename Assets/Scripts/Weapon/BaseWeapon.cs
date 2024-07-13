using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    [SerializeField] protected WeaponSO weaponData;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform firePoint;
    public Weapon weapon { get; private set; }

    protected virtual void Awake()
    {
        InitializeWeapon();
    }

    public void InitializeWeapon()
    {
        weapon = weaponData.GetData();
    }

    public virtual void Fire()
    {
    }
}
