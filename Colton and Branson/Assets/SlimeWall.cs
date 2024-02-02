using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeWall : MonoBehaviour
{
    public SlimeColor slimeColor;
    private SpriteRenderer spriteRenderer;
    private Collider2D MyCollider;
    private Collider2D PlayerCollider;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCollider = ColorController.instance.Player.GetComponent<Collider2D>();
        spriteRenderer.color = slimeColor.color;
    }

    void Awake()
    {
        MyCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(slimeColor == ColorController.instance.slimeColor)
        {
            gameObject.layer = 0;
        }
        else
        {
            gameObject.layer = 6;
        }
        spriteRenderer.color = Color.Lerp(spriteRenderer.color,slimeColor.color,25 * Time.deltaTime);
        Physics2D.IgnoreCollision(MyCollider,PlayerCollider,slimeColor == ColorController.instance.slimeColor);
    }
}