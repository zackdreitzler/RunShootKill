using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTimeScript : MonoBehaviour
{
    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Go same speed bih");
            playerController slowStuff = other.gameObject.GetComponent<playerController>();
            slowStuff.maxSpeed = 5f;
            StartCoroutine(slowTime(slowStuff));
        }
    }

    public IEnumerator slowTime(playerController playerTime)
    {
        Debug.Log("Slow down bih");
        print(Time.time);
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        yield return new WaitForSeconds(5f);
        print(Time.time);
        Time.timeScale = 1.0f;
        Debug.Log("Normal Time Scale");
        Destroy(gameObject);

    }
}
