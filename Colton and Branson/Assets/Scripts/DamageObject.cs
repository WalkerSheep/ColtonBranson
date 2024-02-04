using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public string WhatToDamage = "Player";
    public int Damage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == WhatToDamage)
        {
            if(other.GetComponent<Health>())
            {
                if(other.GetComponent<Health>().invincible == false)
                {
                    other.GetComponent<Health>().TakeDamage(Damage);
                }
            }
        }
    }
}
