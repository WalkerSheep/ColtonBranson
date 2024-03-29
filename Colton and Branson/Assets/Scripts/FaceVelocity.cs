using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceVelocity : MonoBehaviour
{
    public float MoveAmount = 0.1f;
    public float RotateAmount = 2;
    public Vector2 Offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0,0,Movement.instance.MyRigidbody.velocity.x * RotateAmount);
        transform.localPosition = Vector3.Lerp(transform.localPosition,new Vector3(Movement.instance.MyRigidbody.velocity.x * MoveAmount + Offset.x,Movement.instance.MyRigidbody.velocity.y * MoveAmount + Offset.y,0),25 * Time.deltaTime);
    }
}
