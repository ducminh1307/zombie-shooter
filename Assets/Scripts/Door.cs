using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Door")]
    [SerializeField] private int doorId;
    [SerializeField] private GameObject door;
    [SerializeField] private float slideDistance = 3.0f;
    [SerializeField] private float slideDuration = 1.0f;

    private Vector3 initialPosition;

    [Header("Spawn Enemies")]
    [SerializeField] GameObject enemy;
    [SerializeField] private int numberEnemies;
    [SerializeField] Vector2 limitX;
    [SerializeField] Vector2 limitZ;

    private void Awake()
    {
        CheckPlayer.onPlayerInFrontDoor += SpawnEnemies;
        CheckPlayer.onPlayerInFrontDoor += OpenDoor;
        initialPosition = door.transform.position;
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

        for (int i = 0; i < numberEnemies; i++)
        {
            Instantiate(
                enemy,
                new Vector3(Random.Range(limitX.x, limitX.y), .5f, Random.Range(limitZ.x, limitZ.y)),
                Quaternion.identity);
        }
    }

    private void OpenDoor(int _doorId)
    {
        if (_doorId == doorId)
            StartCoroutine(SlideDoorDown());
    }

    private IEnumerator SlideDoorDown()
    {
        Vector3 targetPosition = initialPosition - new Vector3(0, slideDistance, 0);
        float elapsedTime = 0;

        while (elapsedTime < slideDuration)
        {
            door.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / slideDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        door.transform.position = targetPosition;
    }
}
