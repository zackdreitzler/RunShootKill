using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour {

    public GameObject pistolRound;
    public GameObject shotgunRound;
    public GameObject laser;
    public GameObject curr;
    public GameObject player;
    public playerController pc;
    private Vector2 offset;
    public float x;
    public float y;
    public float velocity;
    
    // Use this for initialization
    void Start () {
        velocity = 10f;
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<playerController>();
        curr = pistolRound;
    }
	
	// Update is called once per frame
	void Update () {
        if(pc.currWep == "pistol")
        {
            curr = pistolRound;
        }
        x = Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad) * -1;
        y = Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad); 
        offset = new Vector2(.52f * x,.52f * y);
        if(Input.GetMouseButtonDown(0))
        {
            GameObject b = Instantiate(curr, (Vector2)transform.position + offset, Quaternion.identity);
            b.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity * x, velocity * y);
        }
	}
}
