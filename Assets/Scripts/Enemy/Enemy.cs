using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int Hp;
    [SerializeField] private int damage = 1;
    public Animator hit;
    [SerializeField] private TextMeshProUGUI damageText;
    private GameObject player;
    [SerializeField] private Slider hpBar;
    [SerializeField] private GameObject canvas;
    public float speed;
    [SerializeField] private float checkRadius;
    [SerializeField] private float attackRadius;

    [SerializeField] private float timeBtwAttack;
    float timebtw;

    [SerializeField] private LayerMask whatIsPlayer;

    private Rigidbody2D rb;
    private Transform target;
    private Animator animator;
    [SerializeField] private Vector2 movement;
    [SerializeField] private Vector3 direction;
    public bool isInAttackRange;
    public bool isInChaseRange;
    public bool bush;
    private void Start()
    {
        timebtw = timeBtwAttack;
        hpBar.maxValue = Hp;
        hpBar.value = Hp;
        rb = GetComponent<Rigidbody2D>();
        hit =GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Win.instance.Enemys.Add(this.gameObject);
    }

    private void Update()
    {
        if (!bush)
        {
            animator.SetBool("run", isInChaseRange);
            isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
            isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);
            hpBar.value = Hp;
            direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            direction.Normalize();
            movement = direction;
        }
     
        if(direction.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        

        player.GetComponent<PlayerStats>().Damage = damage;
        if (Hp <= 0)
        {
            hit.Play("dead");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Hp = 0;
            Destroy(gameObject, 1);

        }

    }
  
    private void FixedUpdate()
    {
        if (!bush)
        {
            if (isInChaseRange && !isInAttackRange)
            {
                MoveCharacter(movement);
            }
            if (isInAttackRange)
            {
                rb.velocity = Vector2.zero;
            }
        }
       
    }
    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }
    public void TakeDamage(int damage)
    {


        hit.Play("hit");
        Hp -= damage;
        hit.SetBool("walk", true);
        var s = Instantiate(damageText.gameObject, transform.position, Quaternion.identity);
        s.gameObject.transform.SetParent(canvas.transform);
        damageText.text = "-" +  damage.ToString();
        CameraShake.Instance.ShakeCamera(5f, .1f);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            timebtw -= 1 * Time.deltaTime;
            if(timebtw <= 0)
            {
                player.GetComponent<PlayerStats>().TakeDamage(damage);
                timebtw = timeBtwAttack;
            }
            
           
        }
        
    
    }


}
 