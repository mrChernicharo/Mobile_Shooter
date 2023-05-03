using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private Transform spawnPosition;

    void Start()
    {
        FindObjectOfType<WinCondition>().OnReachedEndOfLevel += SpawnBoss;
        
    }

    private void SpawnBoss()
    {
        Instantiate(bossPrefab, spawnPosition.position, Quaternion.identity);
    }
}

