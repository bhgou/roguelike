using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance
    {
        get
        {
            return _instance;
        }
    }
    public static PlayerStats _instance;

    public int health;
    public Animator anim;
    [SerializeField] Transform main_object_helth_sprite;
    [SerializeField] GameObject health_sprite;
    public List<GameObject> count_health;
    [SerializeField] GameObject DeadPanel;
    public int Damage;

    private void Awake()
    {
        _instance = this;
    }


    private void Start()
    {
        
        for (int i = 0; i < health; i++)
        {
            var s = Instantiate(health_sprite, transform.position, Quaternion.identity);
            s.transform.SetParent(main_object_helth_sprite);
            count_health.Add(s);
        }
        DeadPanel.SetActive(false);
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        
        if (health <= 0)
        {
            
            health = 0;
            DeadPanel.SetActive(true);
            StartCoroutine(Restart(2));
        }
    }
    public void UpdateHealth()
    {
        count_health.RemoveAt(0);
        for (int i = 0; i < Damage; i++)
        {
            Destroy(count_health[i]);
        }   
        
    }
    public void Health(int hp)
    {
        health += hp;
        for (int i = 0; i < hp; i++)
        {
            var s = Instantiate(health_sprite, transform.position, Quaternion.identity);
            s.transform.SetParent(main_object_helth_sprite);
            count_health.Add(s);
        }
    }
    public void TakeDamage(int damage)
    {
        anim.Play("hit");
        anim.SetBool("hit", false);
        health -= damage;
        UpdateHealth();
    }
    IEnumerator Restart(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
