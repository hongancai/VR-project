using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartBtn : MonoBehaviour
{
    public Button restartBtn; 
    
    void Start()
    {
        restartBtn.onClick.AddListener(OnRestartBtnClick);
    }
    
    private void OnRestartBtnClick()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.RestartGame();
        }
    }
}