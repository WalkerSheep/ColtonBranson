using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject Player;
    public float MoveSpeed = 3;
    public Vector3 Offset = new Vector3(0,2,0);
    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,new Vector3(Player.transform.position.x + Offset.x,Player.transform.position.y + Offset.y,-10),MoveSpeed * Time.deltaTime);
    }
}
