using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallStick : MonoBehaviour
{
    public Transform WallCheck;
    public bool TouchingWall;
    private Movement movement;
    private bool OnGround;
    private bool inAir;
    public bool WallSliding;
    // Start is called before the first frame update
    void Awake()
    {
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        TouchingWall = Physics2D.OverlapBox(WallCheck.position,new Vector2(0.2f,0.9f),0,movement.GroundLayer);
        OnGround = movement.OnGround;

        if(TouchingWall && inAir)
        {
            inAir = false;
        }
        if(!TouchingWall && !inAir)
        {
            inAir = true;
            ExitWall();
        }

        if(TouchingWall && !WallSliding && !OnGround)
        {
            if(movement.MyRigidbody.velocity.y < 2)
            {
                EnterWall();
            }
        }

        if(WallSliding)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(StopMovement(0.5f));
                WallSliding = false;
                movement.Flip();
                movement.MyRigidbody.velocity = new Vector2(movement.transform.right.x * 10,movement.JumpHeight);
            }
        }

    }

    public IEnumerator StopMovement(float duration)
    {
        movement.CanMove = false;
        yield return new WaitForSeconds(duration);
        movement.CanMove = true;
    }

    public void EnterWall()
    {
        WallSliding = true;
        StartCoroutine(Slide());
    }

    public void ExitWall()
    {
        WallSliding = false;
    }

    public IEnumerator Slide()
    {
        movement.MyRigidbody.gravityScale = 0;
        movement.MyRigidbody.velocity = Vector2.zero;
        yield return new WaitForSeconds(1);
        movement.MyRigidbody.gravityScale = 0.25f;
    }
}
