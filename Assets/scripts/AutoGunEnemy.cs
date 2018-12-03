using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGunEnemy : MonoBehaviour {


    public float AGEMaxSpeed;
    public float AGEAcceleration;
    public float AGERotateSpeed;
    public GunController enemyGun;

    private float AGECurrentSpeed = 0;
    private float AGELeftSpeed = 0;



    private playerController player;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<playerController>();
    }

    // Update is called once per frame
    void Update () {
        Movement();
    }

    void Movement()
    {
        // Rotate, Move and Shoot
        if(Vector3.Distance(player.transform.position, this.transform.position) < 15)
        {
            Rotation();
            transform.Translate(Vector3.right * AGECurrentSpeed * Time.deltaTime);
            
            // Random strafing
            AGELeftSpeed += Random.Range(-.005f, .005f) * AGEAcceleration;
           
            if (AGELeftSpeed > (AGEMaxSpeed / 4))
            {
                AGELeftSpeed -= (.01f * AGEAcceleration);
            } else if (AGELeftSpeed < (-AGEMaxSpeed / 2))
            {
                AGELeftSpeed += (.01f * AGEAcceleration);
            }
            
            transform.Translate(Vector3.up * AGELeftSpeed / 50);
            
            if (Vector3.Distance(player.transform.position, this.transform.position) < 10)
            {
                enemyGun.isFiring = true;
            }

            
        }
       
        // accelerate backwards
        if (Vector3.Distance(player.transform.position, this.transform.position) < 3)
        {
            if(AGECurrentSpeed > (-AGEMaxSpeed/2))
            {
                AGECurrentSpeed -= (AGEAcceleration * Time.deltaTime);
            }
           
        }
        
        // decellerate
        else if (Vector3.Distance(player.transform.position, this.transform.position) < 3.5 || Vector3.Distance(player.transform.position, this.transform.position) > 12)
        {
            if (AGECurrentSpeed > 0)
            {
                AGECurrentSpeed -= (AGEAcceleration * Time.deltaTime);
            } else if (AGECurrentSpeed < 0)
            {
                AGECurrentSpeed += (AGEAcceleration * Time.deltaTime);
            }
        }
    
        // accelerate forwards
        else if (Vector3.Distance(player.transform.position, this.transform.position) < 14)
        {
           
            if (AGECurrentSpeed < AGEMaxSpeed)
            {
                AGECurrentSpeed += (AGEAcceleration * Time.deltaTime);
            }
            
        }
    }

    // Rotate enemy to look at player
    private void Rotation()
    {
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg);
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, AGERotateSpeed * Time.deltaTime);
    }


    
}
