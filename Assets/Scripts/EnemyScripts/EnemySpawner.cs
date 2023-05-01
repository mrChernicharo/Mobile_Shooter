using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Camera mainCam;
    private float maxLeft;
    private float maxRight;
    private float yPos;

    [Header("Enemy Prefabs")]
    [SerializeField] private GameObject[] enemies;

    private float enemyTimer;
    [Space(15)]
    [SerializeField] private float enemySpawnTime;

    void Start()
    {
        mainCam = Camera.main;
        StartCoroutine(SetBoundaries());
    }

    // Update is called once per frame
    void Update()
    {
        EnemySpawn();
    }

    private void EnemySpawn()
    {
        enemyTimer += Time.deltaTime;
        if (enemyTimer >= enemySpawnTime)
        {
            int randomPick = Random.Range(0, enemies.Length);
            Instantiate(enemies[randomPick], new Vector3(Random.Range(maxLeft, maxRight), yPos, 0), Quaternion.identity);
            enemyTimer = 0;
        }
    }


    private IEnumerator SetBoundaries()
    {
        // accessing mainCam.ViewportToWorldPoint in start doesn't give Cinemachine enough time
        // to adjust the VirtualCamera to the viewport, that's why we create a coroutine here.

        yield return new WaitForSeconds(0.4f);

        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0f)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0f)).x;
        yPos = mainCam.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;
    }
}
