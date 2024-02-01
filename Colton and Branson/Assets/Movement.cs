using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int Score;
    public Rigidbody2D MyRigidbody;
    public float JumpHeight;
    public float MoveSpeed;
    public float Horizontal;
    public bool OnGround;
    public Transform GroundCheck;
    public LayerMask GroundLayer;
    // private Animator animator;
    public bool FacingRight;
    public AudioClip JumpSound;
    private WallStick wallStick;
    public bool CanMove;
    // Start is called before the first frame update
    void Awake()
    {
        // animator = GetComponent<Animator>();
        FacingRight = transform.rotation.y == 0;
        wallStick = GetComponent<WallStick>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnGround = Physics2D.OverlapCircle(GroundCheck.position,0.2f,GroundLayer);

        Horizontal = Input.GetAxisRaw("Horizontal");
        if(CanMove)
        {
            MyRigidbody.velocity = Vector2.Lerp(MyRigidbody.velocity,new Vector2(MoveSpeed * Horizontal,MyRigidbody.velocity.y),10 * Time.deltaTime);
        }
        else
        {
            MyRigidbody.velocity = Vector2.MoveTowards(MyRigidbody.velocity,new Vector2(0,MyRigidbody.velocity.y),10 * Time.deltaTime);
        }
        if(wallStick.WallSliding == false)
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
        // animator.SetFloat("XVelocity",Mathf.Abs(MyRigidbody.velocity.x));
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(OnGround)
            {
                Jump();
            }
        }
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
        AudioManager.instance.PlaySound(JumpSound,transform.position);
        MyRigidbody.velocity = new Vector2(MyRigidbody.velocity.x,JumpHeight);
    }

    public void Flip()
    {
        FacingRight = !FacingRight;
        transform.Rotate(0,180,0);
    }
}
