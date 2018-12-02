using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    // max 15
    public float size;

    private float slimeSpeed;
    private int slimeDamage;
    public EnemyHealth slimeHealth;

    public Slime childSlime;
    private Transform player;
    

    void Start()
    {
        setSlimeValues();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, slimeSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Hit Player
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<damagable>().takeDamage(slimeDamage);

        }
    }

    // Spawns 2 slimes half the size of the current slime
    public void spawnChildren()
    {
        if (size <= 1)
        {
            return;
        }
        else
        {
            Slime leftSlime = Instantiate(childSlime,this.gameObject.transform.position,Quaternion.Euler(0,0,0));
            Slime rightSlime = Instantiate(childSlime, this.gameObject.transform.position, Quaternion.Euler(0, 0, 0));

            leftSlime.size = (this.size / 2);
            rightSlime.size = (this.size / 2);
        }
    }

    // sets size, speed, and damage of slime
    private void setSlimeValues()
    {
        if(size > 15)
        {
            size = 15;
        }

        Vector3 sizeVect;
        sizeVect = transform.localScale;
        sizeVect.x = size;
        sizeVect.y = size;
        transform.localScale = sizeVect;

        if (size > 14)
        {
            slimeSpeed = (20 - size) / 4;
        }
        else if (size > 10)
        {
            slimeSpeed = (16 - size) / 4;
            slimeHealth.health = (int)size * 8;
        }
        else
        {
            slimeSpeed = (16 - size) / 6;
            slimeHealth.health = (int)size * 6;
        }
        slimeDamage = (int)size;
        slimeHealth.exp = ((int)size / 2) + 1;

    }
}