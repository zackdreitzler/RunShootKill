using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                write();
                complete = true;
                SceneManager.LoadScene("HubWorld");
            }

            Debug.Log("Game Over");

        }
	}

    public void updateMaxHealth(int n)
    {
        maxHealth = maxHealth + n;
        currHealth = maxHealth;
    }

    public void write()
    {
        this.gameObject.GetComponent<PlayerTextHandler>().writePlayer(maxHealth, pc.getXP());
    }
    public void takeDamage(int damage)
    {
        currHealth -= damage;
        healthBar.sizeDelta = new Vector2(currHealth, healthBar.sizeDelta.y);
    }

}
