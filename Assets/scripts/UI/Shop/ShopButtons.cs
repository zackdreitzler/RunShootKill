using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour {
    
    public void BuyArmor()
    {
        //Decrement player currency.
        Debug.Log("Armor Purchased");
    }

    public void BuyHealth()
    {
        Debug.Log("Health Purchased");
    }

    public void pistolUpgrade()
    {
        Debug.Log("Upgrade purchased");
    }

}
