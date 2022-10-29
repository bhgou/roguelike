using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    Transform spawnPlayer;
    private void Start()
    {
        spawnPlayer = GameObject.FindGameObjectWithTag("spawnPlayer").GetComponent<Transform>();

        player.position = spawnPlayer.position;
    }
}
