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
        Debug.Log(currentIndex);
        if (collision.gameObject.CompareTag("Player")){
            collision.gameObject.GetComponent<damagable>().write();
            SceneManager.LoadScene(currentIndex + 2);
        }
    }
}
