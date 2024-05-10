using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public static class GameDb
{
    public static int Count;
    public static bool IsPause = false;
    public static bool IsTimeReady = false;
 
    public static void Save()
    {
        PlayerPrefs.SetInt("Count", Count);
    }
 
    public static void Load()
    {
        if (PlayerPrefs.HasKey("Count"))
        {
            Count = PlayerPrefs.GetInt("Count");
        }
        else
        {
            Count = 3 * 60; //給預設值
        }
    }
}