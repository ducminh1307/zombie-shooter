using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DoorManager : MonoBehaviour
{
    public static DoorManager instance;

    public int totalDoors { get; private set; }
    public static UnityAction onAllDoorsOpened;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(instance);

        totalDoors = FindObjectsOfType<Door>().Count();
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