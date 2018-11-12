using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int health;
    public Slime slime;
    public SlimeBoss slimeBoss;

    private GameObject player;
    private playerController pc;
    public int exp;
	
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        pc = player.GetComponent<playerController>();
    }

	void Update () {
		if (health <= 0 )
        {
            // if object is a slime, spawn smaller slime
            if (slime != null)
            {
                slime.spawnChildren();
            }
            else if (slimeBoss != null)
            {
                slimeBoss.spawnChildren();
            }

            // give player experience
            pc.GainExp(exp);

            // enemy dies
            Destroy(gameObject);
        }
	}

    public void takeDamage(int damage)
    {
       health -= damage;
    }

}
