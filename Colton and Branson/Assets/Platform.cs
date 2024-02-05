using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public static Platform platform;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(platform == this && gameObject.layer == 6)
        { 
            Movement.instance.MyRigidbody.velocity = new Vector2((Movement.instance.MoveSpeed * Movement.instance.Horizontal) +  rb.velocity.x,Movement.instance.MyRigidbody.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Movement>())
        {
            platform = this;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.GetComponent<Movement>())
        {
            if(platform == this)
            {
                platform = null;
            }
        }
    }
}
