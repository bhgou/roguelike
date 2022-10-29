using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public static MovePlayer instance;
    public static MovePlayer Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField]private float speed = 8;
    public bool FacingRight = true;
    [SerializeField] Animator anim;
    [SerializeField] FixedJoystick joystick;
    public int direction = 1;
    Rigidbody2D rb;
    Vector2 moveVelocity;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        //Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 moveInput = new Vector2(joystick.Horizontal,joystick.Vertical);
        moveVelocity = moveInput * speed;
        if(!FacingRight && moveInput.x > 0)
        {
            flip();
            
        }
        if (FacingRight && moveInput.x < 0)
        {
            flip();
            
        }
        if ((moveInput.x != 0 || moveInput.y != 0))
            anim.SetBool("_run", true);
        else anim.SetBool("_run", false);



    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position +moveVelocity * Time.fixedDeltaTime);
    }
    
    public void flip()
    {
        direction *= -1;
        FacingRight = !FacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    
    }
}
