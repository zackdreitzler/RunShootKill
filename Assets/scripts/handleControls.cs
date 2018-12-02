using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class handleControls : MonoBehaviour {
    private static string path;
    private static StreamWriter sw;
    private static StreamReader sr;
    private static string up;
    private static string down;
    private static string left;
    private static string right;
    private static string switch1;
    private static string switch2;
    private static string switch3;
    private static string action;
	// Use this for initialization

    private void Awake()
    {
        path = "Assets//files//controls.txt";
        readControls();
    }

    public void writeControls(string[] controls)
    {
        sw = new StreamWriter(path, true);
        sw.WriteLine("up:");
        sw.WriteLine(controls[0]);
        sw.WriteLine("left:");
        sw.WriteLine(controls[1]);
        sw.WriteLine("down:");
        sw.WriteLine(controls[2]);
        sw.WriteLine("right:");
        sw.WriteLine(controls[3]);
        sw.WriteLine("action:");
        sw.WriteLine(controls[4]);
        sw.WriteLine("switch1:");
        sw.WriteLine(controls[4]);
        sw.WriteLine("switch2:");
        sw.WriteLine(controls[5]);
        sw.WriteLine("switch3:");
        sw.WriteLine(controls[6]);
        sw.Close();
    }
    private void readControls()
    {
        sr = new StreamReader(path, true);
        sr.ReadLine();
        up = sr.ReadLine();
        sr.ReadLine();
        left = sr.ReadLine();
        sr.ReadLine();
        down = sr.ReadLine();
        sr.ReadLine();
        right = sr.ReadLine();
        sr.ReadLine();
        action = sr.ReadLine();
        sr.ReadLine();
        switch1 = sr.ReadLine();
        sr.ReadLine();
        switch2 = sr.ReadLine();
        sr.ReadLine();
        switch3 = sr.ReadLine();
        sr.Close();
        Debug.Log("finished read");
    }

    public string getUp()
    {
        return up;
    }
    public string getDown()
    {
        return down;
    }
    public string getLeft()
    {
        return left;
    }
    public string getRight()
    {
        return right;
    }
    public string getAction()
    {
        return action;
    }
    public string getS1()
    {
        return switch1;
    }
    public string getS2()
    {
        return switch2;
    }
    public string getS3()
    {
        return switch3;
    }
}
