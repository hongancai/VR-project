using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class S2Mgr : MonoBehaviour
{
    public Button btnPause;
    public Button btnReset;
     
    void Start()
    {
        btnPause.onClick.AddListener(OnBtnPauseClick);
        btnReset.onClick.AddListener(OnBtnResetClick);
    }
 
    void Update()
    {
         
    }
 
    void OnBtnPauseClick()
    {
        //返向存取
        GameDb.IsPause = !GameDb.IsPause;
        if (GameDb.IsPause)
        {
            btnPause.GetComponentInChildren<Text>().text = "PLAY";
        }
        else
        {
            btnPause.GetComponentInChildren<Text>().text = "PAUSE";
        }
        GameDb.Save();
    }
    void OnBtnResetClick()
    {
        GameDb.Count = 3 * 60; //3 min
    }
}
