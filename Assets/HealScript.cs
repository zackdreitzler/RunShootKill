using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealScript : MonoBehaviour {

	// Use this for initialization
	void Start () {	}
	
	// Update is called once per frame
	void Update () { }

	void OnTriggerEnter(Collider other) {
		GameObject Player = GameObject.Find("Player");
	
		damagable playerhealth = currHealth.GetComponent();
		playerhealth.currHealth += 10;
		Destroy(GameObject);
	}
}
