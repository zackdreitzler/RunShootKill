using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    public float maxSpeed = 10f;
    private int experience = 0;
    private Rigidbody2D player;
    private KeyCode up = KeyCode.W;
    private KeyCode down = KeyCode.S;
    private KeyCode right = KeyCode.D;
    private KeyCode left = KeyCode.A;
    private KeyCode switch1 = KeyCode.Alpha1;
    private KeyCode switch2 = KeyCode.Alpha2;
    private KeyCode switch3 = KeyCode.Alpha3;
    private KeyCode action = KeyCode.E;
    private int money = 0;
    public string currWep = "";
    public string weapon1 = "";
    public string weapon2 = "";
    public string weapon3 = "";

    // Use this for initialization
    void Start () {
        player = this.GetComponent<Rigidbody2D>();
        weapon1 = "pistol";
        currWep = weapon1;
	}
	
	// Update is called once per frame
	void Update () {
        bool moveup = Input.GetKey(up);
        bool movedown = Input.GetKey(down);
        bool moveleft = Input.GetKey(left);
        bool moveright = Input.GetKey(right);
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
        
        if(Input.GetKey(switch1))
        {
            if(weapon1 != "")
            {
                currWep = weapon1;
            }
        }
        else if(Input.GetKey(switch2))
        {
            if (weapon2 != "")
            {
                currWep = weapon2;
            }
        }
        else if(Input.GetKey(switch3))
        {
            if (weapon3 != "")
            {
                currWep = weapon3;
            }
        }

        
	}

    public void OnTriggerStay2D(Collider2D collision)
    {
        
        if (Input.GetKey(action))
        { 
            if(collision.gameObject.name == "Shotgun")
            {
                if(weapon2 == "")
                {
                    weapon2 = "Shotgun";
                }
                else if(weapon3 == "")
                {
                    weapon3 = "Shotgun";
                }
                else
                {
                    currWep = "Shotgun";
                }
                Destroy(collision.gameObject);
            }
        }
    }

    public void GainExp(int exp)
    {
        experience += exp;
    }
}
