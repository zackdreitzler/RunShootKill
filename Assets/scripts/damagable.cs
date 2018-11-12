using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagable : MonoBehaviour {

    public int health;

	
	
	void Update () {
		if (health <= 0)
        {
            // game over
            Destroy(gameObject);
            Debug.Log("Game Over");

        }
	}

    public void takeDamage(int damage)
    {
        health -= damage;
    }
}
