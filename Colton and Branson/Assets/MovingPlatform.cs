using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector2 Move;
    public float Direction;
    public float TurnTime;
    private Rigidbody2D RB;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Turning());
    }

    void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RB.velocity = Move * Direction;
    }

    public IEnumerator Turning()
    {
        yield return new WaitForSeconds(TurnTime);
        Direction = -Direction;
        RB.velocity = Move * Direction;
        if(Movement.instance.Horizontal == 0 && Platform.platform == GetComponent<Platform>())
        {
            Movement.instance.MyRigidbody.velocity = new Vector2(RB.velocity.x,Movement.instance.MyRigidbody.velocity.y);
        }
        StartCoroutine(Turning());
    }
}
