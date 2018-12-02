using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public float speedScale = 11f;
    //public bool isFaster = false;
    public float normalSpeed = 5f;
    public float speedTime = 5f;
    //playerController player;

    // OnTriggerEnter marks the collider as the trigger. 
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Speeeeeed");
            playerController speedOop = other.gameObject.GetComponent<playerController>();
            print(speedOop.maxSpeed);
            speedOop.maxSpeed = speedScale;
            StartCoroutine(speedLength(speedOop));
            Debug.Log("im dumb");
        }
    }

    public IEnumerator speedLength(playerController playerSpeed)
    {
        Debug.Log("Sup");
        print(Time.time);
        print(playerSpeed.maxSpeed);
        yield return new WaitForSecondsRealtime(5);
        print(Time.time);
        playerSpeed.maxSpeed = normalSpeed;
        print(playerSpeed.maxSpeed);
        Destroy(gameObject);
    }
}
