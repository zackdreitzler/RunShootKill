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
        if (player.getXP() >= 50)
        {
            d.updateArmor(10);
            player.GainExp(-50);
        }
    }

    public void BuyHealth()
    {
        if(player.getXP() >= 100)
        {
            d.updateMaxHealth(5);
            player.GainExp(-100);
        }
    }
}
