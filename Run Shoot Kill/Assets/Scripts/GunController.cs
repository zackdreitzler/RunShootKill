using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {


    public BulletController bullet;

    public Transform firePoint;

    public bool isFiring;
    public float bulletSpeed, timeBetweenShots, range, reloadTime;
    public int gunDamage, inaccuracy, magazineSize;

    private int bulletsInMag;
    private bool reloading = false;
    private float reloadCounter, shotCounter;

    void Start()
    {
        reloadCounter = 0;
        bulletsInMag = magazineSize;
    }

    void Update () {

        //check if gun needs to be reloaded
        if (bulletsInMag <= 0)
        {
            reloading = true;
        }

        //reload
        if (reloading)
        {
            reloadCounter += Time.deltaTime;
            if (reloadCounter >= reloadTime)
            {
                bulletsInMag = magazineSize;
                reloadCounter = 0;
                reloading = false;
            }

        }

        //shoot
        else if (isFiring)
        {
            
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;

                bulletsInMag -= 1;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, Random.Range(-inaccuracy, inaccuracy) + 5)) as BulletController;
                newBullet.speed = bulletSpeed;
                newBullet.lifetime = range;
                newBullet.bulletDamage = gunDamage;
            }

        }
        if(!isFiring)
        {
            shotCounter = 0;
        }
    }
}
