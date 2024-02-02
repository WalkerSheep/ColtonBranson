using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBall : MonoBehaviour
{
    public SlimeColor slimeColor;
    private SpriteRenderer spriteRenderer;
    public AudioClip PaintSound;
    private ParticleSystem particle;
    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        particle = GetComponentInChildren<ParticleSystem>();
    }

    [System.Obsolete]
    void Start()
    {
        spriteRenderer.color = slimeColor.color;
        particle.startColor = slimeColor.color;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Movement>())
        {
            if(ColorController.instance.slimeColor != slimeColor)
            {
                AudioManager.instance.PlaySound(PaintSound,transform.position);
                particle.Play();
                ColorController.instance.slimeColor = slimeColor;
            }
        }
    }
}
