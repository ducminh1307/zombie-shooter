using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    void Start()
    {
        transform.position = player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(-10, 10, -10);
    }
}
