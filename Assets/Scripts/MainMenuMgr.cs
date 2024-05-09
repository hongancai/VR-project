using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuMgr : MonoBehaviour
{
    public Button btnstart;
    public Button btnexit;
    
    void Start()
    {
        btnstart.onClick.AddListener(OnStartClick);
        btnexit.onClick.AddListener(OnExitClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnStartClick()
    {
        SceneManager.LoadScene("S1");
    }
    private void OnExitClick()
    {
        Application.Quit();
    }
}
