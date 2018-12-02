using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagable : MonoBehaviour {

    public int currHealth = 100;
    private int maxHealth = 100;
    private static playerController pc;
    private static PlayerTextHandler pth;
    public RectTransform healthBar;

    private void Start()
    {
        pc = this.gameObject.GetComponent<playerController>();
        pth = this.gameObject.GetComponent<PlayerTextHandler>();
        maxHealth = pth.getHeatlh();
        Debug.Log(maxHealth);
        currHealth = maxHealth;
    }

    void Update () {
        bool complete = false;
        if (currHealth <= 0)
        {
            if (complete == false)
            {
                gameObject.SetActive(false);
                this.gameObject.GetComponent<PlayerTextHandler>().writePlayer(maxHealth, pc.getXP());
                complete = true;
            }

            Debug.Log("Game Over");

        }
	}

    public void takeDamage(int damage)
    {
        currHealth -= damage;
        healthBar.sizeDelta = new Vector2(currHealth, healthBar.sizeDelta.y);
    }

}
