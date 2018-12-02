using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public string currWep = "";
    public string weapon1 = "";
    public string weapon2 = "";
    public string weapon3 = "";
    private int pdamage = 5;
    public GameObject weapon;
    private PGColor wc;
    public Text currencyText;
    private static handleControls hc;
    private static PlayerTextHandler pth;


    private void Awake()
    {
        wc = weapon.GetComponent<PGColor>();
        hc = this.gameObject.GetComponent<handleControls>();
        pth = this.gameObject.GetComponent<PlayerTextHandler>();
        player = this.GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start() {

        initPlayer();
        setControls();
    }

    // Update is called once per frame
    void Update() {
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
        if (movedown)
        {
            vertvel = -maxSpeed;
        }
        if (moveright)
        {
            horvel = maxSpeed;
        }
        if (moveleft)
        {
            horvel = -maxSpeed;
        }
        player.velocity = new Vector2(horvel, vertvel);

        if (Input.GetKey(switch1))
        {
            if (weapon1 != "")
            {
                currWep = weapon1;
                wc.changeColor(weapon1);
            }
        }
        else if (Input.GetKey(switch2))
        {
            if (weapon2 != "")
            {
                currWep = weapon2;
                wc.changeColor(weapon2);
            }
        }
        else if (Input.GetKey(switch3))
        {
            if (weapon3 != "")
            {
                currWep = weapon3;
                wc.changeColor(weapon3);
            }
        }

        currencyText.text = experience.ToString();
    }

    public void OnTriggerStay2D(Collider2D collision)
    {

        if (Input.GetKey(action))
        {
            if (collision.gameObject.name == "Shotgun")
            {
                if (weapon2 == "")
                {
                    weapon2 = "Shotgun";
                }
                else if (weapon3 == "")
                {
                    weapon3 = "Shotgun";
                }
                else
                {
                    if (currWep != weapon1)
                    {
                        currWep = "Shotgun";
                    }
                    else
                    {
                        weapon2 = "Shotgun";
                    }

                }
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.name == "MachineGun")
            {
                if (weapon2 == "")
                {
                    weapon2 = "MachineGun";
                }
                else if (weapon3 == "")
                {
                    weapon3 = "MachineGun";
                }
                else
                {
                    if (currWep != weapon1)
                    {
                        currWep = "MachineGun";
                    }
                    else
                    {
                        weapon2 = "MachineGun";
                    }

                }
                Destroy(collision.gameObject);
            }
        }
    }

    public void GainExp(int exp)
    {
        experience += exp;
        currencyText.text = experience.ToString();
    }

    private void setControls()
    {
        try
        {
            up = (KeyCode)System.Enum.Parse(typeof(KeyCode), hc.getUp());
            Debug.Log("Got up");
            left = (KeyCode)System.Enum.Parse(typeof(KeyCode), hc.getLeft());
            Debug.Log("Got left");
            down = (KeyCode)System.Enum.Parse(typeof(KeyCode), hc.getDown());
            Debug.Log("Got down");
            right = (KeyCode)System.Enum.Parse(typeof(KeyCode), hc.getRight());
            Debug.Log("Got right");
            action = (KeyCode)System.Enum.Parse(typeof(KeyCode), hc.getAction());
            Debug.Log("Got action");
            switch1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), hc.getS1());
            Debug.Log("Got s1");
            switch2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), hc.getS2());
            Debug.Log("Got s2");
            switch3 = (KeyCode)System.Enum.Parse(typeof(KeyCode), hc.getS3());
            Debug.Log("Got s3");
        }
        catch { Debug.Log("Setting controls failed"); }



    }
    private void initPlayer()
    {
        //read from player file to initialize
        experience = pth.getCurr();
        currWep = pth.getCWep();
        wc.changeColor(currWep);
        if (pth.getW1() != "")
        {
            weapon1 = pth.getW1();
        }
        if (pth.getW2() != "")
        {
            weapon2 = pth.getW2();
        }
        if (pth.getW3() != "")
        {
            weapon3 = pth.getW3();
        }
        pdamage = pth.getpdamage();
    }

    public int getXP()
    {
        return experience;
    }

    public void setpdamage(int d)
    {
        pdamage += d;
    }

    public int getpdamage()
    {
        return pdamage;
    }
}
