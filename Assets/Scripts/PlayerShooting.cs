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
}
