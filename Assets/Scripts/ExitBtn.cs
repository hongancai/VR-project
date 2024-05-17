using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitBtn : MonoBehaviour
{
    public Button exitbtn;
    // Start is called before the first frame update
    void Start()
    {
        exitbtn.onClick.AddListener(Onexitbtn);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void Onexitbtn()
    { 
        Application.Quit();
    }
}
