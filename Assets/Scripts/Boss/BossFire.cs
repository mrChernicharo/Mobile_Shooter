using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : BossBaseState
{
    [SerializeField] private float speed;
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject bulletPrefab;

    [Header("Shooting Points")]
    [SerializeField] private Transform[] shootingPoints;

    protected override void Start()
    {
        base.Start();
    }

    public override void RunState()
    {
        base.RunState();
        StartCoroutine(RunFireState());
    }

    public override void StopState()
    {
        base.StopState();
    }


    IEnumerator RunFireState()
    {
        float shootTimer = 0f;
        float fireStateTimer = 0f;
        float fireStateExitTime = Random.Range(5f, 10f);
        Vector2 targetPos = new Vector2(Random.Range(maxLeft, maxRight), Random.Range(maxBottom, maxTop));

        while (fireStateTimer <= fireStateExitTime)
        {
            if (Vector2.Distance(transform.position, targetPos) > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            } else
            {
                targetPos = new Vector2(Random.Range(maxLeft, maxRight), Random.Range(maxBottom, maxTop));
            }

            shootTimer += Time.deltaTime;
            if (shootTimer >= fireRate)
            {
                for (int i = 0; i < shootingPoints.Length; i++)
                {
                    Instantiate(bulletPrefab, shootingPoints[i].position, Quaternion.identity);
                }

                shootTimer = 0;
            }
            yield return new WaitForEndOfFrame();
            fireStateTimer += Time.deltaTime;
        }

        bossController.ChangeState(BossState.special);

        //int randomPick = Random.Range(0, 2);
        //if (randomPick == 0)
        //{
        //    bossController.ChangeState(BossState.special);
        //}
        //else
        //{
        //    bossController.ChangeState(BossState.fire);
        //}
    }

}
