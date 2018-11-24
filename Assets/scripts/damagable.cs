using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagable : MonoBehaviour {

    public int health;
    private string playerfile = "Player.txt";
    public RectTransform healthBar;
	
	
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
        healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }

    private void writePlayer()
    {
        
    }
}
