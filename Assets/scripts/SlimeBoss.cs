using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBoss : MonoBehaviour {


    public float size;

    private int slimeDamage;
    private float slimeRotationSpeed = 2;
    private float slimeSpeed;

    public EnemyHealth slimeHealth;
    private playerController player;
    public GunController slimeGun;
    public SlimeBoss childBossSlime;


    void Start () {
        player = FindObjectOfType<playerController>();
        setSlimeValues();
    }

	void Update () {
        Movement();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Hit Player
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<damagable>().takeDamage(slimeDamage);

        }
    }

    // Rotate, Move, Shoot
    private void Movement(){
        Rotation();
        transform.Translate(-Vector3.up * slimeSpeed * Time.deltaTime);

        if (Vector3.Distance(player.transform.position, this.transform.position) < 10)
        {
            slimeGun.isFiring = true;
        }
    }  

    private void Rotation()
    {
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) + 120;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, slimeRotationSpeed * Time.deltaTime);
    }

    // Spawns 2 Boss slimes half the size of the current Boss slime
    public void spawnChildren()
    {
        if (size <= 1)
        {
            return;
        }
        else
        {
            SlimeBoss leftSlime = Instantiate(childBossSlime, this.gameObject.transform.position, Quaternion.Euler(0, 0, 0));
            SlimeBoss rightSlime = Instantiate(childBossSlime, this.gameObject.transform.position, Quaternion.Euler(0, 0, 0));

            leftSlime.size = (this.size / 2);
            rightSlime.size = (this.size / 2);
        }
    }

    // sets size, speed, and damage of slime
    private void setSlimeValues()
    {
        if (size > 15)
        {
            size = 15;
        }

        Vector3 sizeVect;
        sizeVect = transform.localScale;
        sizeVect.x = size;
        sizeVect.y = size;
        transform.localScale = sizeVect;

        if (size >= 8)
        {
            slimeSpeed = (16 - size) / 4;
            slimeHealth.health = (int)size * 8;

            slimeGun.bulletSize = size / 30;
            slimeGun.timeBetweenShots = (20 - size) / 50;
        }
        else
        {
            slimeSpeed = (16 - size) / 8;
            slimeHealth.health = (int)size * 5;

            slimeGun.bulletSize = (size / 20) + 0.05f;
            slimeGun.timeBetweenShots = (10 - size) / 10;
        }
    
        slimeDamage = (int)size;

        slimeGun.gunDamage = (int)size / 2;
        slimeGun.inaccuracy = (int)size * 3;
        slimeHealth.exp = (int)size;
       
    }
}
