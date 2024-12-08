using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    [SerializeField] private float aoeRadius;
    [SerializeField] private LayerMask whatIsEnemy;
    private void OnTriggerEnter(Collider other)
    {
        Explode();
    }

    private void Explode()
    {
        Vector3 explodePos = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
        PoolManager.instance.GetObject(PoolType.Explore, explodePos);
        Collider[] colliders = Physics.OverlapSphere(explodePos, aoeRadius, whatIsEnemy);
        foreach (var hit in colliders)
        {
            if (hit.TryGetComponent(out Enemy enemy))
            {
                enemy.stats.TakeDamage(PlayerManager.instance.player.currentWeapon.weapon.damage);
            }
        }
        PoolManager.instance.ReturnObject(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aoeRadius);
    }
}
