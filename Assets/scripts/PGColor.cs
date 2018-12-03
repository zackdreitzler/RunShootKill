using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGColor : MonoBehaviour {
    Color pColor = new Color(255f/255, 18f/255, 29f/255, 255f/255);
    Color MGColor = new Color(238f/255, 230f/255, 53f/255, 255f/255);
    Color SGColor = new Color(32f / 255, 32f / 255, 32f / 255, 1);
    SpriteRenderer sr;
    // Use this for initialization
    private void Awake()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    void Start () {
        
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
        if (name == "Shotgun")
        {
            sr.color = SGColor;
        }
    }
}
