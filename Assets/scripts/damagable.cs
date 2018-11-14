using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagable : MonoBehaviour {

    public int health;
    private string playerfile = "Player.txt";
	
	
	void Update () {
		if (health <= 0)
        {
            // game over
            gameObject.SetActive(false);
            writePlayer();
            Debug.Log("Game Over");

        }
	}

    public void takeDamage(int damage)
    {
        health -= damage;
    }

    private void writePlayer()
    {
        
    }
}
