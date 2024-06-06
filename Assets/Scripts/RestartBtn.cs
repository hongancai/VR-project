using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartBtn : MonoBehaviour
{
    public Button restartbtn; 
    
    // Start is called before the first frame update
    void Start()
    {
        restartbtn.onClick.AddListener(Onrestartbtn);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void Onrestartbtn()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetGame();
        }
        SceneManager.LoadScene("S2");
    }
}
