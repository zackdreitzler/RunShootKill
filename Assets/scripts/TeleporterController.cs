using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterController : MonoBehaviour {
    private int currentIndex;

    //When a player enters the teleporter they are sent to the next scene.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;

        if (collision.gameObject.CompareTag("Player")){
            SceneManager.LoadScene(currentIndex + 1);
        }
    }
}
