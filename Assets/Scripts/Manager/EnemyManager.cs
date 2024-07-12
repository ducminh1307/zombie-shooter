using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    public static UnityAction onAllEnemiesDefeated;
    public int totalEnemies { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            totalEnemies = 0;
        }
        else
            Destroy(instance);
    }

    public void RegisterEnemies(int _numberOfEnemies)
    {
        totalEnemies += _numberOfEnemies;
    }

    public void EnemyDefeated()
    {
        totalEnemies --;

        if (totalEnemies == 0 )
            onAllEnemiesDefeated.Invoke();
    }
}
