using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public static Platform platform;
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Movement>())
        {
            platform = this;
            if(Movement.instance.Horizontal == 0)
            {
                Movement.instance.MyRigidbody.velocity = new Vector2(rb.velocity.x,Movement.instance.MyRigidbody.velocity.y);
            }
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
