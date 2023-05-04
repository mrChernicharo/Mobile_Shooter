using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShield : MonoBehaviour
{
    [SerializeField] private AudioClip clipToPlay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ShieldActivator shieldActivator = collision.GetComponent<ShieldActivator>();
            shieldActivator.ActivateShield();
            // play clip without specifying an AudioSource
            AudioSource.PlayClipAtPoint(clipToPlay, transform.position, 1f);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
