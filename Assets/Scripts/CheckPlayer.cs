using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPlayer : MonoBehaviour
{
    [SerializeField] private int doorId;
    public static UnityAction<int> onPlayerInFrontDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onPlayerInFrontDoor.Invoke(doorId);
            gameObject.SetActive(false);
        }
    }
}
