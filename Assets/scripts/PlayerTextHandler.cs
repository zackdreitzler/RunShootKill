using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerTextHandler : MonoBehaviour {
    private static string path;
    private static StreamWriter sw;
    private static StreamReader sr;
    private static int currency = 0;
    private static int maxHealth = 100;
    private static int armor = 0;
    private static string cwep = "";
    private static string w1 = "";
    private static string w2 = "";
    private static string w3 = "";
    private static int pdamage = 5;

    // Use this for initialization

    private void Awake()
    {
        path = "Assets//files//Player.txt";
        readPlayer();
    }
    public void writePlayer(float h, int c, int a, string cw, string w1, string w2, string w3, int pd)
    {
        try
        {
            sw = new StreamWriter(path, false);
            sw.WriteLine("max health:");
            sw.WriteLine(h);
            sw.WriteLine("currency:");
            sw.WriteLine(c);
            sw.WriteLine("armor:");
            sw.WriteLine(a);
            sw.WriteLine("current weapon:");
            sw.WriteLine(cw);
            sw.WriteLine("weapon 1:");
            sw.WriteLine(w1);
            sw.WriteLine("weapon 2:");
            sw.WriteLine(w2);
            sw.WriteLine("weapon 3:");
            sw.WriteLine(w3);
            sw.WriteLine("pistol damage:");
            sw.WriteLine(pd);
            sw.Close();
        }
        catch { Debug.Log("could not write Player"); };
    }

    private void readPlayer()
    {
        try
        {
            sr = new StreamReader(path, true);
            sr.ReadLine();
            maxHealth = int.Parse(sr.ReadLine());
            Debug.Log(maxHealth);
            sr.ReadLine();
            currency = int.Parse(sr.ReadLine());
            sr.ReadLine();
            armor = int.Parse(sr.ReadLine());
            sr.ReadLine();
            cwep = sr.ReadLine();
            sr.ReadLine();
            w1 = sr.ReadLine();
            sr.ReadLine();
            w2 = sr.ReadLine();
            sr.ReadLine();
            w3 = sr.ReadLine();
            sr.ReadLine();
            pdamage = int.Parse(sr.ReadLine());
            sr.Close();
        }
        catch { Debug.Log("could not read Player"); };
        
    }

    public int getArmor()
    {
        return armor;
    }

    public int getHealth()
    {
        return maxHealth;
    }

    public int getCurr()
    {
        return currency;
    }

    public string getCWep()
    {
        return cwep;
    }

    public string getW1()
    {
        return w1;
    }

    public string getW2()
    {
        return w2;
    }

    public string getW3()
    {
        return w3;
    }
	
    public int getpdamage()
    {
        return pdamage;
    }
}
