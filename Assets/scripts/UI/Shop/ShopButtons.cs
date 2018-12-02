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
        Debug.Log("Armor Purchased");
    }

    public void BuyHealth()
    {
        if(player.getXP() >= 100)
        {
            d.updateMaxHealth(10);
            player.GainExp(-100);
            Debug.Log("Health Purchased");
        }
       
    }

    public void pistolUpgrade()
    {
        Debug.Log("Upgrade purchased");
    }

}
