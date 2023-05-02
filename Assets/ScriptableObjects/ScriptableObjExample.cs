using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/PowerUpSpawner", fileName = "Spawner")]
public class ScriptableObjExample : ScriptableObject
{
    public int spawnProb;

    public GameObject[] powerUps;

    public void MaybeSpawnPowerUp(Vector3 spawnPos)
    {
        int randomChance = Random.Range(0, 101);
        if (randomChance < spawnProb)
        {
            SpawnPowerUp(spawnPos);
        }

    }

    public void SpawnPowerUp(Vector3 spawnPos)
    {
        int randomPowerUp = Random.Range(0, powerUps.Length);
        Instantiate(powerUps[randomPowerUp], spawnPos, Quaternion.identity);
    }
}
