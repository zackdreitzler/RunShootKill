using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGColor : MonoBehaviour {
    Color pColor = new Color(255f/255, 18f/255, 29f/255, 255f/255);
    Color MGColor = new Color(238f/255, 230f/255, 53f/255, 255f/255);
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
    }
}
