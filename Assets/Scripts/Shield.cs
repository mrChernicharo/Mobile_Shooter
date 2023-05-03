using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    [SerializeField] private float maxShield;

    private float hitsToDestroy;
    public bool protection;

    [SerializeField] private GameObject shieldBar;
    [SerializeField] private Image shieldFill;

    private void Start()
    {
    }


    private void OnEnable()
    {
        hitsToDestroy = maxShield;

        shieldBar.SetActive(true);
        shieldFill.fillAmount = 1;
        protection = true;
    }

    private void DamageShield()
    {
        hitsToDestroy--;
        shieldFill.fillAmount = hitsToDestroy / maxShield;

        if (hitsToDestroy <= 0)
        {
            protection = false;
            shieldBar.SetActive(false);
            gameObject.SetActive(false);
        }

    }

    public void RepairShield()
    {
        hitsToDestroy = maxShield;
        shieldFill.fillAmount = hitsToDestroy / maxShield;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(10);
            DamageShield();
        }
        else if (collision.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            DamageShield();
        }
    }
}
