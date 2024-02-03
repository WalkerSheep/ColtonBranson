using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SetAnimation : MonoBehaviour
{
    private GameObject Sprite;
    private float ScaleX,ScaleY;
    // Start is called before the first frame update
    void Awake()
    {
        Sprite = GetComponentInChildren<SpriteRenderer>().gameObject;
        ScaleX = 1;
        ScaleY = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Sprite.transform.localScale = Vector3.Lerp(Sprite.transform.localScale,new Vector3(ScaleX,ScaleY,0),25 * Time.deltaTime);
    }
}
