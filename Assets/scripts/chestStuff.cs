
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class SpawnPickup : MonoBehaviour {
 
	public GameObject Slow;
   	public GameObject Speed;
   	//public GameObject Health;
    	
 
   	List<GameObject> chestPickups;
 
   	void Start ()
   	{
       	chestPickups = new List<GameObject>();
       	chestPickups.Add(Slow);
       	chestPickups.Add(Speed);
    }
 
   	public void SpawnFromChest(Vector3 pos)
   	{
       	int num = Random.Range (0, chestPickups.Count);    
       	GameObject chestDrop = Instantiate (chestPickups[num], pos, Quaternion.identity) as GameObject;
   	}
}

