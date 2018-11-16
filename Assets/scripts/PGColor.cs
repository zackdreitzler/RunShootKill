using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGColor : MonoBehaviour {
    Color pColor = new Color(255f/255, 18f/255, 29f/255, 255f/255);
    Color MGColor = new Color(238f/255, 230f/255, 53f/255, 255f/255);
<<<<<<< HEAD
    Color SGColor = new Color(32f / 255, 32f / 255, 32f / 255, 1);
=======
>>>>>>> 8728be228b64f83329ef9f87a4cfec281bba9a3d
    SpriteRenderer sr;
	// Use this for initialization
	void Start () {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = pColor;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void changeColor(string name)
    {
        if (name == "MachineGun")
        {
            sr.color = MGColor;
        }
        if (name == "pistol")
        {
            sr.color = pColor;
        }
<<<<<<< HEAD
        if (name == "Shotgun")
        {
            sr.color = SGColor;
        }
=======
>>>>>>> 8728be228b64f83329ef9f87a4cfec281bba9a3d
    }
}
