using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SlimeTrail : MonoBehaviour
{
    public GameObject slimeTrailPrefab; // Assign your slime trail sprite prefab in the Inspector

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") // Change "Wall" to the tag of your wall objects
        {
            Vector2 collisionNormal = collision.contacts[0].normal;
            SpawnSlimeTrail(collision.contacts[0].point, Quaternion.FromToRotation(Vector2.up, collisionNormal));
        }
    }

    // OnCollisionStay2D is called once per frame for every collider/rigidbody that is touching rigidbody/collider
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") // Change "Wall" to the tag of your wall objects
        {
            if(Mathf.Abs(Movement.instance.MyRigidbody.velocity.x) > 1 || Mathf.Abs(Movement.instance.MyRigidbody.velocity.y) > 1)
            {
                Vector2 collisionNormal = collision.contacts[0].normal;
                SpawnSlimeTrail(collision.contacts[0].point, Quaternion.FromToRotation(Vector2.up, collisionNormal));
            }
        }
    }

    void SpawnSlimeTrail(Vector2 position, Quaternion rotation)
    {
        GameObject slimeTrail = Instantiate(slimeTrailPrefab, position, rotation);
        // You may want to add additional logic, such as destroying the spawned trail after some time
    }
}
