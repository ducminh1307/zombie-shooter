using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Door")]
    [SerializeField] private int doorId;
    [SerializeField] private GameObject door;
    private const float SlideDistance = 2.5f;
    private const float SlideDuration = 1.0f;
    private CheckPlayer _checkPlayer;

    private Vector3 _initialPosition;

    [Header("Spawn Enemies")]
    [SerializeField] private int numberEnemies;
    [SerializeField] Vector2 limitX;
    [SerializeField] Vector2 limitZ;

    private void Awake()
    {
        CheckPlayer.onPlayerInFrontDoor += SpawnEnemies;
        CheckPlayer.onPlayerInFrontDoor += OpenDoor;
        _initialPosition = door.transform.position;
    }

    private void OnDestroy()
    {
        CheckPlayer.onPlayerInFrontDoor -= SpawnEnemies;
        CheckPlayer.onPlayerInFrontDoor -= OpenDoor;
    }

    private void SpawnEnemies(int _doorId)
    {
        if (_doorId != doorId) return;
        if (numberEnemies <= 0) return;

        EnemyManager.instance.RegisterEnemies(numberEnemies);

        for (int i = 0; i < numberEnemies; i++)
        {
            PoolManager.instance.GetObject(PoolType.Zombie, new Vector3(Random.Range(limitX.x, limitX.y), .5f, Random.Range(limitZ.x, limitZ.y)));
        }
    }

    private void OpenDoor(int _doorId)
    {
        if (_doorId == doorId)
        {
            StartCoroutine(SlideDoorDown());
            DoorManager.instance.DoorOpened();
        }
    }

    private IEnumerator SlideDoorDown()
    {
        Vector3 targetPosition = _initialPosition - new Vector3(0, SlideDistance, 0);
        float elapsedTime = 0;

        while (elapsedTime < SlideDuration)
        {
            door.transform.position = Vector3.Lerp(_initialPosition, targetPosition, elapsedTime / SlideDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        door.transform.position = targetPosition;
    }
}
