using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject laserBullet;
    [SerializeField] private float shootingInterval;

    [Header("Basic Attack")]
    [SerializeField] private Transform basicShootingPoint;

    [Header("Upgrade 1")]
    [SerializeField] private Transform leftCannon;
    [SerializeField] private Transform rightCannon;

    [Header("Upgrage 2")]
    [SerializeField] private Transform leftCannon2;
    [SerializeField] private Transform rightCannon2;

    [Header("Upgrade Max")]
    [SerializeField] private Transform leftRotationCannon;
    [SerializeField] private Transform rightRotationCannon;

    private float intervalReset;
    [SerializeField] private int upgradeLevel = 0;

    [SerializeField] private AudioSource[] audioSources;

    void Start()
    {
        intervalReset = shootingInterval;
    }

    void Update()
    {
        shootingInterval -= Time.deltaTime;
        if (shootingInterval <= 0)
        {
            Shoot();
            shootingInterval = intervalReset;
        }
    }

    public void IncreaseUpgrade(int increaseAmount)
    {
        upgradeLevel += increaseAmount;
        if (upgradeLevel > 4)
        {
            upgradeLevel = 4;
        }
    }

    public void DecreaseUpgrade()
    {
        upgradeLevel--;
        if (upgradeLevel < 0)
        {
            upgradeLevel = 0;
        }
    }


    private void Shoot()
    {
        StartCoroutine(playLaserSounds());

        switch (upgradeLevel)
        {
            case 0:
                Instantiate(laserBullet, basicShootingPoint.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(laserBullet, leftCannon.position, Quaternion.identity);
                Instantiate(laserBullet, rightCannon.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(laserBullet, basicShootingPoint.position, Quaternion.identity);
                Instantiate(laserBullet, leftCannon.position, Quaternion.identity);
                Instantiate(laserBullet, rightCannon.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(laserBullet, basicShootingPoint.position, Quaternion.identity);
                Instantiate(laserBullet, leftCannon.position, Quaternion.identity);
                Instantiate(laserBullet, rightCannon.position, Quaternion.identity);
                Instantiate(laserBullet, leftCannon2.position, Quaternion.identity);
                Instantiate(laserBullet, rightCannon2.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(laserBullet, basicShootingPoint.position, Quaternion.identity);
                Instantiate(laserBullet, leftCannon.position, Quaternion.identity);
                Instantiate(laserBullet, rightCannon.position, Quaternion.identity);
                Instantiate(laserBullet, leftCannon2.position, Quaternion.identity);
                Instantiate(laserBullet, rightCannon2.position, Quaternion.identity);
                Instantiate(laserBullet, leftRotationCannon.position, leftRotationCannon.localRotation);
                Instantiate(laserBullet, rightRotationCannon.position, rightRotationCannon.localRotation);
                break;
            default:
                break;
        }
    }

    IEnumerator playLaserSounds()
    {
        float playTimes = 1;
        if (upgradeLevel > 3) playTimes = 3;
        else if (upgradeLevel > 1) playTimes = 2;

        //if (audioSources.Length < 5) Debug.LogError("should have 1 audio source for each upgrade level");
        for (int i = 0; i < playTimes; i++)
        {
            audioSources[i].Play();
            yield return new WaitForSeconds(0.12f);
        }
    }
}
