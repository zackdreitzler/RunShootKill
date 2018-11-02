using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopControl : MonoBehaviour {
    public GameObject shopPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) openShop();
    }

    private void openShop()
    {
        shopPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
