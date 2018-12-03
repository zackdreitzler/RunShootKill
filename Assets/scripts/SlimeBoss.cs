using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBoss : MonoBehaviour {


    public float size;

    private int slimeDamage;
    private float slimeRotationSpeed = 2;
    private float slimeSpeed;
    private float strafe = 0;

    public EnemyHealth slimeHealth;
    private playerController player;
    public GunController slimeGunA;
    public GunController slimeGunB;
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
            slimeGunA.isFiring = true;
            slimeGunB.isFiring = true;
        }

        // Random strafing
        strafe += Random.Range(-.0002f, .0002f) * slimeSpeed;

        if (strafe > (slimeSpeed / 4))
        {
            strafe -= (.0004f * slimeSpeed);
        }
        else if (strafe < (-slimeSpeed / 2))
        {
            strafe += (.0004f * slimeSpeed);
        }

        transform.Translate(Vector3.right * strafe);
    }  

    private void Rotation()
    {
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) + 100;
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
        if (size > 16)
        {
            size = 16;
        }

        Vector3 sizeVect;
        sizeVect = transform.localScale;
        sizeVect.x = size;
        sizeVect.y = size;
        transform.localScale = sizeVect;

        if (size >= 8)
        {
            slimeSpeed = (20 - size) / 5;

            slimeGunA.bulletSize = size / 2;
            slimeGunB.bulletSize = size / 2;

            slimeGunA.timeBetweenShots = (20 - size) / 50;
            slimeGunB.timeBetweenShots = (20 - size) / 50;
        }
        else
        {
            slimeSpeed = (16 - size) / 5;

            slimeGunA.bulletSize = (size) + 0.05f;
            slimeGunB.bulletSize = (size) + 0.05f;

            slimeGunA.timeBetweenShots = (10 - size) / 10;
            slimeGunB.timeBetweenShots = (10 - size) / 10;
        }

        slimeHealth.health = (int)size * 10;

        slimeDamage = (int)size;

        slimeGunA.gunDamage = (int)size / 2;
        slimeGunB.gunDamage = (int)size / 2;

        slimeGunA.inaccuracy = (int)size * 3;
        slimeGunB.inaccuracy = (int)size * 3;

        slimeHealth.exp = (int)size;
       
    }
}
