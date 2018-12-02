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
    // Use this for initialization

    private void Awake()
    {
        path = "Assets//files//Player.txt";
        readPlayer();
    }
    public void writePlayer(float h, int c)
    {
        try
        {
            sw = new StreamWriter(path, false);
            sw.WriteLine("max health:");
            sw.WriteLine(h);
            sw.WriteLine("currency:");
            sw.WriteLine(c);
            sw.WriteLine();
            sw.WriteLine();
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
            sr.Close();
        }
        catch { Debug.Log("could not read Player"); };
        
    }
    
    public int getHeatlh()
    {
        return maxHealth;
    }

    public int getCurr()
    {
        return currency;
    }
	
}
