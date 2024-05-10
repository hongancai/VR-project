using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
 
public class TimerHandler : MonoBehaviour
{
    public TextMeshPro txtTimer;
    public GameObject pnlGameOver;
     
     
    private Timer _timer;
 
    void Start()
    {
         
        // GameDb.Count = 50;
        GameDb.Load();
         
        SetTimer();
         
        pnlGameOver.SetActive(false);
    }
 
    void Update()
    {
        if (GameDb.IsPause)
        {
            _timer.Stop();
            GameDb.IsTimeReady = false;
        }
        else
        {
            if (!GameDb.IsTimeReady)
            {
                _timer.Start();
                GameDb.IsTimeReady = true;
            }
        }
         
        if (GameDb.Count <= 0)
        {
            pnlGameOver.SetActive(true);
            // do something for game over 
        }
        else
        {
            int _min = (int)(GameDb.Count / 60);
            int _sec = GameDb.Count % 60;
 
            txtTimer.text = $"{_min.ToString("D2")}:{_sec.ToString("D2")}";
        }
    }
 
    private void OnDestroy()
    {
        _timer.Stop();
        GameDb.IsTimeReady = false;
    }
 
 
    private void SetTimer()
    {
        _timer = new Timer(1000); //1 second
        _timer.Elapsed += OnElapsed;
        _timer.AutoReset = true;
        _timer.Start();
        GameDb.IsTimeReady = true;
    }
 
    private void OnElapsed(object sender, ElapsedEventArgs e)
    {
        Debug.Log("time up 1 sec.");
        GameDb.Count--;
        if (GameDb.Count <= 0)
        {
            _timer.Stop();
        }
    }
}