using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{   
    public Transform GroundCheck;
    public float MoveSpeed;
    public bool OnGround;
    private Rigidbody2D RB;

    public bool FacingRight;

    public bool TouchingWall;
    public Transform WallCheck;
    public LayerMask TheGround;
    

    // Start is called before the first frame update
    void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        FacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        OnGround = Physics2D.OverlapCircle(GroundCheck.position,0.2f,TheGround);
        if (!OnGround || TouchingWall)
        {
            Flip();

        }
        RB.velocity = new Vector2(transform.right.x * MoveSpeed, RB.velocity.y);
        TouchingWall = Physics2D.OverlapCircle(WallCheck.position,0.2f,TheGround);

    }
    public void Flip()
    {
        FacingRight = !FacingRight;
        transform.Rotate(0, 180, 0);
    }
}
 