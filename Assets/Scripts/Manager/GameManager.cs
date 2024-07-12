using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static UnityAction onPlayerWin;

    private void Awake()
    {
        DoorManager.onAllDoorsOpened += CheckWin;
        EnemyManager.onAllEnemiesDefeated += CheckWin;
    }

    private void OnDestroy()
    {
        DoorManager.onAllDoorsOpened -= CheckWin;
        EnemyManager.onAllEnemiesDefeated -= CheckWin;
    }

    private void CheckWin()
    {
        if (DoorManager.instance.totalDoors <= 0 && EnemyManager.instance.totalEnemies <= 0)
            onPlayerWin.Invoke();
    }
}
