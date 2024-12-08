using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public enum PoolType
{
    RifleBullet,
    GrenadeBullet,
    Explore,
    Zombie
}

[Serializable]
public class PoolItem
{
    public PoolType poolType;
    public GameObject poolPrefab;
    public Transform parentTransform;
}

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;

    public List<PoolItem> poolItems = new List<PoolItem>();
    private Dictionary<PoolType, Queue<GameObject>> _pools = new Dictionary<PoolType, Queue<GameObject>>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        foreach (var poolItem in poolItems)
        {
            var pool = new Queue<GameObject>();
            _pools.Add(poolItem.poolType, pool);
        }
    }

    public GameObject GetObject(PoolType poolType, Vector3 spawnPosition)
    {
        if (!_pools.TryGetValue(poolType, out var listObject))
            return null;

        //Get inactive object
        var objectToSpawn = listObject.FirstOrDefault(obj => !obj.activeInHierarchy);

        if (!objectToSpawn)
        {
            var poolItem = poolItems.Find(pool => pool.poolType == poolType);
            if (poolItem.parentTransform == null)
                objectToSpawn = Instantiate(poolItem.poolPrefab);

            objectToSpawn = Instantiate(poolItem.poolPrefab, poolItem.parentTransform);
            _pools[poolType].Enqueue(objectToSpawn);
        }

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.localPosition = spawnPosition;

        return objectToSpawn;
    }

    public void ReturnObject(GameObject obj) => obj.SetActive(false);
}