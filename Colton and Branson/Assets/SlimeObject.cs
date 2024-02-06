using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SlimeObject : MonoBehaviour
{
    public SlimeColor slimeColor;
    private SpriteRenderer spriteRenderer;
    public Collider2D[] MyColliders;
    private Collider2D PlayerCollider;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCollider = ColorController.instance.Player.GetComponent<Collider2D>();
        spriteRenderer.color = slimeColor.color;
    }

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slimeColor == ColorController.instance.slimeColor)
        {
            gameObject.layer = 0;
        }
        else
        {
            gameObject.layer = 6;
        }

        float targetAlpha = (slimeColor == ColorController.instance.slimeColor) ? 0.5f : 1f;
        Color targetColor = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, targetAlpha);

        spriteRenderer.color = Color.Lerp(spriteRenderer.color, targetColor, 10 * Time.deltaTime);
        foreach (Collider2D collider in MyColliders)
        {
            Physics2D.IgnoreCollision(collider, PlayerCollider, slimeColor == ColorController.instance.slimeColor);
        }
    }
}
