using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float damage;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected GameObject explosionPrefab;
    [SerializeField] protected Animator animator;

    [Header("Score"), SerializeField] protected int scoreValue;

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

    public virtual void HurtSequence() {
        EndGameManager.instance.UpdateScore(1);
    }
    public virtual void DeathSequence() {
        EndGameManager.instance.UpdateScore(scoreValue);
    }
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