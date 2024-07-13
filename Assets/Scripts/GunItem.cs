using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Transform itemParentPos;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SwitchGun();
            Destroy(gameObject);
        }
    }

    private void SwitchGun()
    {
        BaseWeapon currentGunScript = itemParentPos.GetComponentInChildren<BaseWeapon>();
        Destroy(currentGunScript.gameObject);

        GameObject newGun =  Instantiate(itemPrefab, itemParentPos);
        BaseWeapon newGunScript = newGun.GetComponent<BaseWeapon>();
        PlayerManager.instance.player.SwitchGun(newGunScript);
    }
}
