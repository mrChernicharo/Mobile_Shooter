using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected Rigidbody2D rb;

    void Start()
    {

    }

    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        HurtSequence();

        if (health <= 0)
        {
            DeathSequence();
        }
    }

    public virtual void HurtSequence() { }
    public virtual void DeathSequence() { }
}


/*

OOP: Inheritance
 
         Enemy
         - health
         - rigidBody
         - animator
         - TakeDamage()
      /                  \
     /                    \
    /                      \
Meteor                  Spaceship
- TakeDamage()          - TakeDamage()
- Rotate()              - Shoot()

 
 
*/