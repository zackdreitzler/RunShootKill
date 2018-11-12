﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistolBulletController : MonoBehaviour {
    private float lifetime;
    private int damage = 10;
	// Use this for initialization
	void Start () {
        lifetime = 60f;
	}
	
	// Update is called once per frame
	void Update () {
        lifetime -= 1 * Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag != "Player")
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<EnemyHealth>().takeDamage(damage);
            }
            Destroy(gameObject);
        }
       
    }
}
