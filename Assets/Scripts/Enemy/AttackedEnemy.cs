using UnityEngine;

public class AttackedEnemy : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnBullet;
    [SerializeField] private float timeBtwAttack;
    private Enemy enemy;
    float timeBtw;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        timeBtw = timeBtwAttack; 
    }

    void Shoot()
    {
        timeBtw -= 1 * Time.deltaTime;

        if(timeBtw < 0)
        {
            Instantiate(bullet, spawnBullet.position, Quaternion.identity);
            timeBtw = timeBtwAttack;
        }
        
    }
    private void Update()
    {
        
    }
    
}
