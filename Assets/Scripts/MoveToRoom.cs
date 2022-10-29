using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRoom : MonoBehaviour
{
    [SerializeField] private Transform spawnInRoom;
    private Transform player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.GetComponent<Transform>();
        player.transform.position = spawnInRoom.position;
    }
}
