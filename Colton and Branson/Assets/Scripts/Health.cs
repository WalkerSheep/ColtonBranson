using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int MaxHealth;
    public int health = 3;
    public bool invincible = false;
    public bool DestroyOnDeath = true;
    SpriteRenderer spriteRenderer;
    public bool invincibleOnHit;
    public bool Dead;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        MaxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        Dead = health < 1;
    }
    
    public void Die()
    {
        if(DestroyOnDeath)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int Amount)
    {
        health = health - Amount;
        rb.velocity = new Vector2(10,10);
        if(health < 1)
        {
            health = 0;
            Die();
        }
        else if(invincibleOnHit)
        {
            StartCoroutine(InvincibilityTimer());
        }
    }

    public void HealDamage(int Amount)
    {
        health = health + Amount;
        if(health > MaxHealth)
        {
            health = MaxHealth;
        }
    }

    public IEnumerator InvincibilityTimer(float duration = 1,int flashes = 3)
    {
        invincible = true;
        float MathedDuration = duration / (flashes * 2);
        for (int i = 0; i < flashes; i++)
        {
            spriteRenderer.color = PlayerHealthController.instance.FlashColor;
            yield return new WaitForSeconds(MathedDuration);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(MathedDuration);
        }
        invincible = false;
    }
}
