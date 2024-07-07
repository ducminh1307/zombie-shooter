using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    private List<GameObject> poolGameobjects = new List<GameObject>();
    [SerializeField] private int amountToPool;
    [SerializeField] private GameObject bulletPrefab;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
    }

    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            poolGameobjects.Add(obj);
        }
    }

    public GameObject GetPoolObject()
    {
        for (int i = 0; i < poolGameobjects.Count; i++)
        {
            if (!poolGameobjects[i].activeInHierarchy)
            {
                return poolGameobjects[i];
            }
        }

        return null;
    }
}
