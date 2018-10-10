using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    public float maxSpeed = 10f;
    private Rigidbody2D player;

    // Use this for initialization
    void Start () {
        player = this.GetComponent<Rigidbody2D>();
     
	}
	
	// Update is called once per frame
	void Update () {
        bool moveup = Input.GetKey(KeyCode.W);
        bool movedown = Input.GetKey(KeyCode.S);
        bool moveleft = Input.GetKey(KeyCode.A);
        bool moveright = Input.GetKey(KeyCode.D);
        Vector3 mouse = Input.mousePosition;
        
        float vertvel = 0f;
        float horvel = 0f;

        Vector3 screen = Camera.main.WorldToScreenPoint(transform.localPosition);

        Vector2 offset = new Vector2(mouse.x - screen.x, mouse.y - screen.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        if (moveup)
        {
            vertvel = maxSpeed;
        }
        if(movedown)
        {
            vertvel = -maxSpeed;
        }
        if(moveright)
        {
            horvel = maxSpeed;
        }
        if(moveleft)
        {
            horvel = -maxSpeed;
        }
        player.velocity = new Vector2(horvel, vertvel);

        
	}
}
