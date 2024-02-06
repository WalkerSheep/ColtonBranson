using System.Collections;
using UnityEngine;

public class SlimeTrail : MonoBehaviour
{
    public GameObject slimeTrailPrefab; // Assign your slime trail sprite prefab in the Inspector
    private SpriteRenderer spriteRenderer;
    private bool canSpawn = true; // Flag to control spawning
    private Transform Ground;

    // Update is called once per frame
    void Update()
    {
        // Your existing Update code here
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && canSpawn)
        {
            Ground = collision.transform;
            Vector2 collisionNormal = collision.contacts[0].normal;
            StartCoroutine(SpawnSlimeTrailWithDelay(collision.contacts[0].point, Quaternion.FromToRotation(Vector2.up, collisionNormal), 0.1f));
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && canSpawn)
        {
            if(Platform.platform == null)
            {
            if (Mathf.Abs(Movement.instance.MyRigidbody.velocity.x) > 0.25f || Mathf.Abs(Movement.instance.MyRigidbody.velocity.y) > 1)
            {
                Ground = collision.transform;
                Vector2 collisionNormal = collision.contacts[0].normal;
                StartCoroutine(SpawnSlimeTrailWithDelay(collision.contacts[0].point, Quaternion.FromToRotation(Vector2.up, collisionNormal), 0.1f));
            }
            }
        }
    }

    IEnumerator SpawnSlimeTrailWithDelay(Vector2 position, Quaternion rotation, float delay)
    {
        canSpawn = false; // Disable spawning
        GameObject slimeTrail = Instantiate(slimeTrailPrefab, position, rotation);
        slimeTrail.transform.SetParent(Ground);
        yield return new WaitForSeconds(delay);
        // You may want to add additional logic, such as destroying the spawned trail after some time
        canSpawn = true; // Enable spawning for the next iteration
    }
}
