using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour {

    public GameObject pistolRound;
    public GameObject shotgunRound;
    public GameObject MachineGunRound;
    public GameObject curr;
    public GameObject player;
    public playerController pc;
    private Vector2 offset;
    bool canShoot;
    float countDown;
    public float x;
    public float y;
    public float velocity;
    
    // Use this for initialization
    void Start () {
        velocity = 10f;
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<playerController>();
        canShoot = true;
        countDown = 0f;
        curr = pistolRound;
    }
	
	// Update is called once per frame
	void Update () {
        x = Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad) * -1;
        y = Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad);
        offset = new Vector2(.52f * x, .52f * y);
        if (pc.currWep == "pistol")
        {
            curr = pistolRound;
            if (Input.GetMouseButtonDown(0))
            {
                GameObject b = Instantiate(curr, (Vector2)transform.position + offset, Quaternion.identity);
                b.GetComponent<pistolBulletController>().setDamage(pc.getpdamage());
                b.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity * x, velocity * y);
            }
        }
        if(pc.currWep == "MachineGun")
        {
            curr = MachineGunRound;
            if (Input.GetMouseButton(0))
            {
                GameObject b = Instantiate(curr, (Vector2)transform.position + offset, Quaternion.identity);
                b.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity * x, velocity * y);
            }
        }
        if(pc.currWep == "Shotgun")
        {
            if(Input.GetMouseButton(0))
            {
                if(canShoot)
                {
                    curr = shotgunRound;
                    GameObject b1 = Instantiate(curr, (Vector2)transform.position + new Vector2(.52f*x, .2f*y), Quaternion.identity);
                    GameObject b2 = Instantiate(curr, (Vector2)transform.position + new Vector2(.2f*x,.52f*y), Quaternion.identity);
                    GameObject b3 = Instantiate(curr, (Vector2)transform.position + new Vector2(.6f*x,.6f*y), Quaternion.identity);
               
                    b1.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity * x, velocity * y);
                    b2.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity * x, velocity * y);
                    b3.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity * x, velocity * y);

                    canShoot = false;
                    countDown = 1f;
                }
            }
            if (canShoot == false)
            {
                if (countDown > 0)
                {
                    countDown -= Time.deltaTime;
                }
                else
                {
                    canShoot = true;
                }
            }
        }
       
       
	}
}
