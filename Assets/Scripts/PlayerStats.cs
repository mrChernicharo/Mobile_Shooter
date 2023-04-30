using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float health;

    [SerializeField] private Image healthFill;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Animator animator;
    private bool canPlayAnim = true;

    void Start()
    {
        health = maxHealth;
        healthFill.fillAmount = health / maxHealth;
    }

    public void PlayerTakeDamage(float damage)
    {
        health -= damage;
        healthFill.fillAmount = health / maxHealth;

        if (canPlayAnim)
        {
            animator.SetTrigger("Damage");
            StartCoroutine(PreventDamageAnimationSpam());
        }

        if (health <= 0)
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private IEnumerator PreventDamageAnimationSpam()
    {
        canPlayAnim = false;
        yield return new WaitForSeconds(0.2f);
        canPlayAnim = true;
    }
}
