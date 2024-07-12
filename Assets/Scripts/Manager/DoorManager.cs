using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DoorManager : MonoBehaviour
{
    public static DoorManager instance;

    public int totalDoors {  get; private set; }
    public static UnityAction onAllDoorsOpened;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            totalDoors = FindObjectsOfType<Door>().Count();
        }
        else
            Destroy(instance);
    }

    public void DoorOpened()
    {
        totalDoors--;
        if (totalDoors <= 0)
        {
            onAllDoorsOpened.Invoke();
        }
    }
}
