using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject laserBullet;
    [SerializeField] private Transform basicShootingPoint;
    [SerializeField] private float shootingInterval;
    private float intervalReset;

    void Start()
    {
        intervalReset = shootingInterval;    
    }

    void Update()
    {
        shootingInterval -= Time.deltaTime;
        if(shootingInterval <=0)
        {
            Shoot();
            shootingInterval = intervalReset;
        }
    }

    private void Shoot()
    {
        Instantiate(laserBullet, basicShootingPoint.position, Quaternion.identity);
    }
}
