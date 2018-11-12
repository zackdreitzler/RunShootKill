using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    public Rigidbody2D zombieRB;
    public float zombieSpeed;
    public float zombieRotateSpeed;
    public int zombieDamage;

    private playerController player;

	void Start () {
        player = FindObjectOfType<playerController>();
	}
	
    void FixedUpdate()
    {
        
        transform.Translate(-Vector3.left * zombieSpeed * Time.deltaTime);
    }
	
	void Update () {
        Rotate();

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Hit Player
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<damagable>().takeDamage(zombieDamage);

        }
    }

    void Rotate()
    {
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg);
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * zombieRotateSpeed);
    }
}
