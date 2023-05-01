using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Enemy
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private float speed;
    [SerializeField] private float minRotateSpeed;
    [SerializeField] private float maxRotateSpeed;
    private float rotateSpeed;
    private bool rotateClockwise;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rotateSpeed = Random.Range(minRotateSpeed, maxRotateSpeed);
        rotateClockwise = Random.Range(0, 2) == 0;

        rb.velocity = Vector2.down * speed;
    }

    void Update()
    {
        if (rotateClockwise)
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
        }


    }

    public override void HurtSequence()
    {
        // do something
    }
    public override void DeathSequence()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerStats player = collider.GetComponent<PlayerStats>();
            player.PlayerTakeDamage(damage);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
