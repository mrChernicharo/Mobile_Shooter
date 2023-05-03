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
    [SerializeField] private Shield shield;
    private bool canPlayAnim = true;

    void Start()
    {
        health = maxHealth;
        healthFill.fillAmount = health / maxHealth;
        EndGameManager.instance.gameOver = false;
    }

    public void PlayerTakeDamage(float damage)
    {
        if (shield.protection) return;

        health -= damage;
        healthFill.fillAmount = health / maxHealth;

        if (canPlayAnim)
        {
            animator.SetTrigger("Damage");
            StartCoroutine(PreventDamageAnimationSpam());
        }

        if (health <= 0)
        {
            EndGameManager.instance.gameOver = true;
            EndGameManager.instance.StartResolveSequence();
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void PlayerAddHealth(int healAmount)
    {
        health += healAmount;
        if (health > maxHealth)
            health = maxHealth;

        healthFill.fillAmount = health / maxHealth;
    }

    private IEnumerator PreventDamageAnimationSpam()
    {
        canPlayAnim = false;
        yield return new WaitForSeconds(0.2f);
        canPlayAnim = true;
    }
}
