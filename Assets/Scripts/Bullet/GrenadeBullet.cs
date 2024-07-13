using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    [SerializeField] private float aoeRadius;
    [SerializeField] private ParticleSystem
        explorePrefab;
    [SerializeField] private LayerMask whatIsEnemy;
    private void OnTriggerEnter(Collider other)
    {
        Explode();
    }

    private void Explode()
    {
        Vector3 explodePos = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
        Instantiate(explorePrefab, explodePos, Quaternion.identity);
        Collider[] colliders = Physics.OverlapSphere(explodePos, aoeRadius, whatIsEnemy);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                hit.GetComponent<Enemy>().stats.TakeDamage(PlayerManager.instance.player.currentWeapon.weapon.damage);
            }
        }
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aoeRadius);
    }
}
