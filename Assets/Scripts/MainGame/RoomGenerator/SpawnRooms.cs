using UnityEngine;

public class SpawnRooms : MonoBehaviour
{
    [SerializeField] private GameObject[] rooms;

    [SerializeField] private Transform[] spawnRooms;

    private void Start()
    {
        for (int i = 0; i < spawnRooms.Length; i++)
        {
            Instantiate(rooms[Random.Range(0, rooms.Length)], spawnRooms[i].position, Quaternion.identity);

        }
    }
}
