using UnityEngine;

public class RifleBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.stats.TakeDamage(PlayerManager.instance.player.currentWeapon.weapon.damage);
        }
        PoolManager.instance.ReturnObject(gameObject);
    }
}
