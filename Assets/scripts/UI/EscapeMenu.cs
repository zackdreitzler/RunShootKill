using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour {
    public GameObject canvas;
    private bool paused;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                canvas.SetActive(false);
                Time.timeScale = 1;
                paused = false;
            }
            else
            {
                canvas.SetActive(true);
                Time.timeScale = 0;
                paused = true;
            }
        }
	}

    public void ResumeGame()
    {
        canvas.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }
}
