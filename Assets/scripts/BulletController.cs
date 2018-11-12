using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed;
    public float lifetime;
    public int bulletDamage;
    public float size;
    public GameObject impactEffect;


    void Start()
    {
        Vector3 sizeVect;
        sizeVect = transform.localScale;
        sizeVect.x = size;
        sizeVect.y = size;
        transform.localScale = sizeVect;
    }

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
        // Is it an enemy bullet?
        if (this.gameObject.tag == "Enemy")
        {
            // Hit Player
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<damagable>().takeDamage(bulletDamage);

            }
        }
        else {

            // Hit Enemy
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<EnemyHealth>().takeDamage(bulletDamage);

            }
        }
        // bullet impact effect
        GameObject impact = Instantiate(impactEffect, transform.position, transform.rotation);
 
        // change impact based on bullet size
        ParticleSystem.ShapeModule impactShape = impactEffect.GetComponent<ParticleSystem>().shape;
        impactShape.radius = size / 10;
        impactShape.length = size / 10;
        impactShape.radiusSpeed = 1 - size;

        //destroy bullet
        Destroy(impact, 2f);
        Destroy(gameObject);
    }
}
