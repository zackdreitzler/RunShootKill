using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealScript : MonoBehaviour {

	public void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player") {
			Debug.Log("Heal up, loser.");
			damagable heals = other.gameObject.GetComponent<damagable>();
			int health = heals.currHealth;
			print(heals.currHealth);
			heals.currHealth = health + 10;
			print(heals.currHealth);
			Debug.Log("Heal done");
			Destroy(gameObject);
		}
	}
}
