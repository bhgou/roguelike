using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public Transform player;
    public Transform spawnPlayer;
    bool spawn = false;
    private void Update()
    {
        if(spawnPlayer != null){
            spawnPlayer = GameObject.FindGameObjectWithTag("spawnPlayer").GetComponent<Transform>();
            spawn = true;
            if (spawn)
            {
                player.position = spawnPlayer.position;
            }
        }
        
    }

}
