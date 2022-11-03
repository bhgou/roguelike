using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static Weapon instance;
    public static Weapon Instance
    {
        get
        {
            return instance;
        }
    }

    public int id;
    [SerializeField] private int damage;
    [SerializeField] private float coolDown;
    [SerializeField] private float speedRotate;
    [SerializeField] private float rotate_;
    [SerializeField] private bool shot;
    [SerializeField] private Transform RotationWeapon; 
    public List<Enemy> Enemy;
     public Enemy LastEnemy;
    
    [SerializeField] private Transform WeaponPosition;
    [SerializeField] private GameObject Particle;
    [SerializeField] private Transform spawnParticle;


    [SerializeField] private Transform spawnBullet;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private bool haveParticle;
    [SerializeField] private bool further;

    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        RotationWeapon =  GetComponent<Transform>();
        RotationWeapon.Rotate(0f, 0f, -45f);
    }

    private void Update()
    {
        if (further)
        {
            if(spawnBullet != null && bulletPrefab != null)
            {
                Shoot(spawnBullet, bulletPrefab);
            }
        }
        transform.position = WeaponPosition.position;
        if (Input.GetMouseButtonDown(0))
        {

            shot = true;
        }
        if (shot) { StartCoroutine(Rotate()); }
        if (Input.GetMouseButtonDown(0))
        {
            if (haveParticle) {
                var s = Instantiate(Particle, spawnParticle.position, Quaternion.identity);
                Destroy(s, 3);
            }
            for (int i = 0; i < Enemy.Count; i++)
            {
                Enemy[i].TakeDamage(damage);
                
            }
        }
        for (int i = 0; i < Enemy.Count; i++)
        {
            if (Enemy[i] == null) return;
            if (Enemy[i].Hp <= 0)
            {
            }

        }
        for(int i = 0; i < Enemy.Count; i++){
            if(Enemy[i] == null){
                Enemy.RemoveAt(i);
            }
        }
        
        
    }
    IEnumerator Rotate()//������� ������
    {    
        if(MovePlayer.Instance.direction == 1)
        {
            RotationWeapon.transform.rotation = Quaternion.Lerp(RotationWeapon.transform.rotation, Quaternion.Euler(0, 0, -rotate_), Time.deltaTime * speedRotate);
            yield return new WaitForSeconds(0.1f);
            RotationWeapon.transform.rotation = Quaternion.Lerp(RotationWeapon.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * speedRotate);
            shot = false;
        }
        if (MovePlayer.Instance.direction == -1)
        {
            RotationWeapon.transform.rotation = Quaternion.Lerp(RotationWeapon.transform.rotation, Quaternion.Euler(0, 0, rotate_), Time.deltaTime * speedRotate);
            yield return new WaitForSeconds(0.1f);
            RotationWeapon.transform.rotation = Quaternion.Lerp(RotationWeapon.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * speedRotate);
            shot = false;
        }
    }
    private void Shoot(Transform spawnPosition,GameObject prefab)
    {
        if (Input.GetMouseButtonDown(0))
        {
           Instantiate(prefab, spawnPosition.position, Quaternion.identity);
           
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !further)
        {
            Enemy.Add(collision.GetComponent<Enemy>());

            LastEnemy = collision.GetComponent<Enemy>();

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !further)
        {
            Enemy.Remove(other.gameObject.GetComponent<Enemy>());


        }

    }
}
