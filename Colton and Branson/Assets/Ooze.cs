using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ooze : MonoBehaviour
{
    private SlimeObject slimeObject;
    // Start is called before the first frame update
    void Awake()
    {
        slimeObject = GetComponent<SlimeObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Movement>())
        {
            if(slimeObject.slimeColor != ColorController.instance.slimeColor)
            {
                Movement.instance.MyRigidbody.velocity = new Vector2(Movement.instance.MyRigidbody.velocity.x,Movement.instance.JumpHeight * 1.5f);
            }
        }
    }
}
