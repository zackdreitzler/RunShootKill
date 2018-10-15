using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed;
    public float lifetime;
    public int bulletDamage;
    public GameObject impactEffect;

	
	void Update () {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        lifetime -= Time.deltaTime *speed;
        if (lifetime <= 0 )
        {
            Destroy(gameObject);
        } 
	}


    void OnCollisionEnter2D(Collision2D other)
    {
        if(this.gameObject.tag == "Enemy")
        {
            
            // bullet impact effect
            GameObject impact = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(impact, 2f);
            Destroy(gameObject);
            
        }
        else {

            // Hit Enemy
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<EnemyHealth>().takeDamage(bulletDamage);

                // bullet impact effect
                GameObject impact = Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(impact, 2f);
                Destroy(gameObject);
            }
        }
    }
}
