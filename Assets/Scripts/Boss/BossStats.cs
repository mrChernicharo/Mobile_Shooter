using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : Enemy
{
    [SerializeField] BossController bossController;

    public override void HurtSequence()
    {
        base.HurtSequence();
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Dmg")) return;
        animator.SetTrigger("Damage");
    }

    public override void DeathSequence()
    {
        base.DeathSequence();
        bossController.ChangeState(BossState.death);
        Instantiate(explosionPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().PlayerTakeDamage(damage);
        }
    }
}
