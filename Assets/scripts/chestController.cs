using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestController : MonoBehaviour
{
    public Sprite closedChest;

    void Start() 
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = closedChest;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Player" && other.tag == "closedChest")
        {
            playerController player = other.gameObject.GetComponent<playerController>();
            Debug.Log("Opening Chest");
            StartCoroutine(chestOpen(player));
        }

        public IEnumerator chestOpen(playerController playerIsDumb)
        {
            Debug.Log("I hate me");
            //gameObject.GetComponent<SpriteRenderer>().sprite = closedChest;
            yield return new WaitForSeconds(5);
            //Destroy(gameObject);
            // replace game object with openChest. 

            // chest no longer produces powerups
        }
    }

}
