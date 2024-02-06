using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement instance;
    public Rigidbody2D MyRigidbody;
    public float JumpHeight;
    public float MoveSpeed;
    public float Horizontal;
    private bool InAir;
    public bool OnGround;
    public Transform GroundCheck;
    public LayerMask GroundLayer;
    private Animator animator;
    public bool FacingRight;
    public AudioClip JumpSound;
    private WallStick wallStick;
    public bool CanMove;
    public Transform Flipper;
    public float CyoteTime;
    public float CyoteTimer;
    public bool haveCyoteTime;
    public bool SavedJump;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
        FacingRight = transform.rotation.y == 0;
        wallStick = GetComponent<WallStick>();
    }
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if(CyoteTimer > 0)
        {
            CyoteTimer = CyoteTimer - Time.deltaTime;
            haveCyoteTime = true;
        }
        else
        {
            CyoteTimer = 0;
            haveCyoteTime = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        OnGround = Physics2D.OverlapCircle(GroundCheck.position,0.2f,GroundLayer);

        Horizontal = Input.GetAxisRaw("Horizontal");
        if(OnGround && InAir)
        {
            InAir = false;
            Land();
        }
        if(OnGround && !InAir)
        {
            InAir = true;
            LeaveGround();
        }
        if(Platform.platform == null)
        {
            if(CanMove)
            {
                MyRigidbody.velocity = Vector2.Lerp(MyRigidbody.velocity,new Vector2(MoveSpeed * Horizontal,MyRigidbody.velocity.y),10 * Time.deltaTime);
            }
            else
            {
                MyRigidbody.velocity = Vector2.MoveTowards(MyRigidbody.velocity,new Vector2(0,MyRigidbody.velocity.y),10 * Time.deltaTime);
            }
        }
        else
        {
            MyRigidbody.gravityScale = 100;
                if(CanMove)
                {
                    MyRigidbody.velocity = Vector2.Lerp(MyRigidbody.velocity,new Vector2((MoveSpeed * Horizontal) + Platform.platform.rb.velocity.x,MyRigidbody.velocity.y),10 * Time.deltaTime);
                }
                else
                {
                    MyRigidbody.velocity = Vector2.MoveTowards(MyRigidbody.velocity,new Vector2(0,MyRigidbody.velocity.y),10 * Time.deltaTime);
                }
        }
        if(wallStick.WallSliding == false && Platform.platform == null)
        {
            if(MyRigidbody.velocity.y < 0)
            {
                MyRigidbody.gravityScale = 5;
            }
            else
            {
                MyRigidbody.gravityScale = 3;
            }
        }
        animator.SetFloat("XVelocity",Mathf.Abs(MyRigidbody.velocity.x));
        animator.SetFloat("YVelocity",MyRigidbody.velocity.y);
        animator.SetBool("OnGround",OnGround);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(OnGround || haveCyoteTime)
            {
                Jump();
            }
            else
            {
                SavedJump = true;
            }
        }
        // if(Input.GetKeyUp(KeyCode.Space))
        // {
        //     if(MyRigidbody.velocity.y > 0)
        //     {
        //         MyRigidbody.velocity = new Vector2(MyRigidbody.velocity.x,0);
        //     }
        // }
        if(CanMove)
        {
            if(FacingRight && Horizontal == -1)
            {
                Flip();
            }
            else if(!FacingRight && Horizontal == 1)
            {
                Flip();
            }
        }
    }

    public void Jump()
    {
        MyRigidbody.gravityScale = 3;
        Platform.platform = null;
        JumpAnimate();
        CyoteTimer = 0;
        MyRigidbody.velocity = new Vector2(MyRigidbody.velocity.x,JumpHeight);
    }

    public void JumpAnimate()
    {
        animator.SetTrigger("Jump");
        AudioManager.instance.PlaySound(JumpSound,transform.position);
    }

    public void Flip()
    {
        FacingRight = !FacingRight;
        Flipper.Rotate(0,180,0);
    }

    public void LeaveGround()
    {
        if(MyRigidbody.velocity.y < 0.1f)
        {
            CyoteTimer = CyoteTime;
        }
    }

    public void Land()
    {
        if(SavedJump && Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
        SavedJump = false;
        CyoteTimer = 0;
    }
}
