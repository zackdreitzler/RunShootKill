using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour {
    private playerController player;
    private damagable d;
    private void Start()
    {
        player = FindObjectOfType<playerController>();
        d = FindObjectOfType<damagable>();
    }
    public void BuyArmor()
    {
        //Decrement player currency.
        if(player.getXP() >= 50)
        {
            d.updateArmor(10);
            player.GainExp(-50);
            Debug.Log("Armor Purchased");
        }
        
    }

    public void BuyHealth()
    {
        if(player.getXP() >= 75)
        {
            d.updateMaxHealth(5);
            player.GainExp(-75);
            Debug.Log("Health Purchased");
        }
       
    }

    public void pistolUpgrade()
    {
        if(player.getXP() >= 100)
        {
            player.setpdamage(2);
            player.GainExp(-100);
            Debug.Log("Upgrade purchased");
        }
       
    }

}
