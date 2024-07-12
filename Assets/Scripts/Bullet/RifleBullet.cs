using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().stats.TakeDamage(PlayerManager.instance.player.currentWeapon.weapon.damage);
        }
        Destroy(gameObject);
    }
}
